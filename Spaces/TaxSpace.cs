using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly.Spaces
{
    //TODO: Figure out if this should be made generic with IncomeSpace
    //TODO: Makes DrawBoard more complex
    class TaxSpace : ISpace
    {
        public enum TaxType
        {
            Income,
            Luxury
        }

        public TaxType Type { get; }

        public TaxSpace(TaxType type)
        {
            Type = type;
        }

        public void DrawBoard()
        {
            throw new NotImplementedException();
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
