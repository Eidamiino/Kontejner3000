using System;

namespace Kontejner3000
{
	public abstract class StorageBase
	{
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
			int one, two, three;
			one = Helpers.GetRandom(1, 10);
			two = Helpers.GetRandom(1, 10);
			three = Helpers.GetRandom(1, 10);
			return one + "-" + two + three;
		}
	}
}