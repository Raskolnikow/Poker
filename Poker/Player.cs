using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum PLAYER_LABEL
    {
        PLAYER_LABEL_NONE,
        PLAYER_LABEL_BUTTON,
        PLAYER_LABEL_SB,
        PLAYER_LABEL_BB
    };

    public enum PLAYER_ACTION
    {
        PLAYER_ACTION_FOLD,
        PLAYER_ACTION_CHECK,
        PLAYER_ACTION_BET,
        PLAYER_ACTION_RAISE
    };

    public class Player
    {
        public Player(string nick, long stack)
        {
            Nick = nick;
            Label = PLAYER_LABEL.PLAYER_LABEL_NONE;

            Stack = stack;
        }

        public void action(PLAYER_ACTION action, long bet)
        {
            Action = action;

            if (Action == PLAYER_ACTION.PLAYER_ACTION_FOLD || Action == PLAYER_ACTION.PLAYER_ACTION_CHECK)
                Bet = 0;
            else
                Bet = bet;
        }

        public string Nick { get; private set; }
        public PLAYER_LABEL Label { get; set; }
        public PLAYER_ACTION Action { get; set; }

        public long Stack { get; private set; }
        public long Bet { get; set; }
    }
}
