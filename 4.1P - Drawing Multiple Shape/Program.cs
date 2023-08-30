using System;
using SplashKitSDK;
using DrawingProgram;

namespace DrawingMultipleShape
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main(string[] args)
        {
            Drawing drawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Rectangle;
            Window window = new Window("Drawing Shape 4.1P", 800, 600);
            while(!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                if (SplashKit.KeyDown(KeyCode.RKey))
                    kindToAdd = ShapeKind.Rectangle;
                if (SplashKit.KeyDown(KeyCode.CKey))
                    kindToAdd = ShapeKind.Circle;
                if (SplashKit.KeyDown(KeyCode.LKey))
                    kindToAdd = ShapeKind.Line;
                if(SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape chosenShape;
                    switch(kindToAdd)
                    {
                        case(ShapeKind.Rectangle):
                            chosenShape = new MyRectangle();
                            break;
                        case (ShapeKind.Circle):
                            chosenShape = new MyCircle();
                            break;
                        case (ShapeKind.Line):
                            chosenShape = new MyLine();
                            break;
                        default:
                            chosenShape = null!;
                            break;
                    }

                    if(chosenShape != null)
                    {
                        chosenShape.X = SplashKit.MouseX();
                        chosenShape.Y = SplashKit.MouseY();
                        drawing.AddShape(chosenShape);
                    }
                }

                if(SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SplashKit.MousePosition());
                }

                if(SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }

                if(SplashKit.KeyDown(KeyCode.EscapeKey))
                {
                    foreach(Shape s in drawing.SelectedShapes)
                    {
                        s.color = SplashKit.RandomRGBColor(255);
                    }
                }

                if(SplashKit.KeyDown(KeyCode.DeleteKey) || SplashKit.KeyDown(KeyCode.BackspaceKey))
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
