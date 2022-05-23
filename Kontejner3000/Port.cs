using System;
using System.Collections.Generic;

namespace Kontejner3000
{
	public class Port
	{
		public int ShipAmount { get; set; }
		public int[] ShipDistance { get; set; }
		public Ship[] Ships { get; set; }

		public Port(int shipcount)
		{
			ShipAmount = shipcount;
			Ships = new Ship[ShipAmount];
			ShipDistance= new int[ShipAmount];
		}
		public int MoveContainer(int start, int container, int destination)
		{
			Ships[destination].AddContainer(Ships[start].ContainersInside[container]);
			Ships[start].ContainersInside.Remove(Ships[start].ContainersInside[container]);
			int time = GetMoveTime(start, destination);
			return time;
		}

		public int[] GetRandomArray(int[] array)
		{
			Random random = new Random();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = random.Next(100, 450);
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
				Ships[i]=new Ship();
		}
	}
}