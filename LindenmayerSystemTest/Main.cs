using System;

namespace LindenmayerSystemTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			SierpinskiTriangleGenerator generator = new SierpinskiTriangleGenerator();
			
			int generations = 5;
			for (int i = 0; i < generations; i++)
			{
				Console.WriteLine(String.Format("{0} : {1}", i, generator));
				generator.NextGeneration();
			}
		}
	}
}

