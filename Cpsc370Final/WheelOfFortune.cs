namespace Cpsc370Final;

class WheelOfFortune
{
    private static readonly Dictionary<string, List<string>> CategoryPhrases = new Dictionary<string, List<string>>
    {
        {
            "Social media apps",
            new List<string>
            {
                "Facebook", "Instagram", "Snapchat", "TikTok", "Twitter", "LinkedIn", "Pinterest", "Reddit", "WhatsApp"
            }
        },
        {
            "Fast food restaurants",
            new List<string>
            {
                "McDonald's", "Burger King", "KFC", "Taco Bell", "Wendy's", "Subway", "Chick-fil-A", "Domino's Pizza",
                "Popeyes"
            }
        },
        {
            "Reality TV shows",
            new List<string>
            {
                "Survivor", "The Bachelor", "Keeping Up with the Kardashians", "Big Brother", "The Amazing Race",
                "The Voice", "Love Island", "Hell's Kitchen", "Shark Tank"
            }
        },
        {
            "Celebrities",
            new List<string>
            {
                "Taylor Swift", "Leonardo DiCaprio", "Kim Kardashian", "Beyoncé", "Dwayne Johnson", "Rihanna",
                "Tom Holland", "Ariana Grande", "Chris Hemsworth"
            }
        },
        {
            "Tongue twisters",
            new List<string>
            {
                "Sally sells seashells by the seashore", "Peter Piper picked a peck of pickled peppers",
                "How much wood would a woodchuck chuck", "Betty Botter bought some butter", "Fuzzy Wuzzy was a bear",
                "Six slippery snails slid slowly seaward"
            }
        }
    };

    public static void StartGame()
    {
        DelayPrint("===============================================");
        DelayPrint("            WHEEL OF FORTUNE GAME              ");
        DelayPrint("===============================================");
        DelayPrint("Welcome to the Wheel of Fortune game!");

        DelayPrint("First thing's first! Please enter a username to continue: ");
        string username = Console.ReadLine();
        DelayPrint($"Welcome, {username}!");

        DelayPrint("How many rounds would you like to play? (1-6): ");
        int rounds;
        while (!int.TryParse(Console.ReadLine(), out rounds) || rounds < 1 || rounds > 6)
        {
            Console.Write("Invalid input. Please enter a number between 1 and 6: ");
        }

        DelayPrint($"You will be playing " + rounds + " rounds!\n");

        DelayPrint("How many AI players would you like to play against? (1-3)\n");
        int numAIPlayers = int.Parse(Console.ReadLine());

        Console.Write($"You will be playing against " + numAIPlayers + " AI players!\n");

        // unless AI difficulty is random we can change this
        DelayPrint("Now, please choose AI difficulty: ('1' = Easy, '2' = medium, or '3' = hard)");
        int difficultyLevel = int.Parse(Console.ReadLine());

        DisplayInstructions();

        string category = ChooseRandomCategory();
        string phrase = ChooseRandomPhrase(category);

        DelayPrint($"The chosen category is: {category}");
        DelayPrint($"Your phrase to guess is: {phrase}");

        DelayPrint("Press 'q' to quit.");
        while (Console.ReadKey(true).KeyChar != 'q')
        {
            DelayPrint("Press 'q' to exit or any other key to continue playing...");
        }
    }

    static void DisplayInstructions()
    {
        DelayPrint("===============================================");
        DelayPrint("Here’s how to play:");
        Console.WriteLine();
        DelayPrint("1. A random category and phrase will be chosen.");
        DelayPrint("2. On your turn, spin the wheel to get money or go bankrupt.");
        DelayPrint("3. Guess a letter or type 'SOLVE!' to guess the full phrase.");
        DelayPrint("4. If correct, you earn money and continue your turn.");
        DelayPrint("5. If wrong, your turn ends, and the next player goes.");
        DelayPrint("6. Players with $0 at the end of a round must win the next to stay in.");
        DelayPrint("7. The player with the most money at the end wins!");
        DelayPrint("===============================================");
        DelayPrint("Press any key to start the game!");
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

    public static void DelayPrint(string message)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(25);
        }

        Console.WriteLine();
    }
}