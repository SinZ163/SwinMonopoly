using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly
{
    interface ICard
    {
        string Name { get; }
        void OnDraw(Player person);
    }
}
