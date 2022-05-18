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

		public string StringFreeSpace()
		{
			return $"Current free space in container: {this.AvailableVolume}";
		}
		public void AddBox(Box box)
		{
			this.AvailableVolume-=box.Volume;
		}
		public void RemoveBox(Box box)
		{
			this.AvailableVolume += box.Volume;
		}

		public bool IsBoxTooBig(Box box)
		{
			if (box.Volume > this.AvailableVolume)
				return true;
			return false;
		}
		public override string ToString()
		{
			return ($"Container has inside {BoxesInside.Count} boxes");
		}
	}
}