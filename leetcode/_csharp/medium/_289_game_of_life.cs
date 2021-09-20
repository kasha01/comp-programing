using System;

// https://leetcode.com/problems/game-of-life/
namespace _csharp
{
	public class _289_game_of_life
	{
		public void GameOfLife(int[][] board) {
			int n = board.Length;
			int m = board[0].Length;

			for(int i=0;i<n;++i){
				for(int j=0;j<m;++j){
					int up = i-1 >=0 ? getOrigValue(board[i-1][j]) : -5;
					int down = i+1<n ? getOrigValue(board[i+1][j]) : -5;
					int left = j-1>=0 ? getOrigValue(board[i][j-1]) : -5;
					int right =j+1<m ? getOrigValue(board[i][j+1]) : -5;
					int up_right = i-1 >=0 && j+1<m ? getOrigValue(board[i-1][j+1]) : -5;
					int up_left = i-1 >=0 && j-1>=0 ? getOrigValue(board[i-1][j-1]) : -5;
					int down_right = i+1<n && j+1<m ? getOrigValue(board[i+1][j+1]) : -5;
					int down_left = i+1<n && j-1>=0 ? getOrigValue(board[i+1][j-1]) : -5;

					int countLife=0; int countDead=0;
					if(up!=-5) countLife = countLife + (up == 1 ? 1 : 0);
					if(down!=-5) countLife = countLife + (down == 1 ? 1 : 0);
					if(left!=-5) countLife = countLife + (left == 1 ? 1 : 0);
					if(right!=-5) countLife = countLife + (right == 1 ? 1 : 0);
					if(up_left!=-5) countLife = countLife + (up_left == 1 ? 1 : 0);
					if(up_right!=-5) countLife = countLife + (up_right == 1 ? 1 : 0);
					if(down_left!=-5) countLife = countLife + (down_left == 1 ? 1 : 0);
					if(down_right!=-5) countLife = countLife + (down_right == 1 ? 1 : 0);

					int x = board[i][j];
					if(x==1){
						if(countLife < 2 || countLife > 3) x = x+2;
					}else{
						if (countLife == 3) x = 2;
					}

					board[i][j]=x;
				}
			}

			for(int i=0;i<n;++i){
				for(int j=0;j<m;++j){
					int v = board[i][j];
					int vToSave = v;
					if(v==2)
						vToSave = 1;
					else if(v==3)
						vToSave = 0;

					board[i][j] = vToSave;
				}
			}
		}

		private int getOrigValue(int v){
			int orig_value = v;
			if(v > 1){
				// it was transformed.
				orig_value = v - 2;
			}
			return orig_value;
		}
	}
}