using System;
using System.Collections.Generic;
using System.Linq;

namespace PegGameSolver
{
	public class PegGameSolver
	{
		private static List<BoardState> PossibleSolutions;

		public PegGameSolver(int initialOpenSlotIndex)
		{
			PossibleSolutions = new List<BoardState>() { new BoardState(BoardUtils.CreateInitialBoard(initialOpenSlotIndex), null) };
		}

		HashSet<string> statesReached = new HashSet<string>();

		public void Solve()
		{
			while (PossibleSolutions.Count > 0)
			{
				Console.WriteLine("Possible solutions: " + PossibleSolutions.Count);
				BoardState currentState = PossibleSolutions[0];
				PossibleSolutions.RemoveAt(0);

				if (currentState.IsValidSolution())
				{
					currentState.PrintSolution();
					break;
				}

				List<BoardState> newStates = BoardUtils.GenerateNextStates(currentState);




				foreach (var state in newStates)
				{
					string hash = string.Join(",", state.Board.Select(x => x.ToString()).ToArray());

					if (!statesReached.Contains(hash))
					{
						PossibleSolutions.Add(state);
						statesReached.Add(hash);
					}
				}
			}
		}
	}
}