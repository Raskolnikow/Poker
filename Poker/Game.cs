using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum GAME_STATE
    {
        GAME_STATE_INIT,
        GAME_STATE_DEALER,          // Game        
        GAME_STATE_BLINDS,          // Players / Game
        GAME_STATE_CARDS_HAND,      // Game
        GAME_STATE_BET_PREFLOP,     // Players
        GAME_STATE_CARDS_FLOP,      // Game
        GAME_STATE_BET_POSTFLOP,    // Players
        GAME_STATE_CARDS_TURN,      // Game
        GAME_STATE_BET_TURN,        // Players
        GAME_STATE_CARDS_RIVER,     // Game
        GAME_STATE_BET_RIVER,       // Players
        GAME_STATE_SHOWDOWN,        // Players
        GAME_STATE_POT_PAYOUT       // Game
    }; 

    public class GameStateEventArgs : EventArgs
    {
        public GameStateEventArgs(GAME_STATE state)
        {
            this.State = state;
        }

        public GAME_STATE State {get; private set; }
    }

    public class Game
    {
        const long SMALL_BLIND = 1;
        const long BIG_BLIND = 2;

        public event EventHandler<GameStateEventArgs> NewState;     

        public Game()
        {
            players = new List<Player>();
            deck = new Deck();

            gameState = GAME_STATE.GAME_STATE_INIT;
        }

        public void addPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void start()
        {
            if (players.Count < 2)
                throw new Exception("Zu wenige Spieler am Tisch");

            setBlinds();
            dealHandCards();

            gameState = GAME_STATE.GAME_STATE_BET_PREFLOP;

        }

        public void quit()
        {

        }

        public void goToNextState()
        {
            gameState++;

            if (NewState != null)
                NewState(this, new GameStateEventArgs(gameState));

            if (gameState == GAME_STATE.GAME_STATE_POT_PAYOUT)
                gameState = GAME_STATE.GAME_STATE_INIT;
        }

        /// <summary>
        /// private methods
        /// </summary> 

        private void setBlinds()
        {
            gameState = GAME_STATE.GAME_STATE_BLINDS;

            if (NewState != null)
                NewState(this, new GameStateEventArgs(gameState));

            for(int i=0; i < players.Count; i++)
            {
                if (players[i].Label == PLAYER_LABEL.PLAYER_LABEL_BUTTON)
                {
                    players[(i + 1) % players.Count].Label = PLAYER_LABEL.PLAYER_LABEL_BUTTON;
                    players[(i + 2) % players.Count].Label = PLAYER_LABEL.PLAYER_LABEL_SB;
                    players[(i + 2) % players.Count].Bet = SMALL_BLIND;
                    players[(i + 3) % players.Count].Label = PLAYER_LABEL.PLAYER_LABEL_BB;
                    players[(i + 2) % players.Count].Bet = BIG_BLIND;

                    return;
                }
            }

            // If the game was first time started
            players[(0) % players.Count].Label = PLAYER_LABEL.PLAYER_LABEL_BUTTON;
            players[(1) % players.Count].Label = PLAYER_LABEL.PLAYER_LABEL_SB;
            players[(1) % players.Count].Bet = SMALL_BLIND;
            players[(2) % players.Count].Label = PLAYER_LABEL.PLAYER_LABEL_BB;
            players[(2) % players.Count].Bet = BIG_BLIND;
        }

        private void dealHandCards()
        {
            gameState = GAME_STATE.GAME_STATE_CARDS_HAND;

            if (NewState != null)
                NewState(this, new GameStateEventArgs(gameState));
        }

        /// <summary>
        /// private members
        /// </summary>

        private List<Player> players;
        private Deck deck;

        private GAME_STATE gameState;
    }
}
