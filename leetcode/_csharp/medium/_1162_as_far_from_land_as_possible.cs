using System;
using System.Collections.Generic;

// https://leetcode.com/problems/as-far-from-land-as-possible/
namespace _csharp
{
	public class _1162_as_far_from_land_as_possible
	{
		public int MaxDistance(int[][] grid) {
			int n = grid.Length;

			bool[,] visited = new bool[n,n];
			var qu = new Queue<int[]>();
			int[][] d = { new int[2]{ -1, 0 }, new int[2]{ 1, 0 }, new int[2]{ 0, -1 }, new int[2]{ 0, 1 } };

			for(int i=0;i<n;++i){
				for(int j=0;j<n;++j){
					if(grid[i][j]==1){
						qu.Enqueue(new int[2]{i,j});
					}
				}
			}

			int maxDistance = -1;   // init to -1 because there is an extra process rotation when everything
			// left in the queue is 0s. so this will have maxDistance have an extra +1
			while(qu.Count > 0){
				int m = qu.Count;
				for(int x=0;x<m;++x){
					var node = qu.Dequeue();
					int ii=node[0]; int jj=node[1];
					for(int k=0;k<4;++k){
						int i_new = ii+d[k][0]; int j_new = jj+d[k][1];

						if(i_new<0 || i_new>=n || j_new<0 || j_new>=n) continue;
						if(grid[i_new][j_new] == 1) continue;
						if(visited[i_new,j_new]) continue;

						visited[i_new,j_new] = true;
						qu.Enqueue(new int[2]{i_new,j_new});
					}
				}
				maxDistance++;
			}

			return maxDistance <= 0 ? -1 : maxDistance;
		}
	}
}