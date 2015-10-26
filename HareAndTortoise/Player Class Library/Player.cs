using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Square_Class_Library;
using System.Drawing;
using Die_Class_Library;
using Board_Class_Library;

namespace Player_Class_Library
{

    public class Player
    {
        private string name;
        private int money;
        private bool hasWon;
        private Square location;
        private Image playerTokenImage;
        private Brush playerTokenColour;

        public Player()
        {
            throw new ArgumentException("Class instantiation syntax is invalid.");
        }

        public Player(string name, Square location)
        {
            this.name = name;
            this.location = location;
            money = 100;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }// End Name property

        public int Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }// End Money property

        public void Add(int amount) {
            money += amount;
        }

        public void Deduct(int amount) {
            if ((money - amount) >= 0) {
                money -= amount;
            } else {
                money = 0;
            }
        }

        public bool HasWon
        {
            get 
            {
                return hasWon;
            }
            set
            {
                hasWon = value;
            }
        }// End HasWon property

        public Square Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }// End Location property

        public Image PlayerTokenImage
        {
            get 
            {
                return playerTokenImage;
            }
            set
            {
                playerTokenImage = value;
            }
        }// End PlayerTokenImage property

        public Brush PlayerTokenColour
        {
            get 
            {
                return playerTokenColour;
            }
            set
            {
                playerTokenColour = value;
                playerTokenImage = new Bitmap(1, 1);
                using (Graphics g = Graphics.FromImage(playerTokenImage)) {
                    g.FillRectangle(playerTokenColour, 0, 0, 1, 1);
                }
            }
        }// End PlayerTokenColour property


        public void RollDice(Die die1, Die die2, ref int moveAmount, ref bool gameOver, ref int movedExtra, Player thisObject)
        {
            // Rolling dice
            moveAmount = moveAmount + die1.Roll() + die2.Roll();

            // getting current square number and incrementing it by dice roll
            int squareNo = location.GetNumber();
            int newSquare = squareNo + moveAmount;

            // check if player has moved onto or past finish
            if (newSquare >= Board.FINISH_SQUARE)
            {
                newSquare = Board.FINISH_SQUARE;
                gameOver = true;
            }
            else
            {
                gameOver = false;
            }

            // setting location to new square
            location = Board.GetGameBoardSquare(newSquare);

            // applying any effects of the square landed on
            location.EffectOnPlayer(this, ref gameOver, ref movedExtra);
            // add in Square.cs to return 0 in EffectOnPlayer and leave gameOver as it is

        }

        public void MoveSquares(int moveNumber, ref bool gameOver, ref int movedExtra)
        {
            int squareNo = location.GetNumber();
            int newSquare = squareNo + moveNumber;

            //If square is past finish, game ends
            if (newSquare >= Board.FINISH_SQUARE)
            {
                newSquare = Board.FINISH_SQUARE;
                gameOver = true;
            }
            else
            {
                gameOver = false;
            }

            //Increment MovedExtra by number of extra moves to make
            movedExtra = movedExtra + moveNumber;

            //Set location to newSquare
            location = Board.GetGameBoardSquare(newSquare);

            //Checking for any effects on new square on board
            location.EffectOnPlayer(this, ref gameOver, ref movedExtra);
        }

        public void CallRoll(ref bool gameOver, ref int movedExtra, Player who)
        {
            int movedFurtherExtra = 0;
            Die die1 = new Die();
            Die die2 = new Die();

            bool gameOver1 = gameOver;

            gameOver = gameOver1;

            RollDice(die1, die2, ref movedExtra, ref gameOver, ref movedFurtherExtra, who);

            movedExtra += movedFurtherExtra;

        }
    }
}
