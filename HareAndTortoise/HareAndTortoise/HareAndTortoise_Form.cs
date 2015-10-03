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

            column = number % NUM_OF_COLUMNS;
            row = NUM_OF_ROWS - ((number - column) / NUM_OF_COLUMNS);
            //bool odd_row = row % 2 == 0;
            //if (odd_row) {
            //    column = NUM_OF_COLUMNS - column;
            //}
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


    }//end class 
} //end namespace
