using System;
using System.Collections.Generic;
using System.Linq;

namespace PegGameSolver
{
	public static class BoardUtils
	{
		private static readonly List<Move> JumpDictionary = new List<Move>
		{
			new Move(0, 1, 3),
			new Move(0, 2, 5),
			new Move(1, 3, 6),
			new Move(1, 4, 8),
			new Move(2, 4, 7),
			new Move(3, 4, 5),
			new Move(2, 5, 9),
			new Move(3, 6, 10),
			new Move(3, 7, 12),
			new Move(4, 7, 11),
			new Move(6, 7, 8),
			new Move(4, 8, 13),
			new Move(5, 8, 12),
			new Move(7, 8, 9),
			new Move(5, 9, 14),
			new Move(10, 11, 12),
			new Move(11, 12, 13),
			new Move(12, 13, 14)
		};

		public static List<Move> GetMovesEndingAt(int index)
		{
			var moveList = new List<Move>();

			foreach (Move jump in JumpDictionary)
			{
				if (jump.StartingPegIndex == index)
				{
					moveList.Add(jump.Reverse());
				}
				else if (jump.EndingPegIndex == index)
				{
					moveList.Add(jump);
				}
			}

			return moveList;
		}

		public static int[] CreateInitialBoard(int initialOpenSlotIndex)
		{
			int[] board = new int[15];

			for (int i = 0; i < board.Length; i++)
			{
				if (i != initialOpenSlotIndex)
				{
					board[i] = 1;
				}
			}

			return board;
		}

		public static List<int> GetOpenSlots(int[] board)
		{
			List<int> openSlots = new List<int>();

			for (int i = 0; i < board.Length; i++)
			{
				if (board[i] == 0)
				{
					openSlots.Add(i);
				}
			}

			return openSlots;
		}

		public static bool IsBoardSolved(int[] board)
		{
			return board.Sum() == 1;
		}

		public static BoardState PerformMove(int[] board, Move move)
		{
			int[] boardCopy = new int[board.Length];
			Array.Copy(board, boardCopy, board.Length);
			boardCopy[move.StartingPegIndex] = 0;
			boardCopy[move.JumpedPegIndex] = 0;
			boardCopy[move.EndingPegIndex] = 1;

			return new BoardState(boardCopy, move);
		}

		public static List<Move> GenerateNextMoves(int[] board)
		{
			List<Move> validNextMoves = new List<Move>();

			foreach (var slot in GetOpenSlots(board))
			{
				List<Move> possibleMoves = GetMovesEndingAt(slot);

				foreach (var move in possibleMoves)
				{
					if (move.IsValidMove(board))
					{
						validNextMoves.Add(move);
					}
				}
			}

			return validNextMoves;
		}

		public static List<BoardState> GenerateNextStates(BoardState currentState)
		{
			List<BoardState> nextStates = new List<BoardState>();

			foreach (var move in GenerateNextMoves(currentState.Board))
			{
				BoardState newState = PerformMove(currentState.Board, move);
				newState.AppendMoves(currentState);
				nextStates.Add(newState);
			}

			return nextStates;
		}
	}
}
