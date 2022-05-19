using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;

namespace Kontejner3000
{
	public class Container : StorageBase
	{
		public Container(int weight, int height, int length, int width) : base(weight, height, length, width)
		{
			BoxesInside = new List<Box>();
			AvailableVolume = Volume;
		}
		public double AvailableVolume { get; protected set; }
		private List<Box> BoxesInside { get; }
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
		public void AddContainerInfoIntoTable(ConsoleTable table)
		{
			table.AddRow($"{StorageId}", $"{BoxesInside.Count}", $"{Weight} kg");
		}
	}
}