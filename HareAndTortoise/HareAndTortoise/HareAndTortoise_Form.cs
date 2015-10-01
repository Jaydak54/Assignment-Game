using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HareAndTortoise {
    public partial class HareAndTortoise_Form : Form {

        const int NUM_OF_ROWS = 8;
        const int NUM_OF_COLUMNS = 7;

        public HareAndTortoise_Form() {
            InitializeComponent();
        //    HareAndTortoise_Game.SetUpGame();
        //    ResizeGameBaord()
            SetUpGuiGameBoard();
        }


        private void SetUpGuiGameBoard() {
        
        // for each square that is on the game board 
        //      obtain the Square object associated with the square
		//      create a SquareControl object (ie call Constructor)
        //      if the square is either Start square or Finish square
		//         set the BackColor of the SquareControl to BurlyWood
		//      otherwise do not set the BackColor
		//      Determine the correct position (cell) in the TablelayoutPanel of the square
		//      Add the SquareControl object to that position of the TableLayoutPanel
        
        }//end SetUpGuiGameBoard()


/*
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
 */


    }//end class 
} //end namespace
