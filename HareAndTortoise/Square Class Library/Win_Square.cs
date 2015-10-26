using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player_Class_Library;

namespace Square_Class_Library
{
    public class Win_Square : Square
    {
        public Win_Square(string name, int number): base(name, number)
        {

        }

        public override void EffectOnPlayer(Player who, ref bool gameOver, ref int movedExtra)
        {
            who.Add(15);
            who.CallRoll(ref gameOver, ref movedExtra, who);

        }
    }
}
