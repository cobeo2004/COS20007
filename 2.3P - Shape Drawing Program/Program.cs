using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Shape myShape = new Shape();
            Window window = new Window("Shape Drawer", 800, 600);

            while(!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                /*The difference between SplashKit.MouseDown and SplashKit.MouseClicked is that, with MouseDown method you can hold left click of the mouse
                 * and drag the object, but MouseClicked method will only allows you to click but not drag the object
                 */
                
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                }

                if(myShape.IsAt(SplashKit.MousePosition()) && SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    myShape.color = Color.RandomRGB(255);
                }

                myShape.Draw();
                //Refresh The Screen
                SplashKit.RefreshScreen();
            }

            //Console.WriteLine("Program Ended, Thanks!");
        }
    }
}
