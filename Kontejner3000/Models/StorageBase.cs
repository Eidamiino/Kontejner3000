using System;

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
			AvailableVolume = Volume = height * length * width;
		}
		public Guid StorageId { get; private set; }
		public int Weight { get; private set; }
		public int Height { get; private set; }
		public int Length { get; private set; }
		public int Width { get; private set; }
		public double Volume { get; private set; }
		public double AvailableVolume { get; protected set; }
	}
}