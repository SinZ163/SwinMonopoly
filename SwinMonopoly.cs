using System;
using SwinGameSDK;
using SwinMonopoly.Spaces;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.IO;
using System.Text;

namespace SwinMonopoly
{
    public static class SwinMonopoly
    {
        [DllImport("kernel32.dll",
            EntryPoint = "GetStdHandle",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll",
            EntryPoint = "AllocConsole",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();
        private const int STD_OUTPUT_HANDLE = -11;
        private const int MY_CODE_PAGE = 437;
        private static void InitConsole()
        {
            AllocConsole();
            IntPtr stdHandle = GetStdHandle(STD_OUTPUT_HANDLE);
            SafeFileHandle safeFileHandle = new SafeFileHandle(stdHandle, true);
            FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);
            Encoding encoding = System.Text.Encoding.GetEncoding(MY_CODE_PAGE);
            StreamWriter standardOutput = new StreamWriter(fileStream, encoding);
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }
       

        public static int HouseCount;
        public static int HotelCount;

        public static void Main()
        {
            InitConsole();
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

            var players = new Player[]
            {
                new Player("SinZ", Color.Blue),
                new Player("Yoshi2", Color.Red),
                new Player("SpiderNight", Color.Green),
                new Player("OvergrownOrange", Color.Orange)
            };

            var random = new Random();

            SwinGame.Delay(3000);
            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(300,300);

                var i = -1;
                foreach(var player in players)
                {
                    i++;

                    if (player.Alive)
                        player.Space += random.Next(1, 7) + random.Next(1, 7);
                    var x = 1000 + 200 * i % 2;
                    var y = 300 * i / 2;
                    try
                    {
                        if (player.Alive)
                        {
                            board[player.Space].OnLand(player);
                            SwinGame.DrawText(board[player.Space].Name, Color.Black, x, 30 + y);
                        }
                        else
                        {
                            SwinGame.DrawText($"D E A D", Color.Red, x, 30 + y);
                        }
                    }
                    catch (NotImplementedException)
                    {
                        SwinGame.DrawText($"Oops", Color.Red, x, 50 + y);
                    }
                    catch (NullReferenceException)
                    {
                        SwinGame.DrawText($"This doesn't exist yet.", Color.Red, x, 50 + y);
                    }
                    catch (Exception)
                    {
                        player.Alive = false;
                    }
                    finally
                    {
                        SwinGame.DrawRectangle(player.Color, x, y, 200, 150);
                        SwinGame.DrawText(player.Nickname, Color.Black, x, 10 + y);
                        SwinGame.DrawText($"{player.Space:D2}", Color.Black, x, 75 + y);
                        SwinGame.DrawText($"{player.Money:0,0}", Color.Green, x, 100 + y);
                    }
                }
                for (var j = 0; j < 40; j++)
                {
                    float x = 0;
                    float y = 0;
                    float width = 100;
                    float height = 100;

                    if (j < 11)
                    {
                        height = 200;
                        y = 1100;
                        if (j != 10)
                            x = 1100 - j * 100;
                    }
                    else if (j < 21)
                    {
                        width = 200;
                        x = 0;
                        if (j != 20)
                            y = 1100 - ((j%10) * 100);
                    }
                    else if (j < 31)
                    {
                        height = 200;
                        y = 0;
                        x = 100 + (j-20) * 100;
                    }
                    else
                    {
                        width = 200;
                        x = 1100;
                        y = 100 + (j%10) * 100;
                    }
                    if (j % 10 == 0)
                    {
                        width = 200;
                        height = 200;
                    }
                    x *= 0.7f;
                    y *= 0.7f;
                    width *= 0.7f;
                    height *= 0.7f;
                    SwinGame.DrawRectangle(Color.Black, x, y, width, height);
                    //Console.WriteLine($"I: {j} X: {x} Y: {y}");
                    switch (board[j])
                    {
                        //case RailroadProperty rProp:
                        case Property prop:
                            SwinGame.DrawText(prop.Name, Color.Black, x+2, y+2);
                            if (prop.owner != null)
                            {
                                SwinGame.DrawRectangle(prop.owner.Color, x + 1, y + 1, width - 2, height - 2);
                            }
                            break;
                        case ISpace space:
                            SwinGame.DrawText(space.Name, Color.Black, x, y);
                            break;
                        default:
                            SwinGame.DrawText("?", Color.DarkRed, x+40, y+10);
                            break;
                    }
                    // Corners
                    //if (j % 10 == 0)
                    //{
                    //    switch(j)
                    //    {
                    //        case 0:
                    //            SwinGame.DrawRectangle(Color.Black, 1100, 300+1100, 100, 100);
                    //            SwinGame.DrawText("GO", Color.Green, 1150, 1450);
                    //            break;
                    //        case 10:
                    //            SwinGame.DrawRectangle(Color.Black, 0, 300 + 1100, 100, 100);
                    //            SwinGame.DrawText("JAIL", Color.Purple, 50, 1450);
                    //            break;
                    //        case 20:
                    //            SwinGame.DrawRectangle(Color.Black, 0, 300, 100, 100);
                    //            SwinGame.DrawText("Free Parking", Color.Red, 50, 350);
                    //            break;
                    //        case 30:
                    //            SwinGame.DrawRectangle(Color.Black, 1100, 300, 100, 100);
                    //            SwinGame.DrawText("GOTO Jail", Color.Purple, 1150, 350);
                    //            break;
                    //    }
                    //}
                }            

                SwinGame.Delay(500);

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}