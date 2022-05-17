using System;

namespace Kontejner3000
{
	public class Helpers
	{
		public static int GetRandom(int min, int max)
		{
			Random rand = new Random();
			return rand.Next(min,max);
		}
		public static Box GenerateRandomBox()
		{
			int weight = GetRandom(1, 50);
			int height = GetRandom(1, 50);
			int length = GetRandom(1, 50);
			int width = GetRandom(1, 50);

			return new Box(weight, height, length, width);
		}
	}
}