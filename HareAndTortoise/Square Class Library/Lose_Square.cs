using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player_Class_Library;

namespace Square_Class_Library
{
    public class Lose_Square : Square
    {
        public Lose_Square(string name, int number) : base(name, number)
        {

        }

        public override void EffectOnPlayer(Player who, ref bool gameOver, ref int movedExtra)
        {
            who.Deduct(25);
            who.MoveSquares(-3, ref gameOver, ref movedExtra);
        }
    }
}
