using static System.Reflection.Metadata.BlobBuilder;

namespace GitHubProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Game> games = new List<Game>();
            games.Add(new Game("NOX", "action RPG", 2000));
            games.Add(new Game("FoE", "strategy game", 2012));

            while (true)
            {
                Console.WriteLine("Pasirinkite norima veiksma:");
                Console.WriteLine("1 - perziureti zaidimus");
                Console.WriteLine("2 - prideti zaidima");
                Console.WriteLine("3 - redaguoti irasa");
                Console.WriteLine("4 - istrinti zaidima");
                Console.WriteLine("5 - iseiti");
                Console.WriteLine("---------------------");
                Console.WriteLine();

                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        foreach (var g in games)
                        {
                            Console.WriteLine($"Game name: {g.Title}, game type: {g.Type}, release year: {g.ReleaseYear}");
                        }
                        break;
                    case 2:
                        Game game = new Game();
                        Console.WriteLine("Iveskite zaidimo pavadinima");
                        game.Title = Console.ReadLine();
                        Console.WriteLine("Iveskite zaidimo tipa");
                        game.Type = Console.ReadLine();
                        Console.WriteLine("Iveskite zaidimo isleidimo metus");
                        game.ReleaseYear = Convert.ToInt32(Console.ReadLine());
                        games.Add(game);
                        break;
                    case 3:
                        Console.WriteLine("3- redaguoti irasa");
                        break;
                    case 4:
                        Console.WriteLine("4 - istrinti zaidima");
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;

                }
            }
        }
    }
}
