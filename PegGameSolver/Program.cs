using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace PegGameSolver
{
	public class Program
	{
		static void Main(string[] args)
		{
			PegGameSolver solver = new PegGameSolver(4);
			solver.Solve();

			//if (args.Length == 1)
			//{
			//	if (int.TryParse(args[0], out openSlot))
			//	{

			//	}
			//}

			Console.ReadLine();
		}






	}
}
