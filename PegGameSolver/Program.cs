using System;

namespace PegGameSolver
{
	public class Program
	{
		static void Main(string[] args)
		{
			PegGameSolver solver = new PegGameSolver(4);
			solver.Solve();
			Console.ReadLine();
		}
	}
}
