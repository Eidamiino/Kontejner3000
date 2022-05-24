using System;
using System.Collections.Generic;
using ConsoleTables;
using Kontejner3000.Models;

namespace Kontejner3000
{
	internal class Program
	{
		public const int ShipAmount = 6;
		public const int AmountOfBoxes = 50;
		public static List<Box> Boxes = new List<Box>();
		public static List<Container> Containers = new List<Container>();
		static void Main(string[] args)
		{
			AddBoxesUntilFull(AmountOfBoxes, 0, null);
			Port port = new Port(ShipAmount);
			port.ShipDistance = port.GetRandomArray(port.ShipDistance);
			port.AddShips();
			port.Ships[1].AddAllContainers();

			while (true)
			{
				Console.WriteLine($"Enter your choice:\n1. Print all containers\t\t2. Move container\t\t3. Unload container to dock");
				Console.Write($"Your input: ");
				int input = Convert.ToInt32(Console.ReadLine());
				switch (input)
				{
					case 1:
						{
							ConsoleTable table = new ConsoleTable("ShipID", "ContainerID", "Total Boxes", "Total Weight");
							foreach (Container container in Containers)
							{
								Helpers.AddContainerInfoIntoTable(table, container);
							}
							table.Write();

							Console.WriteLine($"All available ships:");
							foreach (string id in Ship.ShipIds)
							{
								Console.WriteLine($"{id}");
							}
						}
						break;
					case 2:
						{
							string containerId, shipId;
							do
							{
								Console.WriteLine($"Enter a containerID to move:");
								containerId = Console.ReadLine();
							} while (Container.ContainerIds.Contains(containerId) == false);
							do
							{
								Console.WriteLine($"Enter a shipIP to move container into:");
								shipId = Console.ReadLine();
							} while (Ship.ShipIds.Contains(shipId) == false);

							port.MoveContainer(containerId, shipId);
							Console.WriteLine($"Container has been moved to selected ship!\n");
						}
						break;
					case 3:
						{
							string containerId;
							do
							{
								Console.WriteLine($"Enter a containerID to unload:");
								containerId = Console.ReadLine();
							} while (Container.ContainerIds.Contains(containerId) == false);

							port.MoveContainer(containerId, port.Ships[0].ShipId);
							Console.WriteLine($"Container has been moved to dock!\n");
						}
						break;
					default:
					{
						Console.WriteLine($"Zadej spravnou volbu z nabidky!!!");
					}
						break;
				}
			}



		}
		private static void AddBoxesUntilFull(int remainingBoxes, int startingBox, Box inputBox)
		{
			Container container = CreateNewContainer();
			Containers.Add(container);
			for (int i = startingBox; i < remainingBoxes; i++)
			{
				Box box = GetBox(inputBox);
				Boxes.Add(box);
				//Console.WriteLine(box);
				if (!container.AddBox(box))
				{
					//Console.WriteLine("The container is full \n");
					Box remainedBox = null;
					if (box.Volume < 100000)
						remainedBox = box;
					Boxes.Remove(box);
					AddBoxesUntilFull(remainingBoxes, i, remainedBox);
					break;
				}
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
			return new Container(1000, 10, 100, 100);
		}
	}
}
