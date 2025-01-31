using System;

namespace Cpsc370Final {
    class Program {
        static void Main(string[] args) {
            if (args.Length < 1)
                Console.WriteLine("Usage: Cpsc370Final <arguments>");

            WheelOfFortune game = new WheelOfFortune();
            game.StartGame();
        }

        private static void ShowArguments(string[] args) {
            for (int i = 0; i < args.Length; i++) {
                Console.WriteLine("  Argument " + i + ": " + args[i]);
            }
        }
    }
}