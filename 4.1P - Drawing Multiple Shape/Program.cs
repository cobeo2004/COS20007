using System;
using SplashKitSDK;
using DrawingProgram;

namespace DrawingMultipleShape
{
    public class Program
    {
        private const int _width = 800;
        private const int _height = 600;
        private const string _title = "DrawingShape";

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
            Window window = new Window(_title, _width, _height);
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
                if(SplashKit.MouseDown(MouseButton.LeftButton))
                {
                    switch(kindToAdd)
                    {
                        case(ShapeKind.Rectangle):
                            MyRectangle rectangle = new MyRectangle();
                            rectangle.X = SplashKit.MouseX();
                            rectangle.Y = SplashKit.MouseY();
                            drawing.AddShape(rectangle);
                            break;
                        case (ShapeKind.Circle):
                            MyCircle circle = new MyCircle();
                            circle.X = SplashKit.MouseX();
                            circle.Y = SplashKit.MouseY();
                            drawing.AddShape(circle);
                            break;
                        case (ShapeKind.Line):
                            MyLine line = new MyLine();
                            line.X = SplashKit.MouseX();
                            line.Y = SplashKit.MouseY();
                            drawing.AddShape(line);
                            break;

                    }
                }

                if(SplashKit.MouseDown(MouseButton.RightButton))
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
