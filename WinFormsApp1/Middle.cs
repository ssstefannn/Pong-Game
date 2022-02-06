using System;
using System.Collections.Generic;
using System.Text;

namespace PongGame
{
    class Middle
    {
        public int xPos;
        public int yPos;
        public int gapHeight;
        public int lineHeight;
        public Middle(int xP,int yP,int gH,int lH)
        {
            xPos = xP;
            yPos = yP;
            gapHeight = gH;
            lineHeight = lH;
        }

        public void draw()
        {
            Console.BackgroundColor = ConsoleColor.White;
            int counter = 0;
            for(int i = 0; i < Program.canvasHeight; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(xPos + j, yPos + i);
                    Console.Write(" ");
                }

                counter++;
                if (counter == lineHeight)
                {
                    i += gapHeight;
                    counter = 0;
                    i--; //cuz of i++ in for loop
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}
