using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Square_Class_Library;
using Board_Class_Library;
using System.Diagnostics;

namespace HareAndTortoise {
    public partial class HareAndTortoise_Form : Form {

        const int NUM_OF_ROWS = 8;
        const int NUM_OF_COLUMNS = 7;

        public HareAndTortoise_Form() {
            InitializeComponent();
            HareAndTortoise_Game.SetUpGame();
            ResizeGameBoard();
            SetUpGuiGameBoard();
            dataGridView.DataSource = HareAndTortoise_Game.Players;
            UpdatePlayerSquares(true);
            Trace.Listeners.Add(new ListBoxTraceListener(listBox1));
        }


        private void SetUpGuiGameBoard() {
            int row;
            int column;
            for (int i = Board.START_SQUARE; i <= Board.FINISH_SQUARE; i++) {
                Square position = Board.GetGameBoardSquare(i);
                SquareControl control = new SquareControl(position, HareAndTortoise_Game.Players);
                if (i == Board.START_SQUARE || i == Board.FINISH_SQUARE) {
                    control.BackColor = Color.BurlyWood;
                }

                
                MapSquareToTablePanel(i, out column, out row);
                // Now adding the square controllers to each box in gameBoardPanel
                gameBoardPanel.Controls.Add(control, column, row);
            }
        }//end SetUpGuiGameBoard()

        private static void MapSquareToTablePanel(int number, out int column, out int row)
        {
            row = number / NUM_OF_COLUMNS;
            bool odd_row = row % 2 == 0; // check for every second row
            if (odd_row)
            {
                column = number % NUM_OF_COLUMNS; // set column if odd row
            }
            else
            {
                column = NUM_OF_COLUMNS * (row + 1) - 1 - number; // set column for every other row
            }

            row = NUM_OF_ROWS - 1 - row; // flip the board so square progress the opposite way
        }

        private void ResizeGameBoard() {
            const int SQUARE_SIZE = SquareControl.SQUARE_SIZE;
            int currentHeight = gameBoardPanel.Size.Height;
            int currentWidth = gameBoardPanel.Size.Width;
            int desiredHeight = SQUARE_SIZE * NUM_OF_ROWS;
            int desiredWidth = SQUARE_SIZE * NUM_OF_COLUMNS;
            int increaseInHeight = desiredHeight - currentHeight;
            int increaseInWidth = desiredWidth - currentWidth;
            this.Size += new Size(increaseInWidth, increaseInHeight);
            gameBoardPanel.Size = new Size(desiredWidth, desiredHeight);
        } //end ResizeGameBoard

        private void UpdatePlayerSquares(bool create) {
            int column;
            int row;
            for (int i = 0; i < HareAndTortoise_Game.Players.Count(); i++)
            {
                // Determine the square that the player is on
                Square playerSquare = HareAndTortoise_Game.Players[i].Location;
                int squareNo = playerSquare.GetNumber();
                // Get the SquareControl of that square
                MapSquareToTablePanel(squareNo, out column, out row);
                SquareControl control = (SquareControl)gameBoardPanel.GetControlFromPosition(column, row);
                if (create == true)
                {
                    // Update containsPlayers element which corresponds to this player
                    control.ContainsPlayers[i] = true;
                } else
                {
                    control.ContainsPlayers[i] = false;
                }
                
            }// end for loop
            // Redisplay the GUI board
            gameBoardPanel.Invalidate(true);

        }

        private void splitContainer_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDice_Click(object sender, EventArgs e)
        {
            UpdatePlayerSquares(false);
            HareAndTortoise_Game.PlayOneRound();
            UpdatePlayerSquares(true);
        }

        private void OutputPlayersDetails()
        {
            HareAndTortoise_Game.OutputAllPlayerDetails();
            listBox1.Items.Add("");
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
    }//end class 
} //end namespace
