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

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetLocation(Square location)
        {
            this.location = location;
        }

        public Square GetLocation()
        {
            return location;
        }

        public Image GetPlayerTokenImage()
        {
            return playerTokenImage;
        }

        public Brush GetPlayerTokenColour()
        {
            return playerTokenColour;
        }

        public void SetPlayerTokenColour(Brush value){
            playerTokenColour = value;
            playerTokenImage = new Bitmap(1, 1);
            using(Graphics g = Graphics.FromImage(playerTokenImage)) {
                g.FillRectangle(playerTokenColour, 0, 0, 1, 1);
            }
        } //end SetPlayerTokenColour
    }


}
