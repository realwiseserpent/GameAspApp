﻿using GameAspApp.DAL.Contexts;
using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using GameAspApp.Repositories.Interfaces;
using AutoMapper;

namespace GameAspApp.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями "Игра".
    /// </summary>
    public class GameRepository : BaseRepository<GameDto, Game>, IGameRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GameRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public GameRepository(GameAspAppContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}