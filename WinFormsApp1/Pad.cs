using System;
using System.Collections.Generic;
using System.Text;

namespace PongGame
{
    class Pad
    {
        public int xPos;
        public int yPos;
        //public int xVel;
        public int yVel;
        public int height;
        public int width;
        public Pad(int xP, int yP, int yV, int h, int w)
        {
            xPos = xP;
            yPos = yP;
            yVel = yV;
            height = h;
            width = w;
        }
        public void draw(ConsoleColor color)
        {
            Console.BackgroundColor = color;
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(xPos, yPos + i);
                for (int j = 0; j < width; j++)
                {
                    Console.Write(" ");
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void moveUp()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.SetCursorPosition(xPos + j, yPos + i);
                    Console.Write(" ");
                }
            }
            if (yPos < yVel)
            {
                /*for (int i = 20; i < 20 + yPos; i++)
                {
                    for(int j = 0; j < width; j++)
                    {
                        Console.SetCursorPosition(xPos + j, yPos + i);
                        Console.Write(" ");
                    }
                }*/
                yPos = 0; 
            }
            else if (yPos > 0)
            {
                /*for (int i = 0; i < yVel; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Console.SetCursorPosition(xPos+j,yPos + height - yVel + i);
                        Console.Write(" ");
                    }
                }*/
                yPos -= yVel;
            }
        }
        public void moveDown()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.SetCursorPosition(xPos + j, yPos + i);
                    Console.Write(" ");
                }
            }
            if (yPos > Program.canvasHeight-height-yVel-1)
            {
                yPos = Program.canvasHeight-height-1;
            }
            else if (yPos < 79)
            {
                yPos += yVel;
            }
            
        }
    }

}
