using System;
namespace Kontejner3000
{
	public class Box : StorageBase
	{
		public Box(int weight, int height, int length, int width) : base(weight, height, length, width)
		{
			BoxId = Guid.NewGuid();
		}
		public Guid BoxId { get; protected set; }
		public override string ToString()
		{
			return ($"Box has {Weight}kg and a volume of {Volume}cm3");
		}
	}
}