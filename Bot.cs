using System;

namespace Ships
{
    internal class Bot
    {
        Board board = new Board();
        Random random = new Random();
        public void Place()
        {
            int startX, startY, endX, endY;
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    Console.Clear();
                    startX = random.Next(10);
                    startY = random.Next(10);
                } while (!(board.IsAvaiablePlaceForShip(startX, startY, startX, startY, false)));
                board.BotPlace(startX, startY, startX, startY);
            }
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    Console.Clear();
                    startX = random.Next(9);
                    startY = random.Next(9);
                    if (random.Next(2) == 0)
                    {
                        endX = startX;
                        endY = startY + 1;
                    }
                    else
                    {
                        endY = startY;
                        endX = startX + 1;
                    }

                } while (!(board.IsAvaiablePlaceForShip(startX, startY, endX, endY, false)));
                board.BotPlace(startX, startY, endX, endY);
            }
            for (int i = 0; i < 2; i++)
            {
                do
                {
                    Console.Clear();
                    startX = random.Next(8);
                    startY = random.Next(8);
                    if (random.Next(2) == 0)
                    {
                        endX = startX;
                        endY = startY + 2;
                    }
                    else
                    {
                        endY = startY;
                        endX = startX + 2;
                    }

                } while (!(board.IsAvaiablePlaceForShip(startX, startY, endX, endY, false)));
                board.BotPlace(startX, startY, endX, endY);
            }
            do
            {
                Console.Clear();
                startX = random.Next(7);
                startY = random.Next(7);
                if (random.Next(2) == 0)
                {
                    endX = startX;
                    endY = startY + 3;
                }
                else
                {
                    endY = startY;
                    endX = startX + 3;
                }

            } while (!(board.IsAvaiablePlaceForShip(startX, startY, endX, endY, false)));
            board.BotPlace(startX, startY, endX, endY);
            board.ShowMyBoard(false);
        }
        public void Move()
        {
            int x;
            int y;
            do
            {
                x = random.Next(10);
                y = random.Next(10);
                    
            } while (!(board.IsAvaiable(y, x,false)));
            board.Shoot(y, x,false);
        }
    }
}
