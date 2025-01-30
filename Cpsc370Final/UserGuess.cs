namespace Cpsc370Final;

public class UserGuess
{
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
}