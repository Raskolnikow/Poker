using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    enum HAND
    {
        UNDEFINED = 0,
        HIGH_CARD,          // Rank         Anzahl          1
        ONE_PAIR,           // Rank         Anzahl          2
        TWO_PAIR,           // Rank         Anzahl          2, 2
        SET,                // Rank         Anzahl          3
        STRAIGHT,           // Rank         Reihenfolge     1,2,3,4,5
        FLUSH,              // Suit         
        FULL_HOUSE,         // Rank         Anzahl          3,2
        FOUR_OF_A_KING,     // Rank         Anzahl          4
        STRAIGHT_FLUSH,     // Suit, Rank   Reihenfolge     1,2,3,4,5
        ROYAL_FLUSH         // Suit, Rank   Reihenfolge     1,2,3,4,5
    };

    /*
     *  1. Suit
     *  2. Rank
     *      + Four
     *      + Full-House
     *      + Set
     *      + Two-Pair
     *      + One-Pair
     *      
     *      + Straight
     *      + High Card
     * 
     */
    class HandAnalyzer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handCards"></param>
        /// <param name="tableCards"></param>
        /// <param name="numFixedHandCards"></param>
        /// <returns>Returns the best possible hand</returns>
        public HAND Analyze(List<Card> hand, List<Card> handCards, List<Card> tableCards, byte numFixedHandCards)
        {
            if (hand == null || handCards == null || tableCards == null) throw new NullReferenceException();
            if (handCards.Count + tableCards.Count < 5) return HAND.UNDEFINED;
            
            initialize(hand, handCards, tableCards, numFixedHandCards);
            analyze();

            return handType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public string getHandAsString(HAND hand)
        {
            string[] s = { "Undefined", "High Card", "One Pair", "Two Pair", "Set", "Straight", "Flush", "Full House", "Four of a Kind", "Straight Flush", "Royal Flush" };

            return s[(int)hand];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="handCards"></param>
        /// <param name="tableCards"></param>
        /// <param name="numFixedHandCards"></param>
        private void initialize(List<Card> hand, List<Card> handCards, List<Card> tableCards, byte numFixedHandCards)
        {
            this.hand = hand;
            this.handCards = handCards;
            this.tableCards = tableCards;
            this.numFixedHandCards = numFixedHandCards;

            foreach(var c in handCards)
                this.allCards.Add(c);

            foreach (var c in tableCards)
                this.allCards.Add(c);

            //allCards.Sort();

            countCards();
        }

        /// <summary>
        /// 
        /// </summary>
        private void countCards()
        {
            for(byte i=0; i<15; i++)
                ranks[i] = 0;

            for (byte i = 0; i < 4; i++)
                suits[i] = 0;

            foreach (Card c in allCards)
            {
                ranks[c.Rank]++;
                suits[c.Suit]++;
            }
        }

        /// <summary>
        /// Es ist zu überlegen, ob eine Sortierung alle weiteren Schritte vereinfachen würde.
        /// </summary>
        private void analyze()
        {
            if (!RoyalFlush())
                if (!StraightFlush())   
                    if (!FourOfAKind())
                        if (!FullHouse())
                            if (!Flush())
                                if (!Straight())
                                    if (!Set())
                                        if (!TwoPair())
                                            if (!OnePair())
                                                HighCard();
        }

        /* ------------------------------------ Detections ------------------------------------------ */

        bool isFlush()
        {
            foreach (byte s in suits)
                if (s >= 4)
                    return true;

            return false;
        }

        byte isStraight()
        {
            return 0;
        }

        // Es müssen alle sieben Karten geprüft werden, auch wenn schon
        // in der Flush() Routine die Farbe geprüft wurde. Der Royal/Straight
        // kann zustande kommen bei mehr als 5 gleichen farben.
        private bool RoyalFlush()
        {
            if (isFlush())
            {
                if (isStraight() == 14)
                {
                    handType = HAND.ROYAL_FLUSH;
                    return true;
                }
            }

            for (int i = 0; i < 5; i++)
                hand.Add(allCards[i]);

            return false;
        }

        // Es müssen alle sieben Karten geprüft werden, auch wenn schon
        // in der Flush() Routine die Farbe geprüft wurde. Der Royal/Straight
        // kann zustande kommen bei mehr als 5 gleichen farben.
        private bool StraightFlush()
        {
            throw new NotImplementedException();
        }

        // mindestens fünf Karten müssen von der gleichen Farbe sein
        // at least five cards have to be of same suit
        private bool Flush()
        {
            throw new NotImplementedException();
        }
        
        //
        //
        //
        private bool FourOfAKind()
        {
            throw new NotImplementedException();
        }

        //
        //
        //
        private bool FullHouse()
        {
            throw new NotImplementedException();
        }

        //
        //
        //
        private bool Straight()
        {
            throw new NotImplementedException();
        }
        //
        //
        //
        private bool Set()
        {
            throw new NotImplementedException();
        }

        //
        //
        //
        private bool TwoPair()
        {
            throw new NotImplementedException();
        }

        //
        //
        //
        private bool OnePair()
        {
            throw new NotImplementedException();
        }

        //
        //
        //
        private bool HighCard()
        {
            throw new NotImplementedException();
        }

        /* ------------------------------------ private members ------------------------------------------ */

        List<Card> handCards;
        List<Card> tableCards;
        byte numFixedHandCards;

        List<Card> allCards = new List<Card>();
        List<Card> hand = new List<Card>();
        HAND handType;

        byte[] ranks = new byte[15];
        byte[] suits = new byte[4];
    }
}
