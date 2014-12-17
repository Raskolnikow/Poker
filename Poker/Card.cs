using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Card : IComparable<Card>
    {
        public byte Suit { get; set; }
        public byte Rank { get; set; }

        public override string ToString()
        {
            string[] r = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "D", "K", "A", };
            string[] s = { "h", "d", "c", "s" };

            return r[Rank] + s[Suit];
        }

        public int CompareTo(Card that)
        {
            if (this.Rank < that.Rank) return -1;
            else if (this.Rank > that.Rank) return 1;
            else return 0;
        }
    }
}
