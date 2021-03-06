﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GameAspApp.DAL.Contexts;
using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using GameAspApp.Repositories.Interfaces.CRUD;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace GameAspApp.Repositories
{
    /// <summary>
    /// Базовый класс репозитория для работы с CRUD.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// <typeparam name="TModel">Доменная модель.</typeparam>
    public abstract class BaseRepository<TDto, TModel> : ICrudRepository<TDto, TModel>
        where TDto : BaseDto
        where TModel : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly GameAspAppContext _сontext;
        protected DbSet<TModel> _dbSet => _сontext.Set<TModel>();
        /// <summary>
        /// Контекст для работы с данными БД.
        /// </summary>
        public GameAspAppContext Context { get { return _сontext; } }

        /// <summary>
        /// Инициализирует экземпляр <see cref="BaseRepository{TDto, TModel}"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        protected BaseRepository(GameAspAppContext context, IMapper mapper)
        {
            _сontext = context;
            _mapper = mapper;
        }

        /// <inheritdoc cref="ICreatable{TDto, TModel}.CreateAsync(TDto)"/>
        public async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TModel>(dto);
            await _dbSet.AddAsync(entity);
            await _сontext.SaveChangesAsync();
            return await GetAsync(entity.Id);
        }

        /// <inheritdoc cref="IDeletable{TDto, TModel}.DeleteAsync(long[])"/>
        public async Task DeleteAsync(params long[] ids)
        {
            var entities = await _dbSet
                                .Where(x => ids.Contains(x.Id))
                                .ToListAsync();

            _сontext.RemoveRange(entities);
            await _сontext.SaveChangesAsync();
        }

        /// <inheritdoc cref="IGettableById{TDto, TModel}.GetAsync(long, CancellationToken)"/>
        public async Task<TDto> GetAsync(long id, CancellationToken token = default)
        {
            var entity = await DefaultIncludeProperties(_dbSet)
                              .AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);

            var dto = _mapper.Map<TDto>(entity);

            return dto;
        }

        /// <inheritdoc cref="IUpdatable{TDto, TModel}.UpdateAsync(TDto, CancellationToken)"/>
        public async Task<TDto> UpdateAsync(TDto dto, CancellationToken token = default)
        {
            var entity = _mapper.Map<TModel>(dto);
            _сontext.Update(entity);
            await _сontext.SaveChangesAsync(token);
            var newEntity = await GetAsync(entity.Id);

            return _mapper.Map<TDto>(newEntity);
        }

        /// <inheritdoc cref="IGettable{TDto, TModel}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<TDto>> GetAsync(CancellationToken token = default)
        {
            var entities = await DefaultIncludeProperties(_dbSet).AsNoTracking().ToListAsync();

            var dtos = _mapper.Map<IEnumerable<TDto>>(entities);

            return dtos;
        }

        /// <summary>
        /// Добавляет к выборке связанные параметры.
        /// </summary>
        /// <param name="dbSet">Коллекция DbSet репозитория.</param>
        protected virtual IQueryable<TModel> DefaultIncludeProperties(DbSet<TModel> dbSet) => dbSet;

    }
}