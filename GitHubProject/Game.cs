using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GitHubProject
{
    internal class Game
    {
        private static int idCount = 0;

        private int id;
        private string title;
        private string type;
        private int releaseYear;

        public Game()
        {
            this.id = ++idCount;
        }
        public Game(int id, string title, string type, int releaseYear)
        {
            this.id = ++idCount;
            this.title = title;
            this.type = type;
            this.releaseYear = releaseYear;
        }
        public static void gameEntries()
        {
            Program.games.Add(new Game(1, "NOX", "action RPG", 2000));
            Program.games.Add(new Game(2, "FoE", "strategy game", 2012));
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int ReleaseYear
        {
            get { return releaseYear; }
            set { releaseYear = value; }
        }
        public override string ToString()
        {
            return $"{id} {title} {type} {releaseYear}";
        }
        public static void StartWork()
        {
            Console.WriteLine("Enter a number of required action from the menu bellow:");
            Console.WriteLine("1 - list of games");
            Console.WriteLine("2 - add new game");
            Console.WriteLine("3 - edit record");
            Console.WriteLine("4 - delete game");
            Console.WriteLine("5 - exit");
            Console.WriteLine("---------------------");
            Console.WriteLine();
        }
        public static void GameList(List<Game> games)
        {
            Console.WriteLine("ID   | Title    | Type          | Release Year");
            Console.WriteLine("----------------------------------------------");

            foreach (var game in games)
            {
                PrintGameEntry(game);
            }
            Console.WriteLine();
        }
        public static void PrintGameEntry(Game game)
        {
            Console.WriteLine($"{game.Id,-4} | {game.Title,-8} | {game.Type,-13} | {game.ReleaseYear}");
        }
        public static void AddNewGame(List<Game> games)
        {
            Game game = new Game();
            Console.WriteLine("Enter game title ");
            game.Title = stringValidation(2, 255);
            Console.WriteLine("Enter game type ");
            game.Type = stringValidation(2, 255);
            game.ReleaseYear = yearValidation(1961, DateTime.Now.Year);
            games.Add(game);
            Console.WriteLine();
        }
        public static void EditRecord(List<Game> games, int id)
        {
            Console.WriteLine("Enter ID of the game you want to edit: ");

            id = Convert.ToInt32(Console.ReadLine());
            string title = "";
            string type = "";
            int releaseYear = 0;
            bool continueEditing = true;

            foreach (var g in games)
            {
                if (g.Id == id)
                {
                    do
                    {
                        Console.WriteLine("Enter new title (or type 'exit' to stop editing)");
                        title = Console.ReadLine();

                        if (title.ToLower() == "exit")
                        {
                            continueEditing = false;
                            break;
                        }

                        title = stringValidation(2, 255);

                        Console.WriteLine("Enter new type (or type 'exit' to stop editing)");
                        type = Console.ReadLine();

                        if (type.ToLower() == "exit")
                        {
                            continueEditing = false;
                            break;
                        }

                        type = stringValidation(2, 255);

                        Console.WriteLine("Enter new release year (or type 'exit' to stop editing)");
                        string input = Console.ReadLine();

                        if (input.ToLower() == "exit")
                        {
                            continueEditing = false;
                            break;
                        }

                        releaseYear = yearValidation(1961, DateTime.Now.Year);

                        g.Title = title;
                        g.Type = type;
                        g.ReleaseYear = releaseYear;

                        Console.WriteLine("Continue editing? (yes/no)");
                        string response = Console.ReadLine();

                        if (response.ToLower() == "no")
                        {
                            continueEditing = false;
                        }

                    } while (continueEditing);

                    break;
                }
                else
                {
                    Console.WriteLine($"Game ID = {id} not found");
                }
            }
            Console.WriteLine();
        }
        public static void DeleteGame(List<Game> games, int id)
        {
            Console.WriteLine("Enter ID of the game you want to delete: ");

            id = Convert.ToInt32(Console.ReadLine());
            string title = "";
            bool found = false;
            foreach (var g in games)
            {
                if (g.Id == id)
                {
                    title = g.Title;
                    found = games.Remove(g);
                    break;
                }
            }
            if (found)
            {
                Console.WriteLine($"Game {title} sucessfully deleted");
            }
            else
            {
                Console.WriteLine($"Game ID = {id} not found");
            }
            Console.WriteLine();
        }
        public static void Exit()
        {
            Environment.Exit(0);
        }

        public static string stringValidation(int minLength, int maxLength)
        {
            bool isValidLength = false;
            string input;

            do
            {
                input = Console.ReadLine();

                isValidLength = input.Length >= minLength && input.Length <= maxLength;

                if (!isValidLength)
                {
                    Console.WriteLine($"Invalid input length. Please enter a title with length between {minLength} and {maxLength}.");
                }

            } while (!isValidLength);

            return input;
        }
        public static int yearValidation(int minYear, int maxYear)
        {
            bool isValidYear = false;
            bool correctYear = false;
            int releaseYear = 0;

            do
            {
                Console.WriteLine("Enter a year (4 digits):");
                string input = Console.ReadLine();

                isValidYear = input.Length == 4 && int.TryParse(input, out releaseYear);

                if (!isValidYear)
                {
                    Console.WriteLine("Invalid input. Please enter a 4-digit number.");
                }
                else
                {
                    correctYear = releaseYear >= minYear && releaseYear <= maxYear;

                    if (!correctYear)
                    {
                        Console.WriteLine($"Release year must be between {minYear} and {maxYear}.");
                    }
                }

            } while (!isValidYear || !correctYear);

            return releaseYear;
        }


    }
}

