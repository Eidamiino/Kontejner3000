using System;
using System.Collections.Generic;

namespace Kontejner3000
{
	public abstract class StorageBase
	{
		public StorageBase(int weight, int height, int length, int width)
		{
			StorageId = Guid.NewGuid();
			Weight = weight;
			Height = height;
			Length = length;
			Width = width;
			Volume = height * length * width;
		}
		 
		public Guid StorageId { get; }
		public int Weight { get; private set; }
		public int Height { get; }
		public int Length { get; }
		public int Width { get; }
		public double Volume { get; }

		public void AddWeight(int weight)
		{
			Weight += weight;
		}
		public void RemoveWeight(int weight)
		{
			Weight -= weight;
		}

		public bool CheckIfExists(string id)
		{
			return Container.ContainerIds.Contains(id);
		}
		public string GetId(List<string> list)
		{
			string id = null;
			do
			{
				int one = Helpers.GetRandom(1, 10);
				int two = Helpers.GetRandom(10, 100);
				id = one + "-" + two;
			} while (CheckIfExists(id));

			list.Add(id);
			return id;
		}
	}
}