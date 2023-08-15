using System;
using SplashKitSDK;

namespace DrawingProgram
{
    public class Program
    { 
        public static void Main()
        {
            Drawing drawing = new Drawing();
            Window window = new Window("Shape Drawing 3.3P", 800, 600);

            while(!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                //Draw Shape when click Left Button
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    int xPosition = (int) SplashKit.MouseX();
                    int yPosition = (int) SplashKit.MouseY();
                    drawing.AddShape(new Shape(xPosition, yPosition, Color.Black));
                }
                //Draw Outline (Selected shape) when click Right Button
                if(SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SplashKit.MousePosition());
                }
                //Randomly change color when click ESC
                if(SplashKit.KeyDown(KeyCode.EscapeKey))
                {
                    foreach(Shape s in drawing.SelectedShapes)
                    {
                        s.color = SplashKit.RandomRGBColor(255);
                    }
                }
                //Change background color when click Space
                if(SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }
                //Remove shape if press DEL or Backspace 
                if (SplashKit.KeyDown(KeyCode.DeleteKey) || SplashKit.KeyDown(KeyCode.BackspaceKey))
                {
                    foreach(Shape s in drawing.SelectedShapes)
                    {
                        drawing.RemoveShape(s);
                    }
                }
                drawing.Draw();
                SplashKit.RefreshScreen();
            }
        }
    }
}
