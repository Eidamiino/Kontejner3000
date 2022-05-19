using System;
using System.Collections.Generic;
using ConsoleTables;

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
			ConsoleTable table = new ConsoleTable("ContainerID", "Total Boxes", "Total Weight");
			foreach (Container container in Containers)
			{
				container.AddContainerInfoIntoTable(table);
			}
			table.Write();

		}
		private static void AddBoxesUntilFull(int remainingBoxes, int startingBox, Box inputBox)
		{
			Container container = CreateNewContainer();
			Containers.Add(container);
			for (int i = startingBox; i < remainingBoxes; i++)
			{
				Box box;
				box = GetBox(inputBox);
				Boxes.Add(box);
				//Console.WriteLine(box);
				if (container.IsBoxTooBig(box))
				{
					//Console.WriteLine("The container is full \n");
					Box remainedBox = box;
					Boxes.Remove(box);
					AddBoxesUntilFull(remainingBoxes,i,remainedBox);
					break;
				}
				container.AddBox(box);
				
				//Console.WriteLine(container.GetFreeSpace());
				inputBox = null;
			}
		}

		private static Box GetBox(Box inputBox)
		{
			Box box;
			if (inputBox == null)
				box = Helpers.GenerateRandomBox();
			else
				box = inputBox;
			return box;
		}

		private static Container CreateNewContainer()
		{
			return new Container(1000, 10, 100, 100); ;
		}
	}
}
