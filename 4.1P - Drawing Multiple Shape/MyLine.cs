using System;
using SplashKitSDK;

namespace DrawingProgram
{
	public class MyLine : Shape
	{
        private float _endX, _endY;

        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            X = startX;
            Y = startY;
            _endX = endX;
            _endY = endY;
        }

        public MyLine() : this(Color.RandomRGB(255), 0, 0, 10, 10)
		{
		}

        public float EndX
        {
            get
            {
                return _endX;
            }
            set
            {
                _endX = value;
            }
        }

        public float EndY
        {
            get
            {
                return _endY;
            }
            set
            {
                _endY = value;
            }
        }



        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.DrawLine(color, X, Y, _endX, _endY);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawLine(color, X, Y, _endX + 5, _endY + 5);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, _endX, _endY));
        }
    }
}

