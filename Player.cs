using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    internal class Player
    {
        public string name ="";
        bool isPlayerOne;
        Board board = new Board();
        public Player(bool isPlayerOne,string name) { 
            this.isPlayerOne= isPlayerOne;
            this.name= name;
        }
        public void Place()
        {
            try
            {
                Console.Clear();
                board.ShowMyBoard(isPlayerOne);
                Console.WriteLine("Wybierz początkowe pole");
                string start = Console.ReadLine();
                Console.WriteLine("Wybierz końcowe pole");
                string end = Console.ReadLine();
                if (board.IsAvaiablePlaceForShip(start[1]-'0', ((int)start.ToUpper()[0])-65,end[1]-'0', ((int)end.ToUpper()[0])-65, isPlayerOne))
                {
                   
                    board.Place(start[1]-'0', ((int)start.ToUpper()[0])-65,end[1]-'0', ((int)end.ToUpper()[0])-65, isPlayerOne);
                }
                else
                {
                    Console.ReadKey();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Niepoprawna wartość");
                Console.ReadKey();
            }
        }
        public void Move()
        {
            try
            {
                Console.Clear();
                board.Show(isPlayerOne);
                board.ShowMyBoard(isPlayerOne);
                Console.WriteLine("Wybierz pole");
                string place = Console.ReadLine();
                if (board.IsAvaiable(((int)place.ToUpper()[0]) - 65, place[1] - '0', isPlayerOne))
                {
                    board.Shoot(((int)place.ToUpper()[0]) - 65, place[1] - '0', isPlayerOne);
                    board.Show(isPlayerOne);
                    board.ShowMyBoard(isPlayerOne);
                }
                else
                {
                    Console.WriteLine("Wybrano złe pole.");
                    Console.ReadKey();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Niepoprawna wartość");
                Console.ReadKey();
            }
        }
        public bool IsBoardReady()
        {
            return board.IsReady(isPlayerOne);
        }
    }
}
