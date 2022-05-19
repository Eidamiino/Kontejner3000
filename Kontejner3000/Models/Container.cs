using System;
using System.Collections.Generic;

namespace Kontejner3000
{
	public class Container:StorageBase
	{
		public Container(int weight, int height, int length, int width) : base(weight, height, length, width)
		{
			BoxesInside = new List<Box>();
		}
		public List<Box> BoxesInside { get; set; }

		public string GetFreeSpace()
		{
			return $"Current free space in container: {AvailableVolume}";
		}
		public void AddBox(Box box)
		{
			BoxesInside.Add(box);
			AvailableVolume -=box.Volume;
		}
		public void RemoveBox(Box box, int index)
		{
			BoxesInside.RemoveAt(index);
			AvailableVolume += box.Volume;
		}

		public bool IsBoxTooBig(Box box)
		{
			return box.Volume > AvailableVolume;
		}
		public override string ToString()
		{
			return ($"Container has inside {BoxesInside.Count} boxes");
		}
	}
}