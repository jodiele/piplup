namespace Cpsc370Final;

public class NormalPlayer {
	private int money;

	public NormalPlayer(int initialMoney = 100)
	{
		money = initialMoney;
	}

	public int GetMoney() {
		return money;
	}

	public void SetMoney(int money) {
		this.money = money;
	}

	public void AddMoney(int amount)
	{
		if (amount > 0)
			money += amount;
	}
	

}