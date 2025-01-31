namespace Cpsc370Final
{

    class WheelOfFortune
    {
        

        public void StartGame()
        {
            DelayPrint("===============================================");
            DelayPrint("            WHEEL OF FORTUNE GAME              ");
            DelayPrint("===============================================");
            DelayPrint("Welcome to the Wheel of Fortune game!");

            DelayPrint("First thing's first! Please enter a username to continue: ");
            string username = Console.ReadLine();
            GameLoop gameLoop = new GameLoop(username);
            DelayPrint($"Welcome, {username}!");

            DelayPrint("How many rounds would you like to play? (1-6): ");
            int rounds;
            while (!int.TryParse(Console.ReadLine(), out rounds) || rounds < 1 || rounds > 6)
            {
                Console.Write("Invalid input. Please enter a number between 1 and 6: ");
            }

            gameLoop.SetRoundsCount(rounds);

            DelayPrint($"You will be playing " + rounds + " rounds!\n");

            DelayPrint("How many AI players would you like to play against? (1-3)\n");
            int limitAIPlayers;
            while (!int.TryParse(Console.ReadLine(), out limitAIPlayers) || limitAIPlayers < 1 || limitAIPlayers > 3)
            {
                Console.Write("Invalid input. Please enter a number between 1 and 3: ");
            }
            int numAIPlayers = limitAIPlayers;


            DelayPrint($"You will be playing against " + numAIPlayers + " AI players!\n");
            
            // list to hold the difficulties for the AI
            List<int> aiDifficulties = new List<int>(3);
            
            for (int i = 0; i < numAIPlayers; i++)
            {
                DelayPrint($"Please enter the difficulty for AI player {i + 1} (1 = easy, 2 = medium, 3 = hard): ");
                int difficulty;
                while (!int.TryParse(Console.ReadLine(), out difficulty) || difficulty < 1 || difficulty > 3)
                {
                    Console.Write("Invalid input. Please enter a number between 1 and 3: ");
                }
                aiDifficulties.Add(difficulty);
            }

            gameLoop.SetAiAmount(numAIPlayers, aiDifficulties);

            DisplayInstructions();

            gameLoop.GameplayLoop();
        }

        static void DisplayInstructions()
        {
            DelayPrint("===============================================");
            DelayPrint("Here’s how to play:");
            Console.WriteLine();
            DelayPrint("1. A random category and phrase will be chosen.");
            DelayPrint("2. On your turn, spin the wheel to get money or go bankrupt.");
            DelayPrint("3. Guess a letter or type 'SOLVE!' to guess the full phrase.");
            DelayPrint("4. If correct, you earn money and continue your turn.");
            DelayPrint("5. If wrong, your turn ends, and the next player goes.");
            DelayPrint("6. Players with $0 at the end of a round must win the next to stay in.");
            DelayPrint("7. The player with the most money at the end wins!");
            DelayPrint("===============================================");
            DelayPrint("Press any key to start the game!");
            Console.ReadKey();
            Console.WriteLine();
        }

        public static void DelayPrint(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }

            Console.WriteLine();
        }
    }
}