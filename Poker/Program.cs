using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using school.events;

namespace Poker
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());

            /*Deck deck = new Deck();
            HandAnalyzer analyzer = new HandAnalyzer();

            List<Card> handCards = new List<Card>();
            List<Card> tableCards = new List<Card>();
            List<Card> hand = new List<Card>();

            HAND handType;

            try
            {
                handCards.Add(deck.getNextCard());
                handCards.Add(deck.getNextCard());
                handCards.Add(deck.getNextCard());
                handCards.Add(deck.getNextCard());
                handCards.Add(deck.getNextCard());

                handType = analyzer.Analyze(hand, handCards, tableCards, 5);

                if (handType != HAND.UNDEFINED)
                {
                    Console.WriteLine(analyzer.getHandAsString(handType));

                    foreach (Card c in hand)
                        Console.Write(c);

                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            var dealer = new CarDealer();

            var michael = new Consumer("Michael");
            dealer.NewCarInfo += michael.NewCarIsHere;

            dealer.NewCar("Ferrari");

            var sebastian = new Consumer("Sebastian");
            dealer.NewCarInfo += sebastian.NewCarIsHere;

            dealer.NewCar("Mercedes");

            dealer.NewCarInfo -= michael.NewCarIsHere;

            dealer.NewCar("Red Bull Racing");*/


            Game poker = new Game();
            Controller controller = new Controller(poker);
            View view = new View();
            poker.NewState += view.UpdateStateInfo;

            poker.addPlayer(new Player("sebastian", 1000));
            poker.addPlayer(new Player("bernd", 1000));
            poker.addPlayer(new Player("sascha", 1000));
            poker.addPlayer(new Player("matthias", 1000));
            poker.addPlayer(new Player("carsten", 1000));
            poker.addPlayer(new Player("thomas", 1000));

            try
            {
                poker.start();
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
                return;
            }

            controller.run();

            Console.ReadLine();

        }
    }
}
