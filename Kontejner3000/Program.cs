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
			Box inputBox = null;
			AddBoxesUntilFull(AmountOfBoxes,0, inputBox);
			foreach (var con in Containers)
			{
				Console.WriteLine($"Container {con.StorageId} contains {con.GetContent().Count} boxes");
			}
			
		}
		private static void AddBoxesUntilFull(int remainingBoxes, int startingBox, Box inputBox)
		{
			Container container = CreateNewContainer();
			Containers.Add(container);
			for (int i = startingBox; i < remainingBoxes; i++)
			{
				Box box;
				if (inputBox == null)
					box = Helpers.GenerateRandomBox();
				else
					box = inputBox;
				Boxes.Add(box);
				Console.WriteLine(box);

				if (container.IsBoxTooBig(Boxes[i]))
				{
					Console.WriteLine("The container is full \n");
					Box remainedBox = box;
					Boxes.RemoveAt(i);
					AddBoxesUntilFull(remainingBoxes,i,remainedBox);
					break;
				}
				container.AddBox(Boxes[i]);
				Console.WriteLine(container.GetFreeSpace());
				inputBox = null;
			}
		}

		private static Container CreateNewContainer()
		{
			Container container = new Container(1000, 10, 100, 100);
			return container;
		}
	}
}
