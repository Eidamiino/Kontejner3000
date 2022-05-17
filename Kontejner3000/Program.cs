using System;
using System.Collections.Generic;

namespace Kontejner3000
{
	internal class Program
	{
		public static List<Box> Boxes = new List<Box>();
		static void Main(string[] args)
		{
			for (int hroch = 0; hroch < 20; hroch++)
			{
				var box = Helpers.GenerateRandomBox();
				Boxes.Add(box);
				Console.WriteLine(box);
			}
			Container container = new Container(1000,10,100,100);

			Container.AddBoxesUntilFull(container, Boxes);
		}
	}
}
