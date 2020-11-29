using System.Collections.Generic;
using GameAspApp.DAL.Domain;
using System;

namespace GameAspApp.DAL.Mocks
{
    /// <summary>
    /// Mock для коллекции сущностей "Игры".
    /// </summary>
    public class GameMock
    {
        /// <summary>
        /// Получение коллекции сущностей "Игры".
        /// </summary>
        /// <returns>Коллекция сущностей "Игры".</returns>
        public static IEnumerable<Game> GetGames()
        {
            return new List<Game> {
            new Game
                {
                    Id = 1,
                    ReleaseDate = DateTime.Now,
                    Developer = "Me",
                    Publisher = "Me",
                    //Genre = "Programming",
                    Name = "GameAspApp",
                    Metascore = 10
                },
            new Game
                {
                    Id = 2,
                    ReleaseDate = Convert.ToDateTime("11.11.11"),
                    Developer = "Bethesda Game Studios",
                    Publisher = "Bethesda Softworks",
                    //Genre = "Action role-playing",
                    Name = "GameAspAppTest",
                    Metascore = 9999
                },
            new Game
                {
                    Id = 2,
                    ReleaseDate = DateTime.Now,
                    Developer = "Not Me",
                    Publisher = "Not Me",
                    //Genre = "Testing",
                    Name = "GameAspAppTest",
                    Metascore = 4
                }};
        }
    }
}
