using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly.Spaces
{
    interface ISpace
    {
        string Name { get; }

        void OnLand(Player person);
    }
}
