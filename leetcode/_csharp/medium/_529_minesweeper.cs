using System;

// https://leetcode.com/problems/minesweeper/
namespace _csharp
{
	public class _529_minesweeper
	{
		public char[][] UpdateBoard(char[][] board, int[] click) {
			if(board[click[0]][click[1]] == 'M')
			{
				board[click[0]][click[1]] = 'X';
				return board;
			}

			int a = click[0]; int b = click[1];
			int n = board.Length; int m = board[0].Length;
			reveal(a,b,n,m,board);
			return board;
		}

		int[,] directions = { {1,0}, {-1,0}, {0,1}, {0,-1}, {1,1}, {-1,-1}, {1,-1}, {-1,1} };

		private void reveal(int r, int c, int n, int m, char[][] board){
			if(r<0 || c<0 || r>=n || c>=m){
				return;
			}

			char ch = board[r][c];
			if(ch != 'E')
				return;

			int bombs_sum = 0;

			for(int i=0;i<8;++i){
				int rr = r + directions[i,0];
				int cc = c + directions[i,1];

				if(rr<0 || cc<0 || rr>=n || cc>=m)
					continue;

				if(board[rr][cc] == 'M' || board[rr][cc] == 'X')
					bombs_sum++;
			}

			board[r][c] = bombs_sum>0 ? Convert.ToChar(bombs_sum+'0') : 'B';

			if(board[r][c] != 'B')
				return;

			for(int i=0;i<8;++i){
				int rr = r + directions[i,0];
				int cc = c + directions[i,1];

				reveal(rr,cc,n,m,board);
			}
		}
	}
}

