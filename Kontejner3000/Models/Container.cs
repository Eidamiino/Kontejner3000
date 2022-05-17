using System;

namespace Kontejner3000
{
	public class Container:StorageBase
	{
		public Container(int weight, int height, int length, int width) : base(weight, height, length, width)
		{
			ContainerId = Guid.NewGuid();
		}
		public Guid ContainerId{get;protected set;}
	}
}