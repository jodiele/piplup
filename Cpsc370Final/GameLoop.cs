namespace Cpsc370Final;

public class GameLoop {
    private int roundsCount;
    private int aiAmount;

    public void GameplayLoop() {
        //amount of rounds
        for (int currentRound = 0; currentRound < roundsCount; currentRound++) {
            //logic for player guess

            //ai guesses
            for (int aiTurn = 0; aiTurn < aiAmount; aiAmount++) {
                //logic for each AI to play
            }
        }
    }

    public void SetRoundsCount(int rounds) {
        roundsCount = rounds;
    }

    public void GetUserGuess(string currentAnswer)
    {
        Console.Write("Please enter a letter or type 'SOLVE' to guess the entire phrase: ");
        string userInput = Console.ReadLine().Trim();

        bool isCorrectAnswer = false;
        while (isCorrectAnswer == false)
        {
            if (userInput.Equals("SOLVE", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Please enter your guess for the entire phrase: ");
                string userGuess = Console.ReadLine().Trim();

                if (userGuess.Equals(currentAnswer, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Congratulations! Your guess is correct.");
                    isCorrectAnswer = true;
                    // TODO: ADD CODE TO GO TO NEXT PLAYER TURN
                }
                else
                {
                    Console.WriteLine("Sorry, that's not correct.");
                    // TODO: ADD CODE TO TAKE AWAY USER'S MONEY AND GO TO NEXT PLAYER TURN
                    isCorrectAnswer = false;
                }
            }
            else if (userInput.Length == 1)
            {
                char guessedLetter = userInput[0];
                if (currentAnswer.IndexOf(guessedLetter, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine($"You guessed the letter: {guessedLetter}");
                    // TODO: ADD CODE TO GO TO THE NEXT PLAYER TURN
                    isCorrectAnswer = true;
                }
                else
                {
                    Console.WriteLine("Sorry, that letter is not in the phrase.");
                    // TODO: ADD CODE TO TAKE AWAY USER'S MONEY AND GO TO NEXT PLAYER TURN
                    isCorrectAnswer = false;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter one letter or type 'SOLVE'.");
                Console.Write("Please enter a letter or type 'SOLVE' to guess the entire phrase: ");
                userInput = Console.ReadLine().Trim();
            }
        }
    }
    
    // functionality for choosing random category and phrase in wheeloffortune class
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
    
    public static string ChooseRandomCategory()
    {
        Random random = new Random();
        var categoryList = new List<string>(CategoryPhrases.Keys);
        return categoryList[random.Next(categoryList.Count)];
    }

    public static string ChooseRandomPhrase(string category)
    {
        Random random = new Random();
        List<string> phrases = CategoryPhrases[category];
        return phrases[random.Next(phrases.Count)];
    }
    
    public void SetAiAmount(int amount, List<int> aiDifficulties) {
        CreateAiPlayers(amount, aiDifficulties);
    }
    

    private void CreateAiPlayers(int playerAmount, List<int> aiDifficulties) { 
        List<AIPlayers> aiPlayers = new List<AIPlayers>();
        for (int i = 0; i < playerAmount; i++) {
            // create a new AI player with a random difficulty
            //TODO: take user input and set that to the multiplier per input
            aiPlayers.Add(new AIPlayers(aiDifficulties[i]));
        }
    }
}