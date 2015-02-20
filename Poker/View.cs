using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class View
    {
        public void UpdateStateInfo(object sender, GameStateEventArgs e)
        {
            Console.WriteLine("State: " + e.State);
        }
    }
}
