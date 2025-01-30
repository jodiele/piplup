namespace Cpsc370Final
{

	public class AIPlayers
	{
		// Class for AI players, which will have difficulty and name
		private string[] aiNames = { "Tanner", "Hannah", "Divi", "Jodie", "Ivan" };
		public string name { get; set; }
		private double difficulty = 100;
		private int money = 100;

		private void SetName()
		{
			this.name = aiNames[Random.Shared.Next(aiNames.Length)];
		}

		public int GetMoney()
		{
			return this.money;
		}

		public void SetMoney(int money)
		{
			this.money = money;
		}

		public AIPlayers(int multiplier)
		{
			SetName();
			// multiplier will vary depending on input that we receive, will be a scale
			// 1 = easy, 2 = medium, 3 = hard
			if (multiplier == 1)
			{
				difficulty *= .5;
			}
			else if (multiplier == 2)
			{
				difficulty *= .25;
			}
			else
			{
				difficulty *= .1;
			}

		}
	}
}