using System.Collections.Generic;

namespace Kontejner3000
{
	public class Ship
	{
		public List<Container> ContainersInside { get;}
		public Ship()
		{
			ContainersInside = new List<Container>();
		}
		public bool AddContainer(Container container)
		{
			ContainersInside.Add(container);
			return true;
		}
	}
}