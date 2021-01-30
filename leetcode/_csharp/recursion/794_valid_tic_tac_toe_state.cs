using System;

// https://leetcode.com/problems/valid-tic-tac-toe-state/
namespace _csharp
{
	public class _794_valid_tic_tac_toe_state
	{
		static void driver() {
			string[] board = { "XOX", "OXO", "XOX" };
			Console.WriteLine(solve(board));
		}

		static bool solve(string[] board) {
			int xWin = 0; int oWin = 0;
			int xDiagWin = 0; int oDiagWin = 0;
			int xCount = 0; int oCount = 0;

			for (int i = 0; i < 3; ++i) {
				for (int j = 0; j < 3; ++j) {
					if (board [i] [j] == 'X')
						xCount = xCount + 1;
					else if (board [i] [j] == 'O')
						oCount = oCount + 1;
					else if (board [i] [j] == ' ') {
						// space
					}
					else
						return false;
				}
			}

			for (int i = 0; i < 3; ++i) {
				// row tic tac toe check
				if (board [i] [0] == board [i] [1] && board [i] [1] == board [i] [2]) {
					if (board [i] [0] == 'X') {
						++xWin;
					} else if (board [i] [0] == 'O') {
						++oWin;
					}
				}

				// column tic tac toe check
				if (board [0] [i] == board [1] [i] && board [1] [i] == board [2] [i]) {
					if (board [0] [i] == 'X') {
						++xWin;
					} else if (board [0] [i] == 'O') {
						++oWin;
					}
				}
			}

			// diagonal check
			if (board [0] [0] == board [1] [1] && board [1] [1] == board [2] [2]) {
				if (board [0] [0] == 'X') {
					++xWin;
					++xDiagWin;
				} else if (board [0] [0] == 'O') {
					++oWin;
					++oDiagWin;
				}
			}

			// inverse diagonal check
			if (board [0] [2] == board [1] [1] && board [1] [1] == board [2] [0]) {
				if (board [1] [1] == 'X') {
					++xWin;
					++xDiagWin;
				} else if (board [1] [1] == 'O') {
					++oWin;
					++oDiagWin;
				}
			}

			// checking
			if (xCount < oCount)
				return false;
			if (xWin > 0 && oWin > 0)
				return false;
			if (xCount != oCount + 1 && xWin > 0)
				return false;
			if (xCount > oCount + 1)
				return false;
			if (oCount != xCount && oWin > 0)
				return false;

			// leetcode unit test not check for this. but it should we cannot have two diagonal wins, it is impossible.
			if (xDiagWin > 1 || oDiagWin > 1)
				return false;

			return true;
		}
	}
}