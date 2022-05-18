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
			Container container = new Container(1000, 10, 100, 100);

			Console.WriteLine("List of boxes:");
			for (int hippo = 0; hippo < AmountOfBoxes; hippo++)
			{
				var box = Helpers.GenerateRandomBox();
				Boxes.Add(box);
				Console.WriteLine(box);

				container.AddBox(Boxes[hippo]);
				if (container.IsBoxTooBig(Boxes[hippo]))
				{
					Console.WriteLine("The container is full!");
					break;
				}
				container.PrintFreeSpace();
			}
			Console.WriteLine($"Amount of boxes added: {Boxes.Count}");
		}
	}
}
