using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Game
    {
        public enum GAME_STATES
        {
            GAME_STATE_DEALER,
            GAME_STATE_BLINDS,
            GAME_STATE_CARDS_HAND,
            GAME_STATE_BET_PREFLOP,
            GAME_STATE_CARDS_FLOP,
            GAME_STATE_BET_POSTFLOP,
            GAME_STATE_CARDS_TURN,
            GAME_STATE_BET_TURN,
            GAME_STATE_CARDS_RIVER,
            GAME_STATE_BET_RIVER,
            GAME_STATE_SHOWDOWN,
            GAME_STATE_POT_PAYOUT
        };

        public Game()
        {
            deck = new Deck();
        }

        void start()
        {
            while (run)
            {
                switch(gameState)
                {
                    case GAME_STATES.GAME_STATE_DEALER: break;

                    case GAME_STATES.GAME_STATE_BLINDS: break;

                    case GAME_STATES.GAME_STATE_CARDS_HAND: break;

                    case GAME_STATES.GAME_STATE_BET_PREFLOP: break;

                    case GAME_STATES.GAME_STATE_CARDS_FLOP: break;

                    case GAME_STATES.GAME_STATE_BET_POSTFLOP: break;

                    case GAME_STATES.GAME_STATE_CARDS_TURN: break;

                    case GAME_STATES.GAME_STATE_BET_TURN: break;

                    case GAME_STATES.GAME_STATE_CARDS_RIVER: break;

                    case GAME_STATES.GAME_STATE_BET_RIVER: break;

                    case GAME_STATES.GAME_STATE_SHOWDOWN: break;

                    case GAME_STATES.GAME_STATE_POT_PAYOUT: break;

                    default: break;
                }
            }
        }

        Deck deck;

        private bool run;
        private GAME_STATES gameState;
    }
}
