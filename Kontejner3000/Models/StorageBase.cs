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
		public Guid StorageId { get; }
		public int Weight { get; }
		public int Height { get; }
		public int Length { get; }
		public int Width { get; }
		public double Volume { get; }
		public double AvailableVolume { get; protected set; }
	}
}