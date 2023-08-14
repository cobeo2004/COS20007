using System;
using SplashKitSDK;

namespace DrawingProgram
{
    public class Shape
    {
        private Color _color;
        private float _x, _y;
        private bool _selected;
        private int _width, _height;

        public Shape(int x, int y, Color color)
        {
            _color = color;
            _x = x;
            _selected = false;
            _y = y;
            _width = 100;
            _height = 100;

        }

        public Shape() : this(0, 0, SplashKit.RGBColor(255, 0, 255)) { }

        public Color color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        public void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public bool IsAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(_x, _y, _width, _height));
        }

        public void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, _x - 2, _y - 2, _width + 4, _height + 4);
        }
    }
}

