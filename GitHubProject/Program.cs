using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using static System.Reflection.Metadata.BlobBuilder;

namespace GitHubProject
{
    internal class Program
    {
        public static List<Game> games = new List<Game>();
        static void Main(string[] args)
        {
            Game.gameEntries();

            while (true)
            {
                int id = 0;
                Game.StartWork();
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Game.GameList(games);
                        break;
                    case 2:
                        Game.AddNewGame(games);
                        break;
                    case 3:
                        Game.EditRecord(games, id);
                        break;
                    case 4:
                        Game.DeleteGame(games, id);
                        break;
                    case 5:
                        Game.Exit();
                        break;
                    default:
                        Console.WriteLine("Not a valid input, enter a number from menu list");
                        break;
                }
            }

        }
    }
}
