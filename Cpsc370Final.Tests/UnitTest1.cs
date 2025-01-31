namespace Cpsc370Final.Tests;

public class UnitTest1
{
    [Fact]
    public void CheckUserMoneyAmount()
    {
        NormalPlayer player = new NormalPlayer();
        Assert.Equal(2000, player.GetMoney());
    }
    
    [Fact]
    public void CheckUserMoneyAmountAfterAdding()
    {
        NormalPlayer player = new NormalPlayer();
        player.AddMoney(1000);
        Assert.Equal(3000, player.GetMoney());
    }
    
    [Fact]
    public void CheckAIMoneyAmount()
    {
        AIPlayers ai = new AIPlayers(1);
        ai.SetMoney(2000);
        Assert.Equal(2000, ai.GetMoney());
    }

    [Fact]
    public void CheckGameLoopRoundCount() {
        GameLoop gameLoop = new GameLoop("test");
        gameLoop.SetRoundsCount(2);
        Assert.Equal(2, gameLoop.GetRoundCount());
    }
}