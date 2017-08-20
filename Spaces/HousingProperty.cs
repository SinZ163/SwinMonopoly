using System;

namespace SwinMonopoly.Spaces
{
    public class HousingProperty : Property
    {
        public enum PropertySets
        {
            Undefined = 0,
            Brown,
            Teal,
            Magenta,
            Orange,
            Red,
            Yellow,
            Green,
            Blue
        }
        public PropertySets Set { get; }

        /// <summary>
        /// The number of houses in this property.
        /// 5 houses is defined to be a hotel.
        /// </summary>
        public int HouseCount { get; private set; }
        public bool HasHotel { get => HouseCount == 5; }

        public readonly int BaseRent;
        public readonly int OneHouseValue;
        public readonly int TwoHouseValue;
        public readonly int ThreeHouseValue;
        public readonly int FourHouseValue;
        public readonly int HotelValue;

        public HousingProperty(PropertySets set, string name, int value, int baseRent, int oneHouse, int twoHouse, int threeHouse, int fourHouse, int hotel)
        {
            Name = name;
            Set = set;
            HouseCount = 0;

            PropertyValue = value;
            BaseRent = baseRent;
            OneHouseValue = oneHouse;
            TwoHouseValue = twoHouse;
            ThreeHouseValue = threeHouse;
            FourHouseValue = fourHouse;
            HotelValue = hotel;
        }

        public bool PurchaseHouse()
        {

            var price = 0;
            switch (Set)
            {
                case PropertySets.Brown:
                case PropertySets.Teal:
                    price = 50;
                    break;
                case PropertySets.Magenta:
                case PropertySets.Orange:
                    price = 100;
                    break;
                case PropertySets.Red:
                case PropertySets.Yellow:
                    price = 150;
                    break;
                case PropertySets.Green:
                case PropertySets.Blue:
                    price = 200;
                    break;
            }
            var success = owner.Charge(price);
            if (success)
            {
                if (SwinMonopoly.HouseCount > 0)
                {
                    SwinMonopoly.HouseCount -= 1;
                    if (HouseCount < 5)
                    {
                        HouseCount += 1;
                        return true;
                    }
                }
            }
            return false;
        }

        public override void DrawBoard()
        {
            throw new NotImplementedException();
        }

        public override void DrawCard()
        {
            throw new NotImplementedException();
        }

        public override void OnLand(Player person)
        {
            if (owner == person)
                return;

            var price = PropertyValue;
            switch (HouseCount)
            {
                case 1:
                    price = OneHouseValue;
                    break;
                case 2:
                    price = TwoHouseValue;
                    break;
                case 3:
                    price = ThreeHouseValue;
                    break;
                case 4:
                    price = FourHouseValue;
                    break;
                case 5:
                    price = HotelValue;
                    break;
            }

        }

        public override void Mortgage()
        {
            if (HouseCount == 0)
            {
                base.Mortgage();
            }
            else
            {
                throw new Exception("Unable to mortgage properties with houses or hotels on it");
            }
        }
    }
}
