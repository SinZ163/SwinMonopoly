using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly.Spaces
{
    interface ISpace
    {
        void DrawBoard();

        void OnLand(Player person);
    }
}
