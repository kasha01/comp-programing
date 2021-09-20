using System;

// https://leetcode.com/problems/minimum-path-sum/
namespace _csharp
{
	public class _64_minimum_path_sum
	{
		int[,] memo;
		public int MinPathSum(int[][] grid) {
			int n = grid.Length; int m = grid[0].Length;
			memo = new int[n,m];
			for(int i=0;i<n;++i){
				for(int j=0;j<m;++j){
					memo[i,j]=-1;
				}
			}
			return rc(0,0,n-1,m-1,grid);
		}

		private int rc(int i, int j, int n, int m, int[][] grid){
			if(i>n || j>m)
				return int.MaxValue;

			if(i==n && j==m){
				return grid[i][j];
			}

			if(memo[i,j] != -1)
				return memo[i,j];

			int sum_1 = rc(i+1,j,n,m,grid);    // go down
			int sum_2 = rc(i,j+1,n,m,grid);    // go right

			memo[i,j] = grid[i][j] + Math.Min(sum_1,sum_2);
			return memo[i,j];
		}

		// bottom up approach
		private int MinPathSum_bottom_up(int[][] grid) {
			int n = grid.Length; int m = grid[0].Length;
			int[,] memo = new int[n,m];

			for(int i=0;i<n;++i){
				for(int j=0;j<m;++j){
					if(j-1>=0 && i-1>=0){
						memo[i,j] = grid[i][j] + Math.Min(memo[i-1,j],memo[i,j-1]);
					}
					else if(j-1>=0){
						memo[i,j] = grid[i][j] + memo[i,j-1];                    
					}
					else if (i-1>=0){
						memo[i,j] = grid[i][j] + memo[i-1,j];
					}
					else{
						memo[i,j] = grid[i][j];
					}
				}
			}

			return memo[n-1,m-1];
		}
	}
}