using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace PongGame
{
    class Program
    {
        public static int canvasHeight=100;
        public static int canvasWidth=300;
        public static int playerOneScore;
        public static int playerTwoScore;
        public static bool GameInProgress;
        static void clearConsole(Square obj)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < obj.size; i++)
            {
                for (int j = 0; j < obj.size; j++)
                {
                    Console.SetCursorPosition(obj.xPos + i, obj.yPos + j);
                    Console.Write(" ");
                }

            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void drawScoreBoard()
        {
            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 250; j < 300; j++)
                {
                    if (j < 253 || j > 297 || i < 3 || i > 97)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write("@");
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void incrementPlayerOne()
        {
            if (playerOneScore < 10)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                int start = 3 + (playerOneScore - 1) * 9;
                int end = start + 9;
                //end=97
                for (int i = start; i < end; i++)
                {
                    for (int j = 253; j < 275; j++)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(" ");
                    }
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                for (int i = 3; i < 98; i++)
                {
                    for (int j = 253; j < 275; j++)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(" ");
                    }
                }
                GameInProgress = false;
            }
        }
        public static void incrementPlayerTwo()
        {
            if (playerTwoScore < 10)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                int start = 3 + (playerTwoScore - 1) * 9;
                int end = start + 9;
                //end=97
                for (int i = start; i < end; i++)
                {
                    for (int j = 275; j < 298; j++)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(" ");
                    }
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                for (int i = 3; i < 98; i++)
                {
                    for (int j = 275; j < 298; j++)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(" ");
                    }
                }
                GameInProgress = false;
            }
        }
        static void Main()
        {
            Console.CursorVisible = false;
            Console.Title = "Pong Game";
            Console.SetWindowSize(300, 100);
            Square square = new Square(125, 30, 3, 1, 5);
            Pad leftPad = new Pad(0, 45, 5, 20, 5);
            Pad rightPad = new Pad(245, 45, 5, 20, 5);
            Middle middle = new Middle(125, 0, 5, 5);
            bool isRight = true;
            middle.draw();
            drawScoreBoard();
            GameInProgress = true;
            while (GameInProgress)
            {
                if (Keyboard.IsKeyDown(Keys.W))
                    leftPad.moveUp();
                if (Keyboard.IsKeyDown(Keys.S))
                    leftPad.moveDown();
                if (Keyboard.IsKeyDown(Keys.Up))
                    rightPad.moveUp();
                if (Keyboard.IsKeyDown(Keys.Down))
                    rightPad.moveDown();
                square.update(leftPad, rightPad);
                square.draw();
                leftPad.draw(ConsoleColor.Blue);
                rightPad.draw(ConsoleColor.Red);
                if((isRight && square.xPos+square.size<125)||(!isRight && square.xPos>128))
                {
                    middle.draw();
                    isRight = !isRight;
                }
                Thread.Sleep(17);
                clearConsole(square);
            }
            Thread.Sleep(5000);
        }



    }
}



