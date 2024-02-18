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
                StartMenu();
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Game.GameList();
                        break;
                    case 2:
                        Game.AddNewGame();
                        break;
                    case 3:
                        Game.EditRecord();
                        break;
                    case 4:
                        Game.DeleteGame();
                        break;
                    case 5:
                        Rent.AvailableGamesList(); // 
                        break;
                    case 6:
                        Rent.RentedGamesList();// 
                        break;
                    case 7:
                        Rent.RentGame();// 
                        break;
                    case 8:
                        Rent.ReturnGame(); // veikia su klaidom
                        break;
                    case 9:
                        Rent.ShowGameRentHistory(); // problemos
                        break;
                    case 10:
                        Rent.EditRentInfo();// 
                        break;
                    case 11:
                        // dar nera      sort games info
                        break;
                    case 12:
                        ExitProgram();
                        break;
                    default:
                        Console.WriteLine("Not a valid input, enter a number from menu list");
                        break;
                }
            }
        }
        public static void ExitProgram()
        {
            Environment.Exit(0);
        }
        public static void StartMenu()
        {
            Console.WriteLine("Enter a number of required action from the menu bellow:");
            Console.WriteLine("1 - list of games");
            Console.WriteLine("2 - add new game");
            Console.WriteLine("3 - edit record");
            Console.WriteLine("4 - delete game");
            Console.WriteLine("5 - list of available games");
            Console.WriteLine("6 - list of rented games"); ;
            Console.WriteLine("7 - rent game");
            Console.WriteLine("8 - return game");
            Console.WriteLine("9 - show game's rent history");//not done
            Console.WriteLine("10 - edit rent info");
            Console.WriteLine("11 = sort games info");//not done
            Console.WriteLine("12 - exit Menu");
            Console.WriteLine("---------------------");
            Console.WriteLine();
        }


    }
}
