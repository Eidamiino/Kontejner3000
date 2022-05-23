using System;
using System.Collections.Generic;

namespace Kontejner3000
{
	public abstract class StorageBase
	{
		public List<string> CustomIds = new List<string>();

		public StorageBase(int weight, int height, int length, int width)
		{
			StorageId = Guid.NewGuid();
			CustomId = GetId();
			Weight = weight;
			Height = height;
			Length = length;
			Width = width;
			Volume = height * length * width;
		}

		public Guid StorageId { get; }
		public string CustomId { get; }
		public int Weight { get; private set; }
		public int Height { get; }
		public int Length { get; }
		public int Width { get; }
		public double Volume { get; }

		public void AddWeight(int addedWeight)
		{
			Weight += addedWeight;
		}

		public string GetId()
		{
			string id=null;
			do
			{
				int one = Helpers.GetRandom(1, 10);
				int two = Helpers.GetRandom(10, 100);
				id = one + "-" + two;
			} while (CheckIfExists(id));
			CustomIds.Add(id);
			return id;
		}

		public bool CheckIfExists(string id)
		{
			return CustomIds.Contains(id);
		}
	}
}