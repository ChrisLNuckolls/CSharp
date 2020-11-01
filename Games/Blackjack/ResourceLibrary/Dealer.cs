using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceLibrary
{
    public class Dealer : Gamer
    {
        public Dealer(List<Card> startList)
        {
            Hand = startList;
        }
    }
}
