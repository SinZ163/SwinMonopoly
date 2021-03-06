using System;
using SwinGameSDK;
using SwinMonopoly.Spaces;

namespace SwinMonopoly
{
    public static class SwinMonopoly
    {
        public static int HouseCount;
        public static int HotelCount;

        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("SwinMonopoly", 1440, 900);
            //SwinGame.ShowSwinGameSplashScreen();
            var board = new ISpace[40];
            board[0] = new GOSpace();
            board[1] = new HousingProperty(Property.PropertySets.Brown, "Mediterranean Avenue", 60, 2, 10, 30, 90, 160, 250);
            //TODO: Community chest
            board[3] = new HousingProperty(Property.PropertySets.Brown, "Baltic Avenue", 60, 4, 20, 60, 180, 320, 450);
            board[4] = new TaxSpace(TaxSpace.TaxType.Income);
            board[5] = new RailroadProperty("Reading Railroad");
            board[6] = new HousingProperty(Property.PropertySets.Teal, "Oriental Avenue", 100, 6, 30, 90, 270, 400, 550);
            board[7] = new HousingProperty(Property.PropertySets.Teal, "Vermont Avenue", 100, 6, 30, 90, 270, 400, 550);
            //TODO: Chance
            board[9] = new HousingProperty(Property.PropertySets.Teal, "Connecticut Avenue", 120, 8, 40, 100, 300, 450, 600);
            board[10] = new JailSpace();
            board[11] = new HousingProperty(Property.PropertySets.Magenta, "St. Charles Place", 140, 10, 50, 150, 450, 625, 750);
            board[12] = new UtilityProperty(UtilityProperty.UtilityType.Electric);
            board[13] = new HousingProperty(Property.PropertySets.Magenta, "States Avenue", 140, 10, 50, 150, 450, 625, 750);
            board[14] = new HousingProperty(Property.PropertySets.Magenta, "Virginia Avenue", 160, 12, 60, 180, 500, 700, 900);
            board[15] = new RailroadProperty("Pennsylyania Railroad");
            board[16] = new HousingProperty(Property.PropertySets.Orange, "St. James Place", 180, 14, 70, 200, 550, 750, 950);
            //TODO: Community Chest
            board[18] = new HousingProperty(Property.PropertySets.Orange, "Tennessee Avenue", 180, 14, 70, 200, 550, 750, 950);
            board[19] = new HousingProperty(Property.PropertySets.Orange, "New York Avenue", 200, 16, 80, 220, 600, 800, 1000);
            board[20] = new FreeParkingSpace();
            board[21] = new HousingProperty(Property.PropertySets.Red, "Kentucky Avenue", 220, 18, 90, 250, 700, 875, 1050);
            //TODO: Chance
            board[23] = new HousingProperty(Property.PropertySets.Red, "Indiana Avenue", 220, 18, 90, 250, 700, 875, 1050);
            board[24] = new HousingProperty(Property.PropertySets.Red, "Illinois Avenue", 240, 20, 100, 300, 750, 925, 1100);
            board[25] = new RailroadProperty("B & O Railroad");
            board[26] = new HousingProperty(Property.PropertySets.Yellow, "Atlantic Avenue", 260, 22, 110, 330, 800, 950, 1150);
            board[27] = new HousingProperty(Property.PropertySets.Yellow, "Ventnor Avenue", 260, 22, 110, 330, 800, 950, 1150);
            board[28] = new UtilityProperty(UtilityProperty.UtilityType.Water);
            board[29] = new HousingProperty(Property.PropertySets.Yellow, "Marvin Gardens", 280, 24, 120, 360, 850, 1025, 1200);
            board[30] = new GOTOJailSpace();
            board[31] = new HousingProperty(Property.PropertySets.Green, "Pacific Avenue", 300, 26, 130, 390, 900, 1100, 1275);
            board[32] = new HousingProperty(Property.PropertySets.Green, "North Carolina Avenue", 300, 26, 130, 390, 900, 1100, 1275);
            //TODO: Community Chest
            board[34] = new HousingProperty(Property.PropertySets.Green, "Pennsylyania Avenue", 320, 28, 150, 450, 1000, 1200, 1400);
            board[35] = new RailroadProperty("Short Line");
            //TODO: Chance
            board[37] = new HousingProperty(Property.PropertySets.Blue, "Park Place", 350, 35, 175, 500, 1100, 1300, 1500);
            board[38] = new TaxSpace(TaxSpace.TaxType.Luxury);
            board[39] = new HousingProperty(Property.PropertySets.Blue, "Boardwalk", 400, 50, 200, 600, 1400, 1700, 2000);

            
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0,0);
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}