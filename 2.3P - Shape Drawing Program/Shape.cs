﻿using System;
using SplashKitSDK;
namespace ShapeDrawer
{
	public class Shape
	{
		private Color _color;
		private float _x, _y;
		private int _width, _height;

		public Shape()
		{
			_color = SplashKit.ColorGreen();
			_x = 0;
			_y = 0;
			_width = 100;
			_height = 100;

		}

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

		public void Draw()
		{
			SplashKit.FillRectangle(_color, _x, _y, _width, _height);
		}

		public bool IsAt(Point2D pt)
		{
			return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(_x,_y, _width, _height));
		}
	}
}

