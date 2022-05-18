using System;
using System.Collections.Generic;

namespace Kontejner3000
{
	internal class Program
	{
		public const int AmountOfBoxes = 10;
		public static List<Box> Boxes = new List<Box>();
		static void Main(string[] args)
		{
			Console.WriteLine("List of boxes:");
			for (int hroch = 0; hroch < AmountOfBoxes; hroch++)
			{
				var box = Helpers.GenerateRandomBox();
				Boxes.Add(box);
				Console.WriteLine(box);
			}
			Container container = new Container(1000,10,100,100);

			Console.WriteLine("Adding boxes:");
			Container.AddBoxesUntilFull(container, Boxes);
		}
	}
}
