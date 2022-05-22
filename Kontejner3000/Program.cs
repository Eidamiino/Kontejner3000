using System;
using System.Collections.Generic;
using ConsoleTables;

namespace Kontejner3000
{
	internal class Program
	{
		public const int ShipAmount = 6;
		public const int AmountOfBoxes = 20;
		public static List<Box> Boxes = new List<Box>();
		public static List<Container> Containers = new List<Container>();
		static void Main(string[] args)
		{
			AddBoxesUntilFull(AmountOfBoxes, 0, null);
			ConsoleTable table = new ConsoleTable("ContainerID", "Total Boxes", "Total Weight");
			foreach (Container container in Containers)
			{
				container.AddContainerInfoIntoTable(table);
			}
			table.Write();

			//kamo prisaham ze nam tady dali nejaky NP problem co to vole je pomoc

			//jsou tri classy: container, lod, port (pristav)
			//vytvori se novy port, v portu je *pocet* volnych mist ve kterych je *pocet* lodi
			//v portu muzou lode mezi sebou containery uvnitr lodi prenaset (nejakou metodou)
			//vsechna mista v portu jsou nahodny pocet metru vzdalena od sebe
			//pri prenaseni containeru je potreba znat doba jakou prenos trval, jeden metr odpovida 1 milisekunde
			//napr: mezi misty 1 a 2 je 100m a mezi 2 a 3 je 200m, takze prenos z 1 do 3 bude trvat 100 + 200 metru
			//tyhle vzdalenosti jsou ulozene v listu ve tride port

			Port port = new Port(ShipAmount);
			port.ShipDistance = port.GetRandomArray(port.ShipDistance);

			port.AddShips();
			foreach (var ship in port.Ships)
			{
				Console.WriteLine(ship);
			}

			port.Ships[0].AddContainer(Containers[1]);

			Console.WriteLine(port.Ships[2].ContainersInside.Count);
			port.MoveContainer(0, 0, 2);
			Console.WriteLine(port.Ships[2].ContainersInside.Count);

			foreach (var distance in port.ShipDistance)
			{
				Console.WriteLine($"hrosik {distance}");
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
					Box remainedBox = box;
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
			return new Container(1000, 10, 100, 100); ;
		}
	}
}
