using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Square_Class_Library;
using System.Drawing;

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
    }


}
