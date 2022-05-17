using System;

namespace Kontejner3000
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Box box1=Helpers.GenerateRandomBox();
			Console.WriteLine(box1);
		}
	}
}
