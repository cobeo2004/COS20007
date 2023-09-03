﻿using System;
using System.IO;
using SplashKitSDK;

namespace DrawingProgram
{
	public static class ExtensionMethods
	{
		public static int ReadInteger(this StreamReader reader)
		{
			return Convert.ToInt32(reader.ReadLine());
		}

		public static float ReadSingle(this StreamReader reader)
		{
            return Convert.ToSingle(reader.ReadLine());
        }

		public static Color ReadColor(this StreamReader reader)
		{
			return Color.RGBColor(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
		}

		public static void WriteColor(this StreamWriter writer, Color color)
		{
			writer.WriteLine("{0}\n{1}\n{2}", color.R, color.G, color.B);
		}
	}
}

