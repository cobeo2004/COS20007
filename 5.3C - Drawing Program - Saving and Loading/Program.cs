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

        private const string fPath = "/Users/cobeo/Desktop/Codes/SchoolWork/COS20007 - OOP/5.3C - Drawing Program - Saving and Loading/TestDrawing.txt";

        public static void Main(string[] args)
        {
            Drawing drawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Rectangle;
            Window window = new Window("Drawing Shape 5.3C", 800, 600);
            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                if (SplashKit.KeyDown(KeyCode.RKey))
                    kindToAdd = ShapeKind.Rectangle;
                if (SplashKit.KeyDown(KeyCode.CKey))
                    kindToAdd = ShapeKind.Circle;
                if (SplashKit.KeyDown(KeyCode.LKey))
                    kindToAdd = ShapeKind.Line;
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape chosenShape;
                    switch (kindToAdd)
                    {
                        case (ShapeKind.Rectangle):
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

                    if (chosenShape != null)
                    {
                        chosenShape.X = SplashKit.MouseX();
                        chosenShape.Y = SplashKit.MouseY();
                        drawing.AddShape(chosenShape);
                    }
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.KeyDown(KeyCode.EscapeKey))
                {
                    foreach (Shape s in drawing.SelectedShapes)
                    {
                        s.Color = SplashKit.RandomRGBColor(255);
                    }
                }

                if (SplashKit.KeyDown(KeyCode.DeleteKey) || SplashKit.KeyDown(KeyCode.BackspaceKey))
                {
                    foreach (Shape s in drawing.SelectedShapes)
                    {
                        drawing.RemoveShape(s);
                    }
                }

                if (SplashKit.KeyDown(KeyCode.SKey))
                    drawing.Save(fPath);
                if (SplashKit.KeyDown(KeyCode.OKey))
                {
                    try
                    {
                        drawing.Load(fPath);
                    } catch(Exception e)
                    {
                        Console.Write("Error: {0}", e.Message);
                    }
                }
                    
                drawing.Draw();
                SplashKit.RefreshScreen();
            }

        }
    }
}
