using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Player_Class_Library;
using Board_Class_Library;

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
        // MORE METHODS TO BE ADDED HERE LATER
        
    }//end class
}//end namespace
