using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Hand
    {
        /// <summary 
        /// 
        /// </summary>
        /// 
        /// <param name="cards"></param>
        /// <param name="whichCards"></param>
        /// <returns></returns>
        /// 
        public static bool isRoyalFlush(List<Card> cards, ref byte whichCards)
        {
            if (cards.Count < 5) return false;
            else if (!isFlush(cards, ref whichCards)) return false;
            else
            {
                
            }

            whichCards = 0;
            return false;
        }

        //
        //
        //
        public static bool isStraightFlush()
        {
            throw new NotImplementedException();
        }

        //
        //
        //
        public static bool isFourOfAKind()
        {
            throw new NotImplementedException();
        }

        //
        //
        //
        public static bool isFullHouse()
        {
            throw new NotImplementedException();
        }

        //
        //
        //
        public static bool isFlush(List<Card> cards, ref byte whichCards)
        {
            return false;
        }

        //
        //
        //
        public static bool isStraight()
        {
            throw new NotImplementedException();
        }

        //
        //
        //
        public static bool isSet()
        {
            throw new NotImplementedException();
        }

        //
        //
        //
        public static bool isTwoPair()
        {
            throw new NotImplementedException();
        }

        //
        //
        //
        public static bool isOnePair()
        {
            throw new NotImplementedException();
        }

        //
        //
        //
        public static bool isHighCard()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void countCards(List<Card> hand)
        {
           /* for (byte i = 0; i < 15; i++)
                ranks[i] = 0;

            for (byte i = 0; i < 4; i++)
                suits[i] = 0;

            foreach (Card c in hand)
            {
                ranks[c.Rank]++;
                suits[c.Suit]++;
            }*/
        }

        byte[] ranks = new byte[15];
        byte[] suits = new byte[4];
    }
}
