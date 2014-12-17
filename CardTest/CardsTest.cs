using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace CardTest
{
    [TestClass]
    public class CardsTest
    {
        [TestMethod]
        public void Test_String()
        {
            // arrange
            byte rank = 0;
            byte suit = 0;
            Card c2h = new Card { Rank=rank, Suit=suit };

            // act
            string s = c2h.ToString();

            // assert
            Assert.AreEqual(s, "2h");
        }
    }
}
