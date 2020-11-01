using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceLibrary
{
    public class Player : Gamer
    {
        public int Chips { get; set; }
        public Player(List<Card> startList)
        {
            Hand = startList;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
