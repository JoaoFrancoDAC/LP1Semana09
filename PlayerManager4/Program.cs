using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayerManager4 // >>> Change to PlayerManager2 for exercise 4 <<< //
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The list of all players.
        /// </summary>
        private List<Player> playerList;

        /// <summary>
        /// Program begins here.
        /// </summary>
        private static void Main()
        {
            // Create a new instance of the player listing program
            Program prog = new Program();
            // Start the program instance
            prog.Start();
        }

        /// <summary>
        /// Creates a new instance of the player listing program.
        /// </summary>
        private Program()
        {
            // Initialize the player list with two players using collection
            // initialization syntax
            playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
            playerList.Sort();
        }

        /// <summary>
        /// Start the player listing program instance
        /// </summary>
        private void Start()
        {
            // We keep the user's option here
            string option;

            // Main program loop
            do
            {
                // Show menu and get user option
                ShowMenu();
                option = Console.ReadLine();

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        InsertPlayer();
                        break;
                    case "2":
                        ListPlayers(playerList.OrderByDescending(p => p.Score));
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        ListPlayers(playerList.OrderBy(p => p.Name));
                        break;
                    case "5":
                        ListPlayers(playerList.OrderByDescending(p => p.Name));
                        break;
                    case "6":
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
                        break;
                }

                // Wait for user to press a key...
                if (option != "6")
                {
                    Console.Write("\nPress any key to continue...");
                    Console.ReadKey(true);
                    Console.WriteLine("\n");
                }
            } while (option != "6");
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Insert player");
            Console.WriteLine("2. List all players (Pontos Decrescentes)");
            Console.WriteLine("3. List players with score greater than");
            Console.WriteLine("4. List all players (Ordem Alfabética)");
            Console.WriteLine("5. List all players (Ordem Contra-Alfabética)");
            Console.WriteLine("6. Exit");
            Console.Write("Option: ");
        }

        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        private void InsertPlayer()
        {
            Console.Write("Enter player name: ");
            string name = Console.ReadLine();

            Console.Write("Enter player score: ");
            if (int.TryParse(Console.ReadLine(), out int score))
            {
                Player newPlayer = new Player(name, score);
                playerList.Add(newPlayer);
                Console.WriteLine("Player added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid score. Player not added.");
            }
        }

        /// <summary>
        /// Show all players in a list of players. This method can be static
        /// because it doesn't depend on anything associated with an instance
        /// of the program. Namely, the list of players is given as a parameter
        /// to this method.
        /// </summary>
        /// <param name="playersToList">
        /// An enumerable object of players to show.
        /// </param>
        private static void ListPlayers(IEnumerable<Player> playersToList)
        {
            foreach (Player player in playersToList)
            {
                Console.WriteLine($"Name: {player.Name}, Score: {player.Score}");
            }
        }

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            Console.Write("Enter minimum score: ");
            if (int.TryParse(Console.ReadLine(), out int minScore))
            {
                IEnumerable<Player> highScorePlayers = GetPlayersWithScoreGreaterThan(minScore);
                
                Console.WriteLine($"\nPlayers with score greater than {minScore}:");
                if (highScorePlayers.Any())
                {
                    ListPlayers(highScorePlayers);
                }
                else
                {
                    Console.WriteLine("No players found with a score above the specified value.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            return playerList
                .Where(player => player.Score > minScore)
                .OrderByDescending(player => player.Score);
        }
    }
}