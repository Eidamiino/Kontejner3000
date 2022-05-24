using System.Collections.Generic;
using System.Linq;

namespace Kontejner3000
{
	public class Ship:StorageBase
	{
		public static List<string> ShipIds = new List<string>();
		private List<Container> ContainersInside { get;}
		public Ship(int weight, int height, int length, int width) : base(weight, height, length, width)
		{
			ContainersInside = new List<Container>();
			ShipId = GetId(ShipIds);
		}
		public string ShipId { get; }
		public bool AddContainer(Container container)
		{
			ContainersInside.Add(container);
			container.Location = this;
			return true;
		}

		public bool AddAllContainers()
		{
			foreach (var container in Program.Containers)
			{
				AddContainer(container);
				container.Location = this;
			}
			return true;
		}
		public bool RemoveContainer(Container container)
		{
			ContainersInside.Remove(container);
			return true;
		}
		public List<Container> GetShipContent()
		{
			return ContainersInside.ToList();
		}
	}
}