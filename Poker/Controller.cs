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
        public Controller(Game game)
        {
            this.game = game;
        }

        public void run()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnTime;
            timer.Enabled = true;
        }

        private void OnTime(object sender, ElapsedEventArgs e)
        {
            game.goToNextState();
        }

        private Timer timer;
        private Game game;
    }
}
