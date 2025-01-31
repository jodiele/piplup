namespace Cpsc370Final
{
    public class NormalPlayer
    {
        private int money;
        private List<char> guessedLetters;  // Change from char[] to List<char>

        public NormalPlayer(int initialMoney = 100)
        {
            money = initialMoney;
            guessedLetters = new List<char>();  // Initialize as an empty list
        }

        public int GetMoney()
        {
            return money;
        }

        public void SetMoney(int money)
        {
            this.money = money;
            Console.WriteLine($"Your total money is now ${money}.");
        }

        public void AddMoney(int amount)
        {
            if (amount > 0)
                money += amount;
            Console.WriteLine($"You earned ${amount}! Your total money is now ${money}.");
        }

        public bool Guess(string userInput, string currentAnswer)
        {
            bool endTurn = false;
            bool isCorrectAnswer = false;
            while (endTurn == false)
            {
                if (userInput.Equals("SOLVE", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Enter your guess for the entire phrase: ");
                    string userGuess = Console.ReadLine().Trim();

                    if (userGuess.Equals(currentAnswer, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Yay! Your guess is correct.");
                        isCorrectAnswer = true;
                        endTurn = true;
                        guessedLetters.Clear();
                    }
                    else
                    {
                        isCorrectAnswer = false;
                        endTurn = true;
                    }
                }
                else if (userInput.Length == 1)
                {
                    char guessedLetter = userInput[0];
                    if (currentAnswer.IndexOf(guessedLetter, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        guessedLetters.Add(guessedLetter);  // Use Add() to append the letter
                        Console.WriteLine("You guessed a correct letter!");
                        Console.WriteLine("===============================================");
                        DisplayGuessedWord(currentAnswer);
                        Console.WriteLine();
                        Console.WriteLine("===============================================");
                        if (DisplayGuessedWord(currentAnswer).Equals(currentAnswer))
                        {
                            Console.WriteLine("Congratulations! You guessed the entire phrase.");
                            isCorrectAnswer = true;
                            endTurn = true;
                        }
                        else
                        {
                            isCorrectAnswer = false;
                            Console.Write("Enter another letter to guess or type 'SOLVE' to guess the entire phrase: ");
                            userInput = Console.ReadLine().Trim();
                            endTurn = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that letter is not in the phrase.");
                        isCorrectAnswer = false;
                        endTurn = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter one letter or type 'SOLVE'.");
                    Console.Write("Please enter a letter or type 'SOLVE' to guess the entire phrase: ");
                    userInput = Console.ReadLine().Trim();
                }
            }

            return isCorrectAnswer;
        }

        private string DisplayGuessedWord(string currentAnswer)
        {
            string guessedWord = "";
            for (int i = 0; i < currentAnswer.Length; i++)
            {
                if (currentAnswer[i] == ' ')
                {
                    guessedWord += " ";
                }
                else if (guessedLetters.Contains(currentAnswer[i]))
                {
                    guessedWord += currentAnswer[i];
                }
                else
                {
                    guessedWord += "_";
                }
            }
            Console.WriteLine(guessedWord);
            return guessedWord;
        }
    }
}
