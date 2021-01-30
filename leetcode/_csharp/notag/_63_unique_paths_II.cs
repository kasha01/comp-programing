using System;

// https://leetcode.com/problems/unique-paths-ii/
namespace _csharp
{
	public class _63_unique_paths_II
	{
		int R=0;
		int C=0;
		int[,] memo;
		int[][] grid;

		public int UniquePathsWithObstacles(int[][] obstacleGrid) {
			R=obstacleGrid.Length; C=obstacleGrid[0].Length;
			memo = new int[C,R];
			grid = obstacleGrid;
			return unique(0,0);
		}

		private int unique(int x, int y){
			if(x>=C || y>=R)
				return 0;

			if(grid[y][x] == 1)
				return 0;

			if(x==C-1 && y==R-1)
				return 1;

			if(memo[x,y] > 0)
				return memo[x,y];

			int a = unique(x,y+1);  // down
			int b = unique(x+1,y);  // right
			memo[x,y] = a+b;

			return memo[x,y];
		}
	}
}