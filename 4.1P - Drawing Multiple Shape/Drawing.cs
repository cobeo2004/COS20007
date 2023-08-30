using System;
using SplashKitSDK;
using System.Collections.Generic;
namespace DrawingProgram
{
	public class Drawing
	{
        private readonly List<Shape> _shapes;
		private Color _background;

        public Drawing(Color background)
		{
			_shapes = new List<Shape>();
			_background = background;
		}

		public Drawing() : this(Color.White) { }

		public List<Shape> SelectedShapes
		{
			get
			{
				List<Shape> _selectedShapes = new List<Shape>();
				foreach(Shape s in _shapes)
				{
					if (s.Selected)
						_selectedShapes.Add(s);
				}

				return _selectedShapes;
			}
		}

		public int ShapeCount
		{
			get
			{
				return _shapes.Count;
			}
		}

		public Color Background
		{
			get
			{
				return _background;
			}

			set
			{
				_background = value;
			}
		}

		public void Draw()
		{
			SplashKit.ClearScreen(_background);
			foreach(Shape s in _shapes)
			{
				s.Draw();
			}

		}
		public void SelectShapesAt(Point2D point)
		{
			foreach(Shape s in _shapes)
			{
				s.Selected = s.IsAt(point);
			}
		}
		public void AddShape(Shape s)
		{
			_shapes.Add(s);
		}
		public void RemoveShape(Shape s)
		{
			_shapes.Remove(s);
		}
	}
}

