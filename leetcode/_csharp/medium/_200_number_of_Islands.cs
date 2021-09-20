using System;

// https://leetcode.com/problems/number-of-islands/
namespace _csharp
{
	public class _200_number_of_Islands
	{
		public int NumIslands(char[][] grid) {
			int n = grid.Length;
			int m = grid[0].Length;

			int c = 0;
			for(int i=0;i<n;++i){
				for(int j=0;j<m;++j){
					if(grid[i][j] == '1'){
						++c;
						markIsland(i,j,n,m,grid);
					}
				}
			}

			return c;
		}

		private void markIsland(int i, int j, int n, int m, char[][] grid){
			if(i<0 || i>=n || j<0 || j>=m)
				return;

			if(grid[i][j] != '1')
				return;

			grid[i][j] = '2';

			markIsland(i+1,j,n,m,grid);     // go down
			markIsland(i-1,j,n,m,grid);     // go up
			markIsland(i,j-1,n,m,grid);     // go left
			markIsland(i,j+1,n,m,grid);     // go right
		}
	}
}

