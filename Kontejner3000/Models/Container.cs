using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;

namespace Kontejner3000
{
	public class Container : StorageBase
	{
		public static List<string> ContainerIds = new List<string>();

		public Container(int weight, int height, int length, int width) : base(weight, height, length, width)
		{
			BoxesInside = new List<Box>();
			ContainerId = GetId(ContainerIds);
			AvailableVolume = Volume;
			Location = null;
		}
		public double AvailableVolume { get; protected set; }
		public string ContainerId { get; }
		private List<Box> BoxesInside { get; }
		public Ship Location { get; set; }

		public List<Box> GetContent()
		{
			return BoxesInside.ToList();
		}
		public string GetFreeSpace()
		{
			return $"Current free space in container: {AvailableVolume}";
		}
		public bool AddBox(Box box)
		{
			if (IsBoxTooBig(box))
				return false;

			BoxesInside.Add(box);
			AvailableVolume -= box.Volume;
			AddWeight(box.Weight);
			return true;
		}
		public bool RemoveBox(Box box)
		{
			if (!BoxesInside.Contains(box))
				return false;

			BoxesInside.Remove(box);
			AvailableVolume += box.Volume;
			RemoveWeight(box.Weight);
			return true;
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