using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GuessTheNumber
{
    class Program
    {
        static void GameStarting()
        {
            Console.WriteLine("Hello!\nLet's start the game\nGame rules:\n1.Computer makes a number from 0 to 100(inclusive)\n2.You have to guess what number the computer thought\n3.If you guess right, you win, otherwise you get a hint");
            Console.WriteLine("Good luck!");
        }

        static int GetNumber()
        {
            Console.WriteLine("Enter the number from 0 to 100(inclusive):");
            string number = Console.ReadLine();
            int result;
            bool isConvert = int.TryParse(number, out result);
            bool isError = !isConvert || result > 100 || result < 0;
            while (isError)
            {
                Console.WriteLine("Number input error,try again!");
                number = Console.ReadLine();
                isConvert = int.TryParse(number, out result);
                isError = !isConvert || result > 100 || result < 0;
            }
            return result;
        }

        static void Main(string[] args)
        {
            GuessGame game = new GuessGame();
            bool stopButton = false;
            GameStarting();
            while (!stopButton)
            {
                int value = GetNumber();
                if (game.AreYouWin(value))
                {
                    Console.WriteLine("Congratulations!!!You are win!");
                    Console.WriteLine("Press 1 - to play again,0 - to exit");
                    bool isConvert = int.TryParse(Console.ReadLine(), out value);
                    bool isError = !isConvert || value > 1 || value < 0;
                    while (isError)
                    {
                        Console.WriteLine("Input error,try again.Press 1 - to play again,0 - to exit");
                        isConvert = int.TryParse(Console.ReadLine(), out value);
                        isError = !isConvert || value > 1 || value < 0;
                    }
                    if (value == 0)
                    {
                        stopButton = true;
                    }
                }
                else
                {
                    Console.Clear();
                    GameStarting();
                    Console.WriteLine("********** Game Zone ************");
                    Console.WriteLine(game.GetHint(value));
                }

            }
        }

    }

}

