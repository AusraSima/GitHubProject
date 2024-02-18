using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GitHubProject
{
    internal class Rent
    {
        private string customerName;
        private DateTime rentStart;
        private DateTime rentEnd;
        private TimeSpan timeDifference;


        public Rent()
        {
        }
        public Rent(string renterName, DateTime rentStart, DateTime rentEnd)
        {
            this.customerName = customerName;
            this.rentStart = rentStart;
            this.rentEnd = rentEnd;

        }
        public string RenterName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public DateTime RentStart
        {
            get { return rentStart; }
            set { rentStart = value; }
        }
        public DateTime RentEnd
        {
            get { return rentEnd; }
            set { rentEnd = value; }
        }


        public static void AvailableGamesList()
        {
            Console.WriteLine("List of available games: ");
            Console.WriteLine("ID   | Title    | Type          | Release Year");
            Console.WriteLine("----------------------------------------------");

            foreach (var game in Program.games)
            {
                if (IsAvailableForRent())
                {
                    Game.PrintGameEntry(game);
                }
            }
            Console.WriteLine();
        }
        public static void RentedGamesList()
        {
            Console.WriteLine("List of rented games: ");
            Console.WriteLine("ID   | Title    | Type          | Release Year");
            Console.WriteLine("----------------------------------------------");

            foreach (var game in Program.games)
            {
                if (!IsAvailableForRent())
                {
                    Game.PrintGameEntry(game);
                }
            }
            Console.WriteLine();
        }

        public static void RentGame()// 
        {
            Console.WriteLine("Enter a number of the game from the list: ");
            Rent.AvailableGamesList();
            Console.WriteLine();

            int wantedId = Convert.ToInt32(Console.ReadLine());

            foreach (var game in Program.games)
            {
                if (game.Id == wantedId)
                {
                    if (!IsAvailableForRent())
                    {
                        Console.WriteLine($"The game {game.Id} is not available .");
                        break;
                    }
                    Console.WriteLine("Enter customer name: ");
                    Rent renterData = new Rent();
                    renterData.customerName = Console.ReadLine();
                    renterData.rentStart = DateTime.Now;
                    game.Renting.Add(renterData);

                    Console.WriteLine($"Zaidimas {game.Id}, \"{game.Title}\", sekmingai isnuomuotas");
                }
            }
        }
        public static void ReturnGame()
        {
            Console.WriteLine("Enter ID of the game you want to return: ");
            Rent.RentedGamesList();
            Console.WriteLine();

            int returnId = Convert.ToInt32(Console.ReadLine());

            foreach (var game in Program.games)
            {
                if (game.Id == returnId)
                {
                    if (game.Renting.Count == 0)
                    {
                        Console.WriteLine("Sis zaidimas niekada nebuvo isnuomuotas!");
                        break;
                    }
                    if (game.Renting.Last().rentEnd != DateTime.MinValue)
                    {
                        Console.WriteLine("Sis zaidimas jau yra grazintas!");
                        break;
                    }
                    game.Renting.Last().rentEnd = DateTime.Now;
                    game.Renting.Last().timeDifference = game.Renting.Last().rentEnd - game.Renting.Last().rentEnd;
                    Console.WriteLine($"Zaidimas \"{game.Title}\" sekmingai grazintas");
                    break;
                }
            }
        }

        public static void EditRentInfo()
        {
            Console.WriteLine("List of games: ");
            Console.WriteLine("ID   | Title    | Type          | Release Year");
            Console.WriteLine("----------------------------------------------");

            foreach (var game in Program.games)
            {
                Game.PrintGameEntry(game);
            }
            Console.WriteLine();
            Console.WriteLine("Enter the ID of the game whose rental data you want to edit: ");

            int id = Convert.ToInt32(Console.ReadLine());

            bool continueEditing = true;

            foreach (var g in Program.games)
            {
                if (g.Id == id)
                {
                    do
                    {
                        Console.WriteLine("Enter new customer name (or type 'exit' to stop editing)");
                        g.Renting.Last().customerName = Console.ReadLine();

                        if (g.Renting.Last().customerName.ToLower() == "exit")
                        {
                            continueEditing = false;
                            break;
                        }

                        Game.stringValidation(2, 255, g.Renting.Last().customerName);

                        Console.WriteLine("Continue editing? (yes/no)");
                        string response = Console.ReadLine();

                        if (response.ToLower() == "no")
                        {
                            continueEditing = false;
                        }

                    } while (continueEditing);

                    break;
                }
            }
            Console.WriteLine($"Game ID = {id} not found");
            Console.WriteLine();
        }

        public static void ShowGameRentHistory()
        {
            Console.WriteLine("Enter ID of the game whose rent history you want to see: ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var game in Program.games)
            {
                if (game.Id == id)
                {
                    foreach (var rent in game.Renting)
                    {
                        Console.WriteLine(rent);
                    }
                    break;
                }
            }
        }
        public static bool IsAvailableForRent()
        {
            foreach (var game in Program.games)
            {
                if ((game.Renting.Count > 0 && game.Renting.Last().RentEnd != DateTime.MinValue) || game.Renting.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }





}

