using System;
using System.Collections.Generic;

namespace Kontejner3000
{
	internal class Program
	{
		public const int AmountOfBoxes = 20;
		public static List<Box> Boxes = new List<Box>();
		public static List<Container> Containers = new List<Container>();
		static void Main(string[] args)
		{
			Container container=CreateNewContainer();

			Console.WriteLine("List of boxes:");
			AddBoxesUntilFull(container, AmountOfBoxes);
			Console.WriteLine($"Amount of boxes added: {Boxes.Count}");
			Console.WriteLine(container);
		}
		private static void AddBoxesUntilFull(Container container, int remainingBoxes)
		{
			for (int hippo = 0; hippo < remainingBoxes; hippo++)
			{
				var box = Helpers.GenerateRandomBox();
				Boxes.Add(box);
				Console.WriteLine(box);

				if (container.IsBoxTooBig(Boxes[hippo]))
				{
					Console.WriteLine("The container is full!");
					Boxes.RemoveAt(hippo);
					Containers.Add(container);
					container.BoxesInside = Boxes;

					Container containerNew = CreateNewContainer();
					AddBoxesUntilFull(containerNew,remainingBoxes-hippo);
					break;
				}
				container.AddBox(Boxes[hippo]);
				container.PrintFreeSpace();
			}
		}

		private static Container CreateNewContainer()
		{
			Container container = new Container(1000, 10, 100, 100);
			return container;
		}
	}
}
