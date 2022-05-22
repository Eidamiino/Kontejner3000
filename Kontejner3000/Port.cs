using System;
using System.Collections.Generic;

namespace Kontejner3000
{
	//kamo prisaham ze nam tady dali nejaky NP problem co to vole je pomoc

	//jsou tri classy: container, lod, port (pristav)
	//vytvori se novy port, v portu je *pocet* volnych mist ve kterych je ShipAmount lodi
	//v portu muzou lode mezi sebou containery uvnitr lodi prenaset (nejakou metodou)
	//vsechna mista v portu jsou nahodny pocet metru vzdalena od sebe
	//pri prenaseni containeru je potreba znat doba jakou prenos trval, jeden metr odpovida 1 milisekunde
	//napr: mezi misty 1 a 2 je 100m a mezi 2 a 3 je 200m, takze prenos z 1 do 3 bude trvat 100 + 200 metru
	//tyhle vzdalenosti jsou ulozene v listu ve tride port
	//nemam tuseni jak mam samotne parkovaci misto lodi priradit AHHHAAA JA JE PRIRAZOVAT NEBUDU
	public class Port
	{
		public int ShipAmount { get; set; }
		public int[] ShipDistance { get; set; }
		public Ship[] Ships { get; set; }

		public Port(int shipcount)
		{
			ShipAmount = shipcount;
			Ships = new Ship[ShipAmount];
			ShipDistance= new int[ShipAmount];
		}
		public int MoveContainer(int start, int container, int destination)
		{
			Ships[destination].AddContainer(Ships[start].ContainersInside[container]);
			Ships[start].ContainersInside.Remove(Ships[start].ContainersInside[container]);
			int time = GetMoveTime(start, destination);
			return time;
		}

		public int[] GetRandomArray(int[] array)
		{
			Random random = new Random();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = random.Next(100, 450);
			}

			return array;
		}
		public int GetMoveTime(int start, int destination)
		{
			int time = 0;
			for (int i = start; i < destination; i++)
			{
				time += ShipDistance[i];
			}
			return time;
		}
		public void AddShips()
		{
			for (int i = 0; i < ShipAmount; i++)
				Ships[i]=new Ship();
		}
	}
}