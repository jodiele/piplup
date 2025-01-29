namespace Cpsc370Final;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
            Console.WriteLine("Usage: Cpsc370Final <arguments>");
        
        // you can delete this if/when you like
        ShowArguments(args);
        
        Player user = new Player();
        
        // Guessing this will be where initializing the game will go
        // as a placeholder putting down the String prompt of what the game is,
        // how to play
        Console.WriteLine("Welcome to our game [GAME NAME]!");
        Console.WriteLine("What is your name?");
        // will be passed back to user class 
        String userName = Console.ReadLine();
        // just setting username :) 
        user.Username = userName;
        
        Console.WriteLine("This game is much like Wheel of Fortune, that said, how many rounds will you like to play?");
        // thinking we could have a rounds class here which will be our actual game flow, will run until the rounds are over
        int rounds = Convert.ToInt32(Console.ReadLine()); 
        
    }

    // this is just an example of how to get the command
    // line arguments so you can use them
    private static void ShowArguments(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine("  Argument " + i +": " + args[i]);
        }
    }
}