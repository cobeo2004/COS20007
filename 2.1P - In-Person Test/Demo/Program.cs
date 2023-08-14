using System;
using SplashKitSDK;

namespace Demo
{
    public class Program
    {
        public static void Main()
        {
            const int width = 800;
            const int height = 600;
            Window window = new Window("Demo Window for Task 2.1P", width, height);

            while(!SplashKit.WindowCloseRequested("Demo Window for Task 2.1P"))
            {
                SplashKit.ClearScreen();
                SplashKit.ProcessEvents();
                SplashKit.RefreshScreen();
            }
        }
    }
}
