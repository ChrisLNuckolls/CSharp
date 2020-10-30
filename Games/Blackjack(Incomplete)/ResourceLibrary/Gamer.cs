using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceLibrary
{
    public abstract class Gamer
    {
        private bool _hasAce = false;
        
        public List<Card> Hand { get; set; }
        public int HandValue { get; set; }
        public int TotalCards { get; set; }
        //public bool HasAce { get; set; }
        public bool HasAce
        {
            get { return _hasAce; }
            set { _hasAce = value; }
        }


        public override string ToString()
        {
            string currentHand = "";

            foreach (Card item in Hand)
            {
                currentHand += item + " ";
            }

            return string.Format(currentHand);
        }

    }
}
