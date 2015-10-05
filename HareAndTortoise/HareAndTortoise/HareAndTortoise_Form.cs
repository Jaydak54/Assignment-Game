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

namespace HareAndTortoise {
    public partial class HareAndTortoise_Form : Form {

        const int NUM_OF_ROWS = 8;
        const int NUM_OF_COLUMNS = 7;

        public HareAndTortoise_Form() {
            InitializeComponent();
            HareAndTortoise_Game.SetUpGame();
            ResizeGameBoard();
            SetUpGuiGameBoard();
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

            column = 0;
            row = 0;
            column = number % NUM_OF_COLUMNS;
            row = number / NUM_OF_COLUMNS;
            bool odd_row = row % 2 == 0; // check for every second row
            if (odd_row)
            {
                column = number - row * NUM_OF_COLUMNS; // set column if odd row
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

        private void splitContainer_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }//end class 
} //end namespace
