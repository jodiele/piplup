namespace Cpsc370Final;

public class AIPlayers {
	// Class for AI players, which will have difficulty and name
	private string[] aiNames = { "Tanner", "Hannah", "Divi", "Jodie", "Ivan" };
	public string name { get; set; }
	private int difficulty = 100;

	private void setName() {
		this.name = aiNames[Random.Shared.Next(aiNames.Length)];
	}

	public AIPlayers(int multiplier) {
		setName();
		// just multiply the difficulty by the multiplier, which will be set by the users when they set the ai difficulties
		difficulty *= multiplier;
	}
	
	

}