using System;

namespace Cpsc370Final
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
                Console.WriteLine("Usage: Cpsc370Final <arguments>");
            
            ShowArguments(args);
            
            WheelOfFortune.StartGame();
        }

        private static void ShowArguments(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("  Argument " + i + ": " + args[i]);
            }
        }
    }

    class WheelOfFortune
    {
        private static readonly Dictionary<string, List<string>> CategoryPhrases = new Dictionary<string, List<string>>
        {
            { "Social media apps", new List<string> { "Facebook", "Instagram", "Snapchat", "TikTok", "Twitter", "LinkedIn", "Pinterest", "Reddit", "WhatsApp" } },
            { "Fast food restaurants", new List<string> { "McDonald's", "Burger King", "KFC", "Taco Bell", "Wendy's", "Subway", "Chick-fil-A", "Domino's Pizza", "Popeyes" } },
            { "Reality TV shows", new List<string> { "Survivor", "The Bachelor", "Keeping Up with the Kardashians", "Big Brother", "The Amazing Race", "The Voice", "Love Island", "Hell's Kitchen", "Shark Tank" } },
            { "Celebrities", new List<string> { "Taylor Swift", "Leonardo DiCaprio", "Kim Kardashian", "Beyoncé", "Dwayne Johnson", "Rihanna", "Tom Holland", "Ariana Grande", "Chris Hemsworth" } },
            { "Tongue twisters", new List<string> { "Sally sells seashells by the seashore", "Peter Piper picked a peck of pickled peppers", "How much wood would a woodchuck chuck", "Betty Botter bought some butter", "Fuzzy Wuzzy was a bear", "Six slippery snails slid slowly seaward" } }
        };
        public static void StartGame()
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("            WHEEL OF FORTUNE GAME              ");
            Console.WriteLine("===============================================");
            Console.WriteLine("Welcome to the Wheel of Fortune game!");
            
            Console.Write("First thing's first! Please enter a username to continue: ");
            string username = Console.ReadLine();
            Console.WriteLine($"Welcome, {username}!");
            
            Console.Write("How many rounds would you like to play? (1-6): ");
            int rounds;
            while (!int.TryParse(Console.ReadLine(), out rounds) || rounds < 1 || rounds > 6)
            {
                Console.Write("Invalid input. Please enter a number between 1 and 6: ");
            }
            
            Console.Write($"You will be playing " + rounds + " rounds!\n");
            
            Console.Write("How many AI players would you like to play against? (1-3)\n");
            int numAIPlayers = int.Parse(Console.ReadLine());
            
            Console.Write($"You will be playing against " + numAIPlayers + " AI players!\n");
            
            // unless AI difficulty is random we can change this
            Console.Write("Now, please choose AI difficulty: ('1' = Easy, '2' = medium, or '3' = hard)\n");
            int difficultyLevel = int.Parse(Console.ReadLine());
            
            DisplayInstructions();
            
            string category = ChooseRandomCategory();
            string phrase = ChooseRandomPhrase(category);
            
            Console.WriteLine($"The chosen category is: {category}");
            Console.WriteLine($"Your phrase to guess is: {phrase}");
            
            Console.WriteLine("Press 'q' to quit.");
            while (Console.ReadKey(true).KeyChar != 'q')
            {
                Console.WriteLine("Press 'q' to exit or any other key to continue playing...");
            }
        }

        static void DisplayInstructions()
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("Here’s how to play:");
            Console.WriteLine();
            Console.WriteLine("1. A random category and phrase will be chosen.");
            Console.WriteLine("2. On your turn, spin the wheel to get money or go bankrupt.");
            Console.WriteLine("3. Guess a letter or type 'SOLVE!' to guess the full phrase.");
            Console.WriteLine("4. If correct, you earn money and continue your turn.");
            Console.WriteLine("5. If wrong, your turn ends, and the next player goes.");
            Console.WriteLine("6. Players with $0 at the end of a round must win the next to stay in.");
            Console.WriteLine("7. The player with the most money at the end wins!");
            Console.WriteLine("===============================================");
            Console.WriteLine("Press any key to start the game!");
            Console.ReadKey();
            Console.WriteLine();
        }
        static string ChooseRandomCategory()
        {
            Random random = new Random();
            var categoryList = new List<string>(CategoryPhrases.Keys);
            return categoryList[random.Next(categoryList.Count)];
        }

        static string ChooseRandomPhrase(string category)
        {
            Random random = new Random();
            List<string> phrases = CategoryPhrases[category];
            return phrases[random.Next(phrases.Count)];
        }
    }
}
