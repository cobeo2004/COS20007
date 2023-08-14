using System;
using SplashKitSDK;

namespace DrawingProgram
{
	public class MyCircle : Shape
	{
		private int _radius;

        public MyCircle(Color color, float x, float y, int radius) : base(color)
        {
            X = x;
            Y = y;
            _radius = radius;
        }

        public MyCircle() : this(Color.RandomRGB(255), 0, 0, 30)
		{
		}

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public override void Draw()
        {
            if(Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(color, X, Y, _radius);
        }

        public override bool IsAt(Point2D pt)
        {
            //c = sqrt(a^2 + b^2)
            double a = pt.X - X;
            double b = pt.Y - Y;
            double c = Math.Sqrt((a * a) + (b * b));
            return c < _radius;
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 4);
        }
    }
}

