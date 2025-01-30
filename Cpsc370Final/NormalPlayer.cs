namespace Cpsc370Final;

public class NormalPlayer {
	private int money;
	private char[] guessedLetters;
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

	public bool Guess(string userInput, string currentAnswer) {
		bool endTurn = false;
		bool isCorrectAnswer = false;
		while (endTurn == false) {
			if (userInput.Equals("SOLVE", StringComparison.OrdinalIgnoreCase)) {
				Console.Write("Enter your guess for the entire phrase: ");
				string userGuess = Console.ReadLine().Trim();

				if (userGuess.Equals(currentAnswer, StringComparison.OrdinalIgnoreCase)) {
					Console.WriteLine("Yay! Your guess is correct.");
					isCorrectAnswer = true;
					endTurn = true;
				}
				else {
					Console.WriteLine("That's not correct.");
					SetMoney(0);
					isCorrectAnswer = false;
					endTurn = true;
				}
			}
			else if (userInput.Length == 1) {
				char guessedLetter = userInput[0];
				if (currentAnswer.IndexOf(guessedLetter, StringComparison.OrdinalIgnoreCase) >= 0) {
					guessedLetters = guessedLetters.Append(guessedLetter).ToArray();
					Console.WriteLine("You guessed a correct letter!");
					Console.WriteLine("===============================================");
					DisplayGuessedWord(currentAnswer);
					Console.WriteLine("===============================================");
					isCorrectAnswer = false;
					Console.Write("Enter another letter to guess or type 'SOLVE' to guess the entire phrase: ");
					userInput = Console.ReadLine().Trim();
				}
				else {
					Console.WriteLine("Sorry, that letter is not in the phrase.");
					isCorrectAnswer = false;
					endTurn = true;
				}
			}
			else {
				Console.WriteLine("Invalid input. Please enter one letter or type 'SOLVE'.");
				Console.Write("Please enter a letter or type 'SOLVE' to guess the entire phrase: ");
				userInput = Console.ReadLine().Trim();
			}
		}
		return isCorrectAnswer;
	}
	
	private void DisplayGuessedWord(string currentAnswer) {
		for (int i = 0; i < currentAnswer.Length; i++) {
			if (currentAnswer[i] == ' ') {
				Console.Write(" ");
			}
			else if (guessedLetters.Contains(currentAnswer[i])) {
			    Console.Write(currentAnswer[i]);				
			}
			else {
				Console.Write("_");
			}
		}
	}
}