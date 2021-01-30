using System;
using System.Collections.Generic;

// https://leetcode.com/problems/rotting-oranges/
namespace _csharp
{
	public class _994_rotting_oranges
	{
		public int OrangesRotting(int[][] grid) {
			Queue<KeyValuePair<int,int>> qu = new Queue<KeyValuePair<int,int>>();

			int n=grid.Length;
			int m=grid[0].Length;

			int sumOfRottens = 0;
			int sumOfOranges=0;
			for(int i=0;i<n;++i){
				for(int j=0;j<m;++j){
					if(grid[i][j]==1 || grid[i][j]==2){
						++sumOfOranges;    
					}

					if(grid[i][j] == 2){
						// rotten
						++sumOfRottens;
						qu.Enqueue(new KeyValuePair<int,int>(i,j));
					}
				}
			}

			int minutes=0;
			while(qu.Count>0 && sumOfRottens != sumOfOranges){
				minutes++;
				int k = qu.Count;
				for(int i=0;i<k;++i){
					var x = qu.Dequeue();

					int r = x.Key;
					int c = x.Value;

					// under
					if(r+1<n && grid[r+1][c] == 1){
						grid[r+1][c]=2;
						qu.Enqueue(new KeyValuePair<int,int>(r+1,c));                
						++sumOfRottens;
					}

					// above
					if(r-1>=0 && grid[r-1][c] == 1){
						grid[r-1][c]=2;
						qu.Enqueue(new KeyValuePair<int,int>(r-1,c));                
						++sumOfRottens;
					}

					// left
					if(c-1>=0 && grid[r][c-1] == 1){
						grid[r][c-1]=2;
						qu.Enqueue(new KeyValuePair<int,int>(r,c-1));                
						++sumOfRottens;
					}

					// right
					if(c+1<m && grid[r][c+1] == 1){
						grid[r][c+1]=2;
						qu.Enqueue(new KeyValuePair<int,int>(r,c+1));                
						++sumOfRottens;
					}
				}
			}

			return sumOfRottens == sumOfOranges ? minutes : -1;
		}
	}
}

