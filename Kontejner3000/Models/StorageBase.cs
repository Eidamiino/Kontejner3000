namespace Kontejner3000
{
	public abstract class StorageBase
	{
		public StorageBase(int weight, int height, int length, int width)
		{
			Weight=weight;
			Height=height;
			Length=length;
			Width=width;
			Volume = height * length * width;
		}

		public int Weight { get; protected set; }
		public int Height { get; protected set; }
		public int Length { get; protected set; }
		public int Width { get; protected set; }
		public double Volume { get; protected set; }
	}
}	