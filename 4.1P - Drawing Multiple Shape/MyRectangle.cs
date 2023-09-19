﻿using System;
using SplashKitSDK;

namespace DrawingProgram
{
	public class MyRectangle : Shape
	{
        private int _width;
        private int _height;

        public MyRectangle(Color color, float x, float y, int width, int height) : base(color, 0, 0, 100, 100)
        {
            X = x;
            Y = y;
            _width = width;
            _height = height;
        }

        public MyRectangle() : this(Color.Green, 0, 0, 100, 100) { }

        public new int Width
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

        public new int Height
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

        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.FillRectangle(color, X, Y, _width, _height);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(X, Y, _width, _height));
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
        }
    }
}

