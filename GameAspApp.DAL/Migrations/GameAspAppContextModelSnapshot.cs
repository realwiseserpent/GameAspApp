﻿// <auto-generated />
using System;
using GameAspApp.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GameAspApp.DAL.Migrations
{
    [DbContext(typeof(GameAspAppContext))]
    partial class GameAspAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("GameAspApp.DAL.Domain.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Developer")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<float>("Metascore")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Publisher")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("SeriesId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SeriesId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameAspApp.DAL.Domain.GameGenre", b =>
                {
                    b.Property<long>("Entity1Id")
                        .HasColumnType("bigint")
                        .HasColumnName("GameId");

                    b.Property<long>("Entity2Id")
                        .HasColumnType("bigint")
                        .HasColumnName("GenreId");

                    b.HasKey("Entity1Id", "Entity2Id");

                    b.HasIndex("Entity2Id");

                    b.ToTable("GameGenres");
                });

            modelBuilder.Entity("GameAspApp.DAL.Domain.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(2500)
                        .HasColumnType("character varying(2500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("GameAspApp.DAL.Domain.Series", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(2500)
                        .HasColumnType("character varying(2500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("GameAspApp.DAL.Domain.Game", b =>
                {
                    b.HasOne("GameAspApp.DAL.Domain.Series", "Series")
                        .WithMany()
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Series");
                });

            modelBuilder.Entity("GameAspApp.DAL.Domain.GameGenre", b =>
                {
                    b.HasOne("GameAspApp.DAL.Domain.Game", "Entity1")
                        .WithMany("GameGenres")
                        .HasForeignKey("Entity1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameAspApp.DAL.Domain.Genre", "Entity2")
                        .WithMany("GameGenres")
                        .HasForeignKey("Entity2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entity1");

                    b.Navigation("Entity2");
                });

            modelBuilder.Entity("GameAspApp.DAL.Domain.Game", b =>
                {
                    b.Navigation("GameGenres");
                });

            modelBuilder.Entity("GameAspApp.DAL.Domain.Genre", b =>
                {
                    b.Navigation("GameGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
