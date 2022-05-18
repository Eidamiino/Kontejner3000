using System;
using System.Collections.Generic;

namespace Kontejner3000
{
	public class Container:StorageBase
	{
		public Container(int weight, int height, int length, int width) : base(weight, height, length, width)
		{
			ContainerId = Guid.NewGuid();
			BoxesInside = new List<Box>();
		}
		public Guid ContainerId{get;protected set;}
		public List<Box> BoxesInside { get; set; }

		public void PrintFreeSpace()
		{
			Console.WriteLine($"Current free space in container: {this.Volume}");
		}
		public void AddBox(Box box)
		{
			this.Volume-=box.Volume;
		}
		public void RemoveBox(Box box)
		{
			this.Volume += box.Volume;
		}

		public bool IsBoxTooBig(Box box)
		{
			if (box.Volume > this.Volume)
				return true;
			return false;
		}
		public override string ToString()
		{
			return ($"Container has inside {BoxesInside.Count} boxes");
		}
	}
}