using System.Globalization;

namespace Cpsc370Final
{

    public class GameLoop
    {
        private int roundsCount;
        private int aiAmount;
        private String correctAnswer;
        private NormalPlayer player;
        private List<AIPlayers> aiPlayers = new List<AIPlayers>();
        private String category;

        public void GameplayLoop()
        {
            player = new NormalPlayer();
            
            //amount of rounds
            for (int currentRound = 0; currentRound < roundsCount; currentRound++)
            {
                category = ChooseRandomCategory();
                Console.WriteLine($"The chosen category is: {category}");
                correctAnswer = ChooseRandomPhrase(category);
                Console.WriteLine($"Round {currentRound + 1} begins!");
                int wheelValue = SpinWheel(); //spin the wheel to determine money value
                ShowUnsolvedWord();

                //the user and AIs guess until correct
                while (true)
                {
                    //user guesses
                    Console.Write("Please enter a letter or type 'SOLVE' to guess the entire phrase: ");
                    string userInput = Console.ReadLine().Trim();
                    bool playerGuessed = player.Guess(userInput, correctAnswer);
                    if (playerGuessed)
                    {
                        player.AddMoney(wheelValue);
                        break; // if the user guesses the correct answer, goes to next round
                    }
                    else {
                        player.SetMoney(player.GetMoney() - wheelValue);
                        for (int aiTurn = 0; aiTurn < aiPlayers.Count; aiTurn++)
                        {
                            //logic for each AI to play
                            Console.WriteLine(aiPlayers[aiTurn].GetName() + " Guessed: " + aiPlayers[aiTurn].Guess(correctAnswer, category));
                        }
                    }
                }

                if (player.GetMoney() < 0)
                {
                    Console.Write("You are out of money!");
                    PrintEndGame(aiPlayers[0].GetName());
                    break;
                }
                
                if (aiAmount == 0)
                {
                    PrintEndGame("AI");
                    break;
                }
            }
        }

        public void SetRoundsCount(int rounds)
        {
            roundsCount = rounds;
        }

        // functionality for choosing random category and phrase in wheeloffortune class
        public static readonly Dictionary<string, List<string>> CategoryPhrases = new Dictionary<string, List<string>>
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
            Console.Write("The word to solve is: ");
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

        public string GetCategory() {
            return this.category;
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
            for (int i = 0; i < playerAmount; i++)
            {
                // create a new AI player with a difficulty dictated by user
                aiPlayers.Add(new AIPlayers(aiDifficulties[i]));
            }
        }
        
        private int SpinWheel()
        {
            Console.Write("Type 'SPIN' to spin the wheel: ");
            string spinInput = Console.ReadLine();
            while (!spinInput.Equals("SPIN", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid input. Please type 'SPIN' to spin the wheel: ");
                spinInput = Console.ReadLine();
            }
            Random random = new Random();
            int wheelValue = random.Next(1, 21) * 100;
            Console.WriteLine($"You spun ${wheelValue}! Solve the word/phrase to keep the money.");
            return wheelValue;
        }
        
        private void PrintEndGame(string winner)
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("                   GAME OVER                   ");
            Console.WriteLine("===============================================");
            Console.WriteLine("===============================================");
            if (winner.Equals("player"))
            {
                Console.WriteLine("You win!! You ended with $" + player.GetMoney());
            }
            else
            {
                Console.WriteLine($"You loose. The winner is {winner}! You ended with ${player.GetMoney()}");
            }
        }
    }
}