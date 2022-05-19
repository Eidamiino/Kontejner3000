using System;
namespace Kontejner3000
{
	public class Box : StorageBase
	{
		public Box(int weight, int height, int length, int width) : base(weight, height, length, width)
		{
			
		}
		public override string ToString()
		{
			return ($"Box has {Weight}kg and a volume of {AvailableVolume}cm3");
		}
	}
}