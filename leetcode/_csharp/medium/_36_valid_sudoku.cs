using System;

// https://leetcode.com/problems/valid-sudoku/
namespace _csharp
{
	public class _36_valid_sudoku
	{
		public bool IsValidSudoku(char[][] board) {
			bool[,] columns = new bool[9,9];
			bool[,] rows = new bool[9,9];
			bool[,] squares = new bool[9,9];

			int n = board.Length; int m = board[0].Length;

			for(int i=0;i<n;++i){
				for(int j=0;j<m;++j){
					if(board[i][j] != '.'){
						int x = board[i][j] - '0' - 1;
						int square_index = (i/3)*3 + (j/3);
						if(columns[j,x] || rows[i,x] || squares[square_index,x])
							return false;

						columns[j,x] = true;
						rows[i,x] = true;
						squares[square_index,x] = true;
					}
				}
			}

			return true;
		}
	}
}