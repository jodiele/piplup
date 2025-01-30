namespace Cpsc370Final;

public class NormalPlayer {
	private int money;

	public NormalPlayer(int initialMoney = 100) {
		money = initialMoney;
	}

	public int GetMoney() {
		return money;
	}

	public void SetMoney(int money) {
		this.money = money;
	}

	public void AddMoney(int amount) {
		if (amount > 0)
			money += amount;
	}

	public void Guess(string userInput, string currentAnswer) {
		bool isCorrectAnswer = false;
		while (isCorrectAnswer == false) {
			if (userInput.Equals("SOLVE", StringComparison.OrdinalIgnoreCase)) {
				Console.Write("Enter your guess for the entire phrase: ");
				string userGuess = Console.ReadLine().Trim();

				if (userGuess.Equals(currentAnswer, StringComparison.OrdinalIgnoreCase)) {
					Console.WriteLine("Congratulations! Your guess is correct.");
					isCorrectAnswer = true;
					// TODO: ADD CODE TO GO TO NEXT PLAYER TURN
				}
				else {
					Console.WriteLine("Sorry, that's not correct.");
					// TODO: ADD CODE TO TAKE AWAY USER'S MONEY AND GO TO NEXT PLAYER TURN
					isCorrectAnswer = false;
				}
			}
			else if (userInput.Length == 1) {
				char guessedLetter = userInput[0];
				if (currentAnswer.IndexOf(guessedLetter, StringComparison.OrdinalIgnoreCase) >= 0) {
					Console.WriteLine($"You guessed the letter: {guessedLetter}");
					isCorrectAnswer = false;
					Console.Write("Enter another letter to guess or type 'SOLVE' to guess the entire phrase: ");
					userInput = Console.ReadLine().Trim();
				}
				else {
					Console.WriteLine("Sorry, that letter is not in the phrase.");
					// TODO: ADD CODE TO TAKE AWAY USER'S MONEY AND GO TO NEXT PLAYER TURN
					isCorrectAnswer = false;
				}
			}
			else {
				Console.WriteLine("Invalid input. Please enter one letter or type 'SOLVE'.");
				Console.Write("Please enter a letter or type 'SOLVE' to guess the entire phrase: ");
				userInput = Console.ReadLine().Trim();
			}
		}
	}
}