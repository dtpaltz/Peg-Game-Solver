using System;
using System.Collections.Generic;

namespace PegGameSolver
{
	public class BoardState
	{
		private int[] m_BoardState;

		public int[] Board
		{
			get
			{
				return m_BoardState;
			}
		}

		private List<Move> m_moves;

		public BoardState(int[] boardState, Move previousMove)
		{
			m_BoardState = boardState;
			m_moves = new List<Move>() { previousMove };
		}

		public void AppendMoves(BoardState previouState)
		{
			for (int i = 0; i < previouState.m_moves.Count; i++)
			{
				m_moves.Insert(i, previouState.m_moves[i]);
			}
		}

		public bool IsValidSolution()
		{
			return BoardUtils.IsBoardSolved(m_BoardState);
		}

		public void PrintSolution()
		{
			Console.WriteLine("--------------------------------");

			foreach (var move in m_moves)
			{
				if (move != null)
				{
					Console.WriteLine(move.StartingPegIndex + "  \t--->\t  " + move.EndingPegIndex); 
				}
			}

			Console.WriteLine("Moves: " + m_moves.Count);
		}
	}
}
