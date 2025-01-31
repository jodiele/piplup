namespace Cpsc370Final
{

	public class AIPlayers
	{
		// Class for AI players, which will have difficulty and name
		private string[] aiNames = { "Tanner", "Hannah", "Divi", "Jodie", "Ivan" };
		public string name { get; set; }
		private string difficulty;
		private int money = 100;
		

		public AIPlayers(int difficultyDecision)
		{
			SetName();
			// multiplier will vary depending on input that we receive, will be a scale
			// 1 = easy, 2 = medium, 3 = hard
			if (difficultyDecision == 1)
			{
				difficulty = "easy";
			}
			else if (difficultyDecision == 2)
			{
				difficulty = "medium";
			}
			else
			{
				difficulty = "hard";
			}
		}

		public string Guess(string correctAnswer, string currentCategory) {
			int guessPercentage = Random.Shared.Next(1, 101);
			// deciding upon the difficulty of the AI, we will either choose between a letter and a phrase
			if (difficulty == "easy") {
				// guess percentage is going to be lower, compared to the other difficulties
				if (guessPercentage <= 2) { // these are 1/50 odds
					// choosing between guessing a word or a character
					int wordOrChar = Random.Shared.Next(1, 11);
					if (wordOrChar <= 9) { // 9 in 10 chance that the ai will guess a letter
						// guessing a letter
						char guessedLetter = (char)Random.Shared.Next(correctAnswer.Length);
						return guessedLetter.ToString();
					}
					else {
						// guessing a word, we take the current category being played in the game loop
						// and then choose a random phrase from the category
						Random.Shared.Next(GameLoop.CategoryPhrases[currentCategory].Count);
					}
				}
				else {
					return "idk lol"; // means ai player doesn't know what to guess
				}
			} else if (difficulty == "medium") {
				if (guessPercentage <= 4) { // these are 1/25 odds
					// choosing between guessing a word or a character
					int wordOrChar = Random.Shared.Next(1, 11);
					if (wordOrChar <= 9) { // 9 in 10 chance that the ai will guess a letter
						// guessing a letter
						char guessedLetter = (char)Random.Shared.Next(correctAnswer.Length);
						return guessedLetter.ToString();
					}
					else {
						// guessing a word, we take the current category being played in the game loop
						// and then choose a random phrase from the category
						Random.Shared.Next(GameLoop.CategoryPhrases[currentCategory].Count);
					}
				}
				else {
					return "bruh what"; // means ai player doesn't know what to guess
				}
			} else { // difficulty selected is the hardest
				if (guessPercentage <= 10) { // 1 in 10 odds
					int wordOrChar = Random.Shared.Next(1, 11);
					if (wordOrChar <= 9) { // 9 in 10 chance that the ai will guess a letter
						// guessing a letter
						char guessedLetter = (char)Random.Shared.Next(correctAnswer.Length);
						return guessedLetter.ToString();
					}
					else {
						// guessing a word, we take the current category being played in the game loop
						// and then choose a random phrase from the category
						Random.Shared.Next(GameLoop.CategoryPhrases[currentCategory].Count);
					}
				}
				else {
					return "whar"; // means ai player doesn't know what to guess
				}
			}
			return "??";
		}
		
		private void SetName()
		{
			this.name = aiNames[Random.Shared.Next(aiNames.Length)];
		}
		
		public string GetName()
		{
			return this.name;
		}

		public int GetMoney()
		{
			return this.money;
		}

		public void SetMoney(int money)
		{
			this.money = money;
		}
	}
}