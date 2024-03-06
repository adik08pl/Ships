using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string doPlayerWantToPlayAgain;
            bool nextGame = true;
            int playerOneWinCounter = 0;
            int playerTwoWinCounter = 0;
            Board board = new Board();
            bool endOfChoice = false;
            Console.WriteLine("Statki <3 \n1.Gracz vs Gracz \n2.Gracz vs Bot");
            int playerChoice = 0;
            do
            {
                try
                {
                    playerChoice = Int32.Parse(Console.ReadLine());
                    if (playerChoice != 1 || playerChoice != 2)
                        Console.WriteLine("Nieprawidłowy wybór.");
                }
                catch (Exception) 
                {
                    Console.WriteLine("Nieprawidłowy wybór.");
                }
               
            } while (!(playerChoice==1||playerChoice==2));
            if (playerChoice == 1) {
                Console.WriteLine("Jak nazywa się pierwszy gracz?");
                string name = Console.ReadLine();
                Player player1 = new Player(true, name);
                Console.WriteLine("Jak nazywa się drugi gracz?");
                name = Console.ReadLine();
                Player player2 = new Player(false, name);
                bool isPlayerOneTurn = true;
                do {
                    do
                    {
                        player1.Place();
                    } while (!(player1.IsBoardReady()));
                    Console.Clear();
                    Console.WriteLine("Proszę gracza \"" + player2.name + "\" do komputera.");
                    Console.ReadKey();
                    Console.ReadKey();
                    do
                    {
                        player2.Place();
                    } while (!(player2.IsBoardReady()));

                    do
                    {
                        if (Board.isPlayerOneTurn)
                        {
                            Console.WriteLine("Tura gracza: \"" + player1.name + "\".");
                            Console.ReadKey();
                            Console.ReadKey();
                            player1.Move();

                        }
                        else
                        {
                            Console.WriteLine("Tura gracza: \"" + player2.name + "\".");
                            Console.ReadKey();
                            Console.ReadKey();
                            player2.Move();
                        }
                    } while (board.WhoWon() == 0);
                    if (board.WhoWon() == 1)
                    {
                        playerOneWinCounter++;
                        Console.WriteLine("Wygrał gracz: \"" + player1.name + "\"");
                    }
                    else
                    {
                        playerTwoWinCounter++;
                        Console.WriteLine("Wygrał gracz: \"" + player2.name + "\"");
                    }
                    Console.WriteLine("Wynik to: " + playerOneWinCounter + "-" + playerTwoWinCounter);
                    bool end = false;
                    do
                    {
                        Console.WriteLine("Czy chcesz zagrać jeszcze raz (t/n) ?");
                        doPlayerWantToPlayAgain = Console.ReadLine();
                        switch (doPlayerWantToPlayAgain)
                        {
                            case "t":
                                end = true;
                                break;
                            case "n":
                                nextGame = false;
                                end = true;
                                break;
                            default:
                                Console.WriteLine("Niepoprawny wybór.");
                                break;
                        }
                    } while (end == false);
                    board.Clear();
                } while (nextGame);
            }
            else
            {
                Player player = new Player(true, "Gracz");
                Bot bot = new Bot();
                do
                {
                    player.Place();
                } while (!(player.IsBoardReady()));
                Console.Clear();
                Console.WriteLine("Bot przygotowuje planszę.");
                Console.ReadKey();
                bot.Place();
                do
                {
                    if (Board.isPlayerOneTurn)
                    {
                        player.Move();
                    }
                    else
                    {
                        bot.Move();
                    }
                } while (board.WhoWon() == 0);
                if (board.WhoWon() == 1)
                {
                    playerOneWinCounter++;
                    Console.WriteLine("Wygrał gracz.");
                }
                else
                {
                    playerTwoWinCounter++;
                    Console.WriteLine("Wygrał bot.");
                }
                Console.WriteLine("Wynik to: " + playerOneWinCounter + "-" + playerTwoWinCounter);
                bool end = false;
                do
                {
                    Console.WriteLine("Czy chcesz zagrać jeszcze raz (t/n) ?");
                    doPlayerWantToPlayAgain = Console.ReadLine();
                    switch (doPlayerWantToPlayAgain)
                    {
                        case "t":
                            end = true;
                            break;
                        case "n":
                            nextGame = false;
                            end = true;
                            break;
                        default:
                            Console.WriteLine("Niepoprawny wybór.");
                            break;
                    }
                } while (end == false);
            }
            Console.ReadKey();
        }
    }
}
