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
			AddBoxesUntilFull(container, AmountOfBoxes,0);
			Console.WriteLine($"Amount of boxes added: {Boxes.Count}");
			
		}
		private static void AddBoxesUntilFull(Container container, int remainingBoxes, int startingBox)
		{
			for (int hippo = startingBox; hippo < remainingBoxes; hippo++)
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
					AddBoxesUntilFull(containerNew,remainingBoxes,hippo);
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
