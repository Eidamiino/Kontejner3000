using System;
using System.Collections.Generic;

namespace Kontejner3000
{
	public class Container:StorageBase
	{
		public Container(int weight, int height, int length, int width) : base(weight, height, length, width)
		{
			ContainerId = Guid.NewGuid();
		}
		public Guid ContainerId{get;protected set;}

		public static void AddBoxesUntilFull(Container container,List<Box> boxes)
		{
			for (int i = 0; i < boxes.Count; i++)
			{
				container.PrintFreeSpace();
				if (container.IsBoxBigger(boxes[i]))
				{
					Console.WriteLine($"The container is full!");
					break;
				}

				container.AddBox(boxes[i]);
			}
		}

		public void PrintFreeSpace()
		{
			Console.WriteLine($"Current free space in container: {this.Volume}");
		}
		public void AddBox(Box box)
		{
			this.Volume-=box.Volume;
		}

		public bool IsBoxBigger(Box box)
		{
			if (box.Volume > this.Volume)
				return true;
			return false;
		}
	}
}