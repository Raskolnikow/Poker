using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace CardTest
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void Test_RoyalFlush()
        {
            byte whichCards = 0;
            List<Card> hand = new List<Card>();

            hand.Add(new Card { Rank = 2, Suit = 0 } );
            hand.Add(new Card { Rank = 5, Suit = 1 });
            hand.Add(new Card { Rank = 8, Suit = 2 });
            hand.Add(new Card { Rank = 10, Suit = 3 });
            hand.Add(new Card { Rank = 13, Suit = 0 });

            Assert.AreEqual(false, Hand.isRoyalFlush(hand, ref whichCards));
            
        }
    }
}
