namespace Cpsc370Final
{

    public class GameLoop
    {
        private int roundsCount;
        private int aiAmount;
        private String correctAnswer;
        private NormalPlayer player;

        public void GameplayLoop()
        {
            player = new NormalPlayer();
            //amount of rounds
            for (int currentRound = 0; currentRound < roundsCount; currentRound++)
            {
                String category = ChooseRandomCategory();
                Console.WriteLine($"The chosen category is: {category}");
                correctAnswer = ChooseRandomPhrase(category);
                Console.WriteLine($"Round {currentRound + 1} begins!");
                ShowUnsolvedWord();

                //the user and AIs guess until correct
                while (true)
                {
                    //user guesses
                    Console.Write("Please enter a letter or type 'SOLVE' to guess the entire phrase: ");
                    string userInput = Console.ReadLine().Trim();
                    bool guessed = player.Guess(userInput, correctAnswer);
                    if (guessed)
                    {
                        break; // if the user guesses the correct answer, goes to next round
                    }

                    for (int aiTurn = 0; aiTurn < aiAmount; aiAmount++)
                    {
                        //logic for each AI to play
                    }
                }
            }
        }

        public void SetRoundsCount(int rounds)
        {
            roundsCount = rounds;
        }

        // functionality for choosing random category and phrase in wheeloffortune class
        private static readonly Dictionary<string, List<string>> CategoryPhrases = new Dictionary<string, List<string>>
        {
            {
                "Social media apps",
                new List<string>
                {
                    "Facebook", "Instagram", "Snapchat", "TikTok", "Twitter", "LinkedIn", "Pinterest", "Reddit",
                    "WhatsApp"
                }
            },
            {
                "Fast food restaurants",
                new List<string>
                {
                    "McDonald's", "Burger King", "KFC", "Taco Bell", "Wendy's", "Subway", "Chick-fil-A",
                    "Domino's Pizza",
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
                    "How much wood would a woodchuck chuck", "Betty Botter bought some butter",
                    "Fuzzy Wuzzy was a bear",
                    "Six slippery snails slid slowly seaward"
                }
            }
        };

        private void ShowUnsolvedWord()
        {
            for (int currChar = 0; currChar < correctAnswer.Length; currChar++)
            {
                if (correctAnswer[currChar] == ' ')
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("_");
                }
            }
            Console.WriteLine();
        }

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

        public void SetAiAmount(int amount, List<int> aiDifficulties)
        {
            CreateAiPlayers(amount, aiDifficulties);
        }


        private void CreateAiPlayers(int playerAmount, List<int> aiDifficulties)
        {
            List<AIPlayers> aiPlayers = new List<AIPlayers>();
            for (int i = 0; i < playerAmount; i++)
            {
                // create a new AI player with a difficulty dictated by user
                aiPlayers.Add(new AIPlayers(aiDifficulties[i]));
            }
        }
    }
}