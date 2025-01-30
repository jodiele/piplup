namespace Cpsc370Final;

public class AIPlayers {
	// Class for AI players, which will have difficulty and name
	private string[] aiNames = { "Tanner", "Hannah", "Divi", "Jodie", "Ivan" };
	public string Name { get; set; }

	private void setName() {
		this.Name = aiNames[Random.Shared.Next(aiNames.Length)];
	}
}