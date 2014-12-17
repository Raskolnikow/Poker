using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Deck
    {
        public Deck()
        {
            rnd = new Random();
            cards = new List<Card>();
            createCards();
        }


        /// <summary>
        /// initializes the deck
        /// </summary>
        public void shuffle()
        {
            cards.Clear();
            createCards();

        }

        /// <summary>
        /// returns a new card
        /// </summary>
        /// <returns>a new Card, null if deck is empty</returns>
        public Card getNextCard()
        {
            if(cards.Count == 0)
                throw new Exception("Deck is empty!");

            int newpos = rnd.Next(cards.Count);

            Card c = cards[newpos];
            cards.RemoveAt(newpos);

            return c;
        }

        /// <summary>
        /// creates a fresh deck of 52 cards
        /// </summary>
        private void createCards()
        {
            for(byte i=0; i<4; i++)
            {
                for (byte k = 0; k < 13; k++)
                {
                    cards.Add(new Card { Rank=(byte)(k+2), Suit=i});
                }
            }
        }

        private List<Card> cards;
        Random rnd;

    }
}
