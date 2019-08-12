namespace PegGameSolver
{
	public class Move
	{
		public int StartingPegIndex { get; }
		public int JumpedPegIndex { get; }
		public int EndingPegIndex { get; }

		public Move(int startSlotIndex, int jumpSlotIndex, int endSlotIndex)
		{
			StartingPegIndex = startSlotIndex;
			JumpedPegIndex = jumpSlotIndex;
			EndingPegIndex = endSlotIndex;
		}

		public Move Reverse()
		{
			return new Move(EndingPegIndex, JumpedPegIndex, StartingPegIndex);
		}

		public bool IsValidMove(int[] board)
		{
			if (board[StartingPegIndex] != 1)
			{
				return false;
			}

			if (board[JumpedPegIndex] != 1)
			{
				return false;
			}

			if (board[EndingPegIndex] != 0)
			{
				return false;
			}

			return true;
		}
	}
}
