using System;

// https://leetcode.com/problems/max-area-of-island/
namespace _csharp
{
	public class _695_max_area_of_island
	{
		public int MaxAreaOfIsland(int[][] grid) {
			int ans = 0;
			for(int i=0;i<grid.Length;++i){
				for(int j=0;j<grid[0].Length;++j){
					if(grid[i][j] == 1)
						ans = Math.Max(ans, rc(i,j,grid));
				}
			}
			return ans;
		}

		private int rc(int x, int y, int[][] grid){
			if(x>= grid.Length || x<0 || y>=grid[0].Length || y<0)
				return 0;

			if(grid[x][y] != 1)
				return 0;

			grid[x][y] = -1;
			return 1 + rc(x+1,y,grid) + rc(x-1,y,grid) + rc(x,y+1,grid) + rc(x,y-1,grid);
		}
	}
}