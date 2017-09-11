using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly
{
    class Chance
    {
        private static Chance chance;

        public static Chance Instance
        {
            get
            {
                if (chance is null)
                {
                    chance = new Chance();
                }
                return chance;
            }
        }
    }
}
