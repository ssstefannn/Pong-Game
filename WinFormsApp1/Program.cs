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

        static void Main()
        {
            Console.CursorVisible = false;
            Console.Title = "Pong Game";
            Console.SetWindowSize(250, 100);
            Square square = new Square(30, 30, 3, 1, 5);
            Pad leftPad = new Pad(0, 45, 5, 20, 5);
            Pad rightPad = new Pad(245, 45, 5, 20, 5);
            while (true)
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
                leftPad.draw();
                rightPad.draw();
                Thread.Sleep(17);
                clearConsole(square);
            }
        }



    }
}



