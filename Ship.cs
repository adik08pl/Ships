using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    internal class Ship
    {
        public int startPositionX;
        public int startPositionY;
        public int endPositionX;
        public int endPositionY;
        public bool[] shipBody;
        public Ship(int startPositionX,int startPositionY,int endPositionX,int endPositionY) { 
            this.startPositionX = startPositionX;
            this.startPositionY = startPositionY;
            this.endPositionX = endPositionX;
            this.endPositionY = endPositionY;
            int length = Math.Abs(startPositionX - endPositionX + startPositionY - endPositionY)+1;
            shipBody = new bool[length];
            for(int i = 0;i<length;i++) {
                shipBody[i]= true;
            }
        }
        public bool IsAlive()
        {
            foreach(bool shipPart in shipBody) { 
                if(shipPart) return true;
            }
            return false;
        }
        public void TakeDamage()
        {
            for(int i = 0; i < shipBody.Length;i++)
            {
                if (shipBody[i]==true) {
                    shipBody[i]=false;
                    break;
                }
            }
        }
        public IEnumerable<int> WhereIsShip()
        {
            List<int> shipPlace = new List<int>();
            for (int i = 0; i < Math.Abs(startPositionX - endPositionX) + 1; i++)
            {
                for (int j = 0; j < Math.Abs(startPositionY - endPositionY) + 1; j++)
                {
                    if (startPositionX - endPositionX < 0 || startPositionY - endPositionY < 0)
                        shipPlace.Add((startPositionX + i) + (startPositionY + j) * 10);
                    else
                        shipPlace.Add((startPositionX - i) + (startPositionY - j) * 10);
                }
            }
            return shipPlace.Distinct();
        }
    }
}
