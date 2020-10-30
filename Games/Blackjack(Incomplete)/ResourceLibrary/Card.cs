using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceLibrary
{
    public class Card
    {
        public int Value { get; set; }
        public Suit CardSuit { get; set; }
        public string FaceValue { get; set; }

        public Card(int value, Suit cardSuit, string faceValue)
        {
            Value = value;
            CardSuit = cardSuit;
            FaceValue = faceValue;
        }

        public override string ToString()
        {
            return string.Format("{0} of {1}", FaceValue, CardSuit);
        }

    }
}
