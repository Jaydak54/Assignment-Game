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
        public static int NumberOfPlayers
        {
            get
            {
                return numberOfPlayers;
            }
            set
            {
                numberOfPlayers = value;
            }
        }
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

        public static void RetrieveInfo()
        {

        }

        public static void PlayOneRound()
        {
            Die die1 = new Die();
            Die die2 = new Die();

            int moveAmount = 0;
            int movedExtra = 0;
            bool gameOver = false;
            bool playerReachedFinish = false;

            for (int i = 0; i < HareAndTortoise_Game.NumberOfPlayers; i++)
            {
                // Rolling dice and moving player
                Players[i].RollDice(die1, die2, ref moveAmount, ref playerReachedFinish, ref movedExtra, Players[i]);

                // Announcing player results
                Trace.WriteLine(String.Format("Player {0} rolled a {1}!",
                Players[i].Name, moveAmount));
                if (movedExtra > 0)
                {
                    Trace.WriteLine(String.Format("Player {0} moved an extra {1} spaces!",
                    Players[i].Name, movedExtra));
                }

                gameOver = gameOver || playerReachedFinish;
            }
            Trace.WriteLine("");
            if (gameOver == true)
            {
                List<int> winners = EndChecks();
                EndGame(winners);
            }

        }

        /*public static void DisableParse(bool disableParse, out bool runIt)
        {
            
            runIt = false;
            if (disableParse == true)
            {
                runIt = true; 
            }
            else
            {
                runIt = false;
            }
            
        }*/

        /*public static bool ButtonDisable()
        {
            bool disable;
            bool disableParse;
            DisableParse(true, out disableParse);
            Trace.WriteLine(String.Format(disableParse.ToString()));
            if (disableParse == true)
            {
                disable = true;
                return disable;
            }else
            {
                disable = false;
                return disable;
            }
        }*/

        public static void EndGame(List<int> winners)
        {
            // announce winners from given array
            if (winners.Count == 1) {
                Trace.WriteLine("\nAnd the winner is...\n");
            } else {
                Trace.WriteLine("\nAnd the winners are...\n");
            }

            foreach (int winner in winners) {
                string playerName = Players[winner].Name;
                int playerMoney = Players[winner].Money;
                Trace.WriteLine(String.Format("{0} with ${1}", playerName, playerMoney));
            }
            // disable roll dice button
            //currently disabled when player location >= FINISH_SQUARE in HareAndTortoise_Form
        }

        public static List<int> EndChecks()
        {
            // Array containing player money and player number
            int[][] playerInfo = OrderByMoney(GetPlayerInfo());
            List<int> winnerList = new List<int>();

            for (int i = 0; playerInfo[0][0] == playerInfo[i][0] && i < numberOfPlayers; i++)
            {
                winnerList.Add(playerInfo[i][1]);
                Players[playerInfo[i][1]].HasWon = true;
            }
            return winnerList;
        }

        /// <summary>
        /// Orders a given jagged array in a descending
        /// fashion based on values held within each
        /// array's 0'th position
        /// </summary>
        /// <param name="info">An array containing player info to be ordered</param>
        /// <returns>a jagged array, ordered in an descending fashion</returns>
        public static int[][] OrderByMoney(int[][] info)
        {
            int[][] orderedInfo = InitialiseInfoArray();
            int newMoney = 0; // container for sorting loop
            int newPlayer = 0; // as above
            bool sorted = false;
            bool sortedWithErrors; // will be true if sorting encountered a case where a number had to be moved

            while (!sorted)
            {
                sortedWithErrors = false;
                for (int i = 0; i < numberOfPlayers-1; i++)
                {
                    if (info[i][0] < info[i + 1][0])
                    {
                        // Swap money and player numbers
                        newMoney = info[i + 1][0];
                        newPlayer = info[i + 1][1];

                        info[i + 1][0] = info[i][0];
                        info[i + 1][1] = info[i][1];

                        info[i][0] = newMoney;
                        info[i][1] = newPlayer;

                        // mark this pass as having had errors (prompt another pass)
                        sortedWithErrors = sortedWithErrors || true;
                    }
                }
                sorted = !sortedWithErrors;
            }
            return info;
        }

        public static int[][] GetPlayerInfo()
        {
            int[][] info = InitialiseInfoArray();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                info[i][0] = Players[i].Money;
                info[i][1] = i;
            }
            return info;
        }

        public static int[][] InitialiseInfoArray()
        {
            int[][] info = new int[numberOfPlayers][];
            for (int i = 0; i < info.Length; i++)
            {
                info[i] = new int[2];
            } // end array initialisation

            return info;
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
