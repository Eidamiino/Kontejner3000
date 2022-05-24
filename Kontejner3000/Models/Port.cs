using System;

namespace Kontejner3000.Models
{
	public class Port
	{
		private int ShipAmount { get; }
		public int[] ShipDistance { get; set; }
		public Ship[] Ships { get; set; }

		public Port(int shipcount)
		{
			ShipAmount = shipcount;
			Ships = new Ship[ShipAmount];
			ShipDistance = new int[ShipAmount - 1];
		}
		public bool MoveContainer(string containerId, Ship destination)
		{
			if (Container.ContainerIds.Contains(containerId) == false)
				return false;

			int containerIndex = Container.ContainerIds.IndexOf(containerId);
			Container container = Program.Containers[containerIndex];

			Ship start = container.Location;
			destination.AddContainer(container);
			start.RemoveContainer(container);
			container.Location = destination;

			return true;
		}


		public int[] GetRandomArray(int[] array)
		{
			Random random = new Random();
			foreach (int item in array)
			{
				array[item] = random.Next(100, 450);
			}
			return array;
		}
		public int GetMoveTime(int start, int destination)
		{
			int time = 0;
			for (int i = start; i < destination; i++)
			{
				time += ShipDistance[i];
			}
			return time;
		}
		public void AddShips()
		{
			for (int i = 0; i < ShipAmount; i++)
				Ships[i] = new Ship(5000,10000, 10000, 10000);
		}
	}
}