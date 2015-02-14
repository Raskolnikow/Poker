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
     * 
     *      Ah Kh Dh Jh 10h 8d Ac
     *      
     *      Dd Jd 10d 9d 8d Ac Kh
     *      
     *      Kd Kh Ks Kc Jd 8c 2h
     *      
     *      Dh Dd Dc 10h 10d 8c Ad
     *      
     *      9h Jh 2h 8h Ah 10c Jd
     *      
     *      8c 9d 10c Jh Dh 2d 5c
     *      
     *      8c 8d 8h Ad Jc 10h 3d
     *      
     *      9c 9d 10c 10h Js As 8h
     *      
     *      9c 9d As Ks 8c 7d 2h
     *      
     *      Dc 9d As Ks 8c 7d 2h
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
        }

        

        /// <summary>
        /// Es ist zu überlegen, ob eine Sortierung alle weiteren Schritte vereinfachen würde.
        /// </summary>
        private void analyze()
        {
            /*if (!Hand.isRoyalFlush())
                if (!Hand.isStraightFlush())   
                    if (!Hand.isFourOfAKind())
                        if (!Hand.isFullHouse())
                            if (!Hand.isFlush())
                                if (!Hand.isStraight())
                                    if (!Hand.isSet())
                                        if (!Hand.isTwoPair())
                                            if (!Hand.isOnePair())
                                                Hand.isHighCard();*/
        }

        

        /* ------------------------------------ private members ------------------------------------------ */

        List<Card> handCards;
        List<Card> tableCards;
        byte numFixedHandCards;

        List<Card> allCards = new List<Card>();
        List<Card> hand = new List<Card>();
        HAND handType;
    }
}
