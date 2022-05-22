using System.Collections.Generic;

namespace Kontejner3000
{
	public class Ship
	{
		public List<Container> ContainersInside { get; set; }
		public Ship()
		{
			ContainersInside = new List<Container>();
		}
		public bool AddContainer(Container container)
		{
			this.ContainersInside.Add(container);
			return true;
		}
	}
}