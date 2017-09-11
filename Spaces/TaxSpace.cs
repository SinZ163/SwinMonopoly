using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly.Spaces
{
    class TaxSpace : ISpace
    {
        public enum TaxType
        {
            Income,
            Luxury
        }

        public TaxType Type { get; }

        public string Name { get; }

        public TaxSpace(TaxType type)
        {
            Type = type;
            switch(Type)
            {
                case TaxType.Luxury:
                    Name = "Luxury Tax";
                    break;
                case TaxType.Income:
                    Name = "Income Tax";
                    break;
            }
        }

        public void OnLand(Player person)
        {
            int value = 0;
            switch(Type)
            {
                case TaxType.Income:
                    value = 200;
                    break;
                case TaxType.Luxury:
                    value = 100;
                    break;
            }
            //TODO: Make sure they pay up
            person.Charge(value);
        }
    }
}
