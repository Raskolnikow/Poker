using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Controller
    {
        public Controller(Game game, View view)
        {
            this.game = game;
            this.view = view;

            this.game.NewState += UpdateStateInfo;
        }

        public void run()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnTime;
            timer.Enabled = true;
        }

        private void UpdateStateInfo(object sender, GameStateEventArgs e)
        {
            view.UpdateStateInfo(sender, e);
        }

        private void OnTime(object sender, ElapsedEventArgs e)
        {
            game.goToNextState();
        }

        private Timer timer;
        private Game game;
        private View view;
    }
}
