using System;
using System.Numerics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    internal class Board
    {
        static char[,] firstShootingBoard = { { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' } };
        static char[,] secondShootingBoard = { { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' } };
        static char[,] secondBoard = { { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' } };
        static char[,] firstBoard = { { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' } };
        static List<Ship> firstShips = new List<Ship>();
        static List<Ship> secondShips = new List<Ship>();
        static public bool isPlayerOneTurn = true;
        public void Show(bool isPlayerOne)
        {

            Console.WriteLine(" Tutaj strzelasz: ");
            Console.WriteLine("    A B C D E F G H I J");
            Console.WriteLine("    ____________________");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("\n" + i + " | ");
                for (int j = 0; j < 10; j++) {
                    if (isPlayerOne)
                        Console.Write(firstShootingBoard[i, j] + " ");
                    else
                        Console.Write(secondShootingBoard[i, j] + " ");
                }
                Console.Write(" | " + i);
            }
            Console.WriteLine("\n    ____________________");
            Console.WriteLine("    A B C D E F G H I J");
        }
        public void ShowMyBoard(bool isPlayerOne)
        {
            Console.WriteLine("\n Twoje statki: ");
            Console.WriteLine("    A B C D E F G H I J");
            Console.WriteLine("    ____________________");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("\n" + i + " | ");
                for (int j = 0; j < 10; j++)
                {
                    if (isPlayerOne)
                        Console.Write(firstBoard[i, j] + " ");
                    else
                        Console.Write(secondBoard[i, j] + " ");
                }
                Console.Write(" | " + i);
            }
            Console.WriteLine("\n    ____________________");
            Console.WriteLine("    A B C D E F G H I J");
        }
        public bool IsAvaiable(int userY, int userX, bool isPlayerOne)
        {
            if (isPlayerOne && firstShootingBoard[userX, userY].Equals(' '))
                return true;
            else if (!isPlayerOne && secondShootingBoard[userX, userY].Equals(' '))
                return true;
            else
                return false;
        }
        public bool IsAvaiablePlaceForShip(int startPositionX, int startPositionY, int endPositionX, int endPositionY, bool isPlayerOne)
        {
            if ((!(startPositionX <= 9 && startPositionX >= 0) || !(startPositionY <= 9 && startPositionY >= 0) || !(endPositionX <= 9 && endPositionX >= 0) || !(endPositionY <= 9 && endPositionY >= 0)))
            {
                Console.WriteLine("Niepoprawne miejsce na statek");
                return false;
            }
            if (startPositionX - endPositionX == 0 || startPositionY - endPositionY == 0)
            {

                for (int i = -2; i < Math.Abs(startPositionX - endPositionX) + 1; i++)
                {
                    for (int j = -2; j < Math.Abs(startPositionY - endPositionY) + 1; j++)
                        try
                        {
                            if (startPositionX - endPositionX < 0 || startPositionY - endPositionY < 0)
                            {
                                if (isPlayerOne && firstBoard[startPositionX + i + 1, startPositionY + j + 1].Equals('█'))
                                {
                                    Console.WriteLine("Niepoprawne miejsce na statek");
                                    return false;
                                }
                                else if (!(isPlayerOne) && secondBoard[startPositionX + i + 1, startPositionY + j + 1].Equals('█'))
                                {
                                    Console.WriteLine("Niepoprawne miejsce na statek");
                                    return false;
                                }
                            }
                            else
                            {
                                if (isPlayerOne && firstBoard[startPositionX - i - 1, startPositionY - j - 1].Equals('█'))
                                {
                                    Console.WriteLine("Niepoprawne miejsce na statek");
                                    return false;
                                }
                                else if (!(isPlayerOne) && secondBoard[startPositionX - i - 1, startPositionY - j - 1].Equals('█'))
                                {
                                    Console.WriteLine("Niepoprawne miejsce na statek");
                                    return false;
                                }
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {

                        }

                }
                if (Math.Abs(startPositionX - endPositionX + startPositionY - endPositionY) > 4 || Math.Abs(startPositionX - endPositionX + startPositionY - endPositionY) < 0)
                {
                    Console.WriteLine("Zły rozmiar statku");
                    return false;
                }
                int[] shipsLengths = { 0, 0, 0, 0 };
                if (isPlayerOne)
                {
                    foreach (Ship ship in firstShips)
                    {
                        shipsLengths[ship.shipBody.Length - 1]++;
                    }
                    if (shipsLengths[Math.Abs(startPositionX - endPositionX + startPositionY - endPositionY)] >= 5 - Math.Abs(startPositionX - endPositionX + startPositionY - endPositionY) - 1)
                    {
                        Console.WriteLine("Masz już wszystkie " + (Math.Abs(startPositionX - endPositionX + startPositionY - endPositionY) + 1) + "-masztowce");
                        return false;
                    }
                }
                else
                {
                    foreach (Ship ship in secondShips)
                    {
                        shipsLengths[ship.shipBody.Length - 1]++;
                    }
                    if (shipsLengths[Math.Abs(startPositionX - endPositionX + startPositionY - endPositionY)] >= 5 - Math.Abs(startPositionX - endPositionX + startPositionY - endPositionY) - 1)
                    {
                        Console.WriteLine("Masz już wszystkie " + (Math.Abs(startPositionX - endPositionX + startPositionY - endPositionY) + 1) + "-masztowce");
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public void Shoot(int userY, int userX, bool isPlayerOne)
        {
            if (isPlayerOne && secondBoard[userX, userY] == '█')
            {
                firstShootingBoard[userX, userY] = 'X';
                secondBoard[userX, userY] = 'X';
                foreach (Ship ship in secondShips)
                {
                    foreach (int place in ship.WhereIsShip())
                    {
                        if (place == userX + userY * 10)
                            ship.TakeDamage();
                        if (!(ship.IsAlive()))
                        {
                            for (int i = -2; i < Math.Abs(ship.startPositionX - ship.endPositionX) + 1; i++)
                            {
                                for (int j = -2; j < Math.Abs(ship.startPositionY - ship.endPositionY) + 1; j++) {
                                    try
                                    {
                                        if (ship.startPositionX - ship.endPositionX < 0 || ship.startPositionY - ship.endPositionY < 0)
                                        {
                                            firstShootingBoard[ship.startPositionX + i + 1, ship.startPositionY + j + 1] = 'O';
                                            secondBoard[ship.startPositionX + i + 1, ship.startPositionY + j + 1] = 'O';
                                            for (int k = 0; k < Math.Abs(ship.startPositionY - ship.endPositionY) + 1; k++)
                                            {
                                                for (int l = 0; l < Math.Abs(ship.startPositionX - ship.endPositionX) + 1; l++)
                                                {
                                                    firstShootingBoard[ship.startPositionX + l, ship.startPositionY + k] = 'X';
                                                    secondBoard[ship.startPositionX + l, ship.startPositionY + k] = 'X';
                                                }
                                            }

                                        }
                                        else
                                        {
                                            firstShootingBoard[ship.startPositionX - i - 1, ship.startPositionY - j - 1] = 'O';
                                            secondBoard[ship.startPositionX - i - 1, ship.startPositionY - j - 1] = 'O';
                                            for (int k = 0; k < Math.Abs(ship.startPositionY - ship.endPositionY) + 1; k++)
                                            {
                                                for (int l = 0; l < Math.Abs(ship.startPositionX - ship.endPositionX) + 1; l++)
                                                {
                                                    firstShootingBoard[ship.startPositionX - l, ship.startPositionY - k] = 'X';
                                                    secondBoard[ship.startPositionX - l, ship.startPositionY - k] = 'X';
                                                }
                                            }
                                        }
                                    }
                                    catch (IndexOutOfRangeException)
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (!isPlayerOne && firstBoard[userX, userY] == '█')
            {
                secondShootingBoard[userX, userY] = 'X';
                firstBoard[userX, userY] = 'X';
                foreach (Ship ship in firstShips)
                {
                    foreach (int place in ship.WhereIsShip())
                    {

                        if (place == userX + userY * 10)
                            ship.TakeDamage();

                        if (!(ship.IsAlive()))
                        {
                            for (int i = -2; i < Math.Abs(ship.startPositionX - ship.endPositionX) + 1; i++)
                            {
                                for (int j = -2; j < Math.Abs(ship.startPositionY - ship.endPositionY) + 1; j++)
                                {
                                    try
                                    {
                                        if (ship.startPositionX - ship.endPositionX < 0 || ship.startPositionY - ship.endPositionY < 0)
                                        {
                                            secondShootingBoard[ship.startPositionX + i + 1, ship.startPositionY + j + 1] = 'O';
                                            firstBoard[ship.startPositionX + i + 1, ship.startPositionY + j + 1] = 'O';
                                            for (int k = 0; k < Math.Abs(ship.startPositionY - ship.endPositionY) + 1; k++)
                                            {
                                                for (int l = 0; l < Math.Abs(ship.startPositionX - ship.endPositionX) + 1; l++)
                                                {
                                                    secondShootingBoard[ship.startPositionX + l, ship.startPositionY + k] = 'X';
                                                    firstBoard[ship.startPositionX + l, ship.startPositionY + k] = 'X';
                                                }
                                            }
                                        }
                                        else
                                        {
                                            secondShootingBoard[ship.startPositionX - i - 1, ship.startPositionY - j - 1] = 'O';
                                            firstBoard[ship.startPositionX - i - 1, ship.startPositionY - j - 1] = 'O';
                                            for (int k = 0; k < Math.Abs(ship.startPositionY - ship.endPositionY) + 1; k++)
                                            {
                                                for (int l = 0; l < Math.Abs(ship.startPositionX - ship.endPositionX) + 1; l++)
                                                {
                                                    secondShootingBoard[ship.startPositionX - l, ship.startPositionY - k] = 'X';
                                                    firstBoard[ship.startPositionX - l, ship.startPositionY - k] = 'X';
                                                }
                                            }
                                        }
                                    }
                                    catch (IndexOutOfRangeException)
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (isPlayerOne)
                {
                    firstShootingBoard[userX, userY] = 'O';
                    secondBoard[userX, userY] = 'O';
                    isPlayerOneTurn = !(isPlayerOne);
                }
                else
                {
                    secondShootingBoard[userX, userY] = 'O';
                    firstBoard[userX, userY] = 'O';
                    isPlayerOneTurn = !(isPlayerOne);
                }
            }
        }
        public void Place(int startPositionY, int startPositionX, int endPositionY, int endPositionX, bool isPlayerOne)
        {

            for (int i = 0; i < Math.Abs(startPositionY - endPositionY) + 1; i++)
            {
                for (int j = 0; j < Math.Abs(startPositionX - endPositionX) + 1; j++)
                    if (isPlayerOne)
                    {
                        if (startPositionX - endPositionX < 0 || startPositionY - endPositionY < 0)
                            firstBoard[startPositionY + i, startPositionX + j] = '█';
                        else
                            firstBoard[startPositionY - i, startPositionX - j] = '█';
                    }
                    else
                    {
                        if (startPositionX - endPositionX < 0 || startPositionY - endPositionY < 0)
                            secondBoard[startPositionY + i, startPositionX + j] = '█';
                        else
                            secondBoard[startPositionY - i, startPositionX - j] = '█';
                    }
            }
            ShowMyBoard(isPlayerOne);
            bool end = false;
            string playerChoice;
            do
            {
                Console.WriteLine("Napewno chcesz tutaj postawić statek t/n?");
                playerChoice = Console.ReadLine();
                switch (playerChoice)
                {
                    case "t":
                        if (isPlayerOne)
                            firstShips.Add(new Ship(startPositionY, startPositionX, endPositionY, endPositionX));
                        else
                            secondShips.Add(new Ship(startPositionY, startPositionX, endPositionY, endPositionX));
                        end = true;
                        break;
                    case "n":
                        for (int i = 0; i < Math.Abs(startPositionY - endPositionY) + 1; i++)
                        {
                            for (int j = 0; j < Math.Abs(startPositionX - endPositionX) + 1; j++)
                                firstBoard[startPositionY + i, startPositionX + j] = ' ';
                        }
                        end = true;
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór.");
                        break;
                }
            } while (end == false);
        }

        public int WhoWon()
        {
            bool isPlayerOneDead = true;
            foreach (Ship ship in firstShips) {
                if (ship.IsAlive())
                    isPlayerOneDead = false;
            }
            bool isPlayerTwoDead = true;
            foreach (Ship ship in secondShips)
            {
                if (ship.IsAlive())
                    isPlayerTwoDead = false;
            }
            if (isPlayerOneDead)
                return 2;
            else if (isPlayerTwoDead)
                return 1;
            else
                return 0;
        }
        public bool IsReady(bool isPlayerOne)
        {
            try
            {
                int shipBodiesCounter = 0;
                if (isPlayerOne)
                {
                    foreach (Ship ship in firstShips)
                    {
                        shipBodiesCounter += ship.shipBody.Length;
                    }
                    Console.WriteLine(shipBodiesCounter + " " + firstShips.Count());
                    if (shipBodiesCounter == 20 && firstShips.Count() == 10)
                        return true;
                }
                else
                {
                    foreach (Ship ship in secondShips)
                    {
                        shipBodiesCounter += ship.shipBody.Length;
                    }
                    if (shipBodiesCounter == 20 && secondShips.Count() == 10)
                        return true;
                }
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
        public void BotPlace(int startPositionY, int startPositionX, int endPositionY, int endPositionX)
        {
            for (int i = 0; i < Math.Abs(startPositionY - endPositionY) + 1; i++)
            {
                for (int j = 0; j < Math.Abs(startPositionX - endPositionX) + 1; j++)
                {
                    if (startPositionX - endPositionX < 0 || startPositionY - endPositionY < 0)
                        secondBoard[startPositionY + i, startPositionX + j] = '█';
                    else
                        secondBoard[startPositionY - i, startPositionX - j] = '█';
                }
            }
            secondShips.Add(new Ship(startPositionY, startPositionX, endPositionY, endPositionX));
        }
        public void Clear()
        {
            Array.Clear(firstShootingBoard,0, 100);
            Array.Clear(secondShootingBoard,0, 100);
            Array.Clear(secondBoard,0, 100);
            Array.Clear(firstBoard,0, 100);
            firstShips.Clear();
            secondShips.Clear();
            isPlayerOneTurn = true;
        }
    }
}
