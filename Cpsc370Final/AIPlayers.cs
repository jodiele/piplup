namespace Cpsc370Final;

public class AIPlayers {
	// Class for AI players, which will have difficulty and name
	private string[] aiNames = { "Tanner", "Hannah", "Divi", "Jodie", "Ivan" };
	public string name { get; set; }
	private int difficulty = 100;
	private int money;

	private void SetName() {
		this.name = aiNames[Random.Shared.Next(aiNames.Length)];
	}

	private int GetMoney() {
		return this.money;
	}

	public void SetMoney(int money) {
		this.money = money;
	}

	public AIPlayers(int multiplier) { 
		SetName();
		// just multiply the difficulty by the multiplier, which will be set by the users when they set the ai difficulties
		difficulty *= multiplier;
	}
	
	

}