using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Player_Class_Library;
using Board_Class_Library;
using Square_Class_Library;
using Die_Class_Library;
using System.Diagnostics;

namespace HareAndTortoise {
    public static class HareAndTortoise_Game {

        private static int numberOfPlayers = 6;
        private static string[] playerNames = {"One", "Two", "Three", "Four", "Five", "Six"};
        private static Brush[] playerColours = {Brushes.Black, Brushes.Red, Brushes.Gold, Brushes.GreenYellow, Brushes.Fuchsia, Brushes.BlueViolet};

        private static BindingList<Player> players = new BindingList<Player>();
        public static BindingList<Player> Players {
            get {
                return players;
            }
        }

        public static void SetUpGame(){

            Board.SetUpBoard();
            SetUpPlayers();
            //more code to be added later
        }// end SetUpGame

        private static void SetUpPlayers()
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Player newPlayer = new Player(playerNames[i], Board.StartSquare());
                newPlayer.PlayerTokenColour = playerColours[i];
                players.Add(newPlayer);
            }
        } 

        public static void PlayOneRound()
        {
            Die die1 = new Die();
            Die die2 = new Die();

            int moveAmount;

            for (int i = 0; i < Players.Count(); i++)
            {
                // Rolling dice and moving player
                Players[i].RollDice(die1, die2, out moveAmount);
                // Announcing player results
                Trace.WriteLine(String.Format("Player {0} rolled a {1}!",
                Players[i].Name, moveAmount));
            }
            Trace.WriteLine("");

        }
        // MORE METHODS TO BE ADDED HERE LATER

        public static void EndCheck()
        {
            int[] money;
            string[] playerNumber;
            Array[] info;

            money = new int[6];
            playerNumber = new string[6];
            info = new Array[2];
            for (int i = 0; i < numberOfPlayers; i++)
                if (Players[i].Location == Board.GetGameBoardSquare(56))
                {
                    for (int j = 0; j < numberOfPlayers; j++)
                    {
                        money[j] = Players[j].Money;
                        playerNumber[j] = Players[i].Name;

                        info[0] = money;
                        info[1] = playerNumber;

                        Array.Sort(info);

                        for (int k = 0; k < numberOfPlayers; k++)
                        {
                            //if ( == money[k])
                            {
                                Players[k].HasWon = true;
                            }
                        }
                    }
                }
        }

        public static void OutputAllPlayerDetails()
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                OutputIndividualDetails(Players[i]);
            }
        } // end OutputAllPlayerDetails
          /// <summary>
          /// Outputs a player's current location and amount of money
          /// pre: player's object to display
          /// post: displayed the player's location and amount
          /// </summary>
          /// <param name="who">the player to display</param>
        public static void OutputIndividualDetails(Player who)
        {
            Square playerLocation = who.Location;
            Trace.WriteLine(String.Format("Player {0} on square {1} with {2:C}",
            who.Name, playerLocation.GetName(), who.Money));
        }// end OutputIndividualDetails

    }//end class
}//end namespace
