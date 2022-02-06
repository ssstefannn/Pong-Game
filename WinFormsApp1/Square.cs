using System;

namespace PongGame
{
    class Square
    {
        public int xPos;
        public int yPos;
        public int xVel;
        public int yVel;
        public int size;
        public bool turn=true;
        public Square(int xP, int yP, int xV, int yV, int s)
        {
            xPos = xP;
            yPos = yP;
            xVel = xV;
            yVel = yV;
            size = s;

        }
        public void draw()
        {
            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    try
                    {
                        Console.SetCursorPosition(xPos + j, yPos + i);
                        Console.Write(" ");
                    }
                    catch (Exception e)
                    {
                        Console.Write("Error!");
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public bool collidesWith(Pad pad)
        {
            int squareT = yPos;
            int squareB = yPos + size - 1;
            int padT = pad.yPos;
            int padB = pad.yPos + pad.height - 1;

            int squareL = xPos;
            int squareR = xPos + size - 1;
            int padL = pad.xPos;
            int padR = pad.xPos + pad.width - 1;

            return (squareR >= padL) && (padR >= squareL) && (squareB >= padT) && (padB >= squareT); 
        }
        public void update(Pad leftPad, Pad rightPad)
        {
            xPos += xVel;
            yPos += yVel;
            handleCollisions(leftPad, rightPad);
        }
        public void handleCollisions(Pad leftPad,Pad rightPad)
        {
            if (collidesWith(leftPad))
            {
                handleCollision(leftPad);
            }
            else if (collidesWith(rightPad))
            {
                handleCollision(rightPad);
            }
            //bounce off top and bottom walls (2)
            else if (xPos <= 0 || xPos + size - 1 >= 249)
            {
                if (xPos <= 0)
                {
                    Program.playerTwoScore++;
                    Program.incrementPlayerTwo();
                }
                else
                {
                    Program.playerOneScore++;
                    Program.incrementPlayerOne();
                }
                resetBall();
            }
            if (yPos <= 0 || yPos + size - 1 >= 99)
            {
                if (yPos < 0)
                    yPos = 0;
                else if (yPos + size - 1 > 99)
                    yPos = 95;
                yVel *= -1;
            }
        }
        public void resetBall()
        {
            Random r = new Random();
            
            yPos = r.Next(10, 90);
            //xVel = 3;
            //yVel = 1;
            if (turn)
            {
                xPos = 130;
                xVel = 3;
                if (r.Next(0, 1)==0)
                {
                    yVel = -1;
                }
                else
                {
                    yVel = 1;
                }
            }
            else
            {
                xPos = 115;
                xVel = -3;
                if (r.Next(0, 1)==0)
                {
                    yVel = -1;
                }
                else
                {
                    yVel = 1;
                }
            }
            turn = !turn;
        }
        public void handleCollision(Pad pad)
        {
            Random r = new Random();
            if (yPos < pad.yPos+3)
            {
                yVel = -1*r.Next(3,5);
                xVel = xVel > 0 ? -5+yVel/2 : 5-yVel/2;
            }
            else if (yPos > pad.yPos + 12)
            {
                yVel = r.Next(3,5);
                xVel = xVel > 0 ? -5-yVel/2 : 5+yVel/2;
            }
            else if (yPos >= pad.yPos && yPos <= pad.yPos + 9)
            {
                yVel = -1*r.Next(1,3);
                xVel = xVel > 0 ? -6+yVel : 6-yVel;
            }
            else if (yPos >= pad.yPos + 10 && yPos <= pad.yPos + 19)
            {
                yVel = r.Next(1,3);
                xVel = xVel > 0 ? -6-yVel : 6+yVel;
            }

            if (pad.xPos < 150)
                xPos = pad.xPos + pad.width + 1;
            else
                xPos = pad.xPos - size - 1;
        }

    }
}