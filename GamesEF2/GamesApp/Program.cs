using System;
using System.Linq;
using GamesData;
using GamesModels;

namespace GamesApp
{
    class Program
    {
        static void Main()
        {
            using (var db = new GamesContext())
            {
                db.Database.EnsureCreated();

                if (!db.Games.Any())
                {
                    db.Games.Add(new Game { Title = "The Witcher 3", Studio = "CD Projekt", Genre = "RPG", ReleaseDate = new DateTime(2015, 5, 19) });
                    db.Games.Add(new Game { Title = "GTA V", Studio = "Rockstar", Genre = "Action", ReleaseDate = new DateTime(2013, 9, 17) });
                    db.Games.Add(new Game { Title = "Minecraft", Studio = "Mojang", Genre = "Sandbox", ReleaseDate = new DateTime(2011, 11, 18) });
                    db.SaveChanges();
                    Console.WriteLine("Игры добавлены.");
                }

                Console.WriteLine("\nСписок игр:");
                foreach (var game in db.Games.ToList())
                {
                    Console.WriteLine($"{game.Title} | {game.Studio} | {game.Genre} | {game.ReleaseDate:yyyy-MM-dd}");
                }
            }
            Console.ReadLine();
        }
    }
}