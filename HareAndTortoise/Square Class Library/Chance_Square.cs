using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player_Class_Library;

namespace Square_Class_Library
{
    public class Chance_Square : Square
    {
        public Chance_Square(string name, int number) : base(name, number)
        {

        }

        public override void EffectOnPlayer(Player who) {
            Random randint = new Random();
            if (randint.Next(2) == 0) {
                who.Add(50);
            } else {
                who.Deduct(50);
            }
        }
    }
}
