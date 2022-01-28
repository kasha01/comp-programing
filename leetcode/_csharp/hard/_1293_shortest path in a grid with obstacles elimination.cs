using System;
using System.Collections.Generic;

// https://leetcode.com/problems/shortest-path-in-a-grid-with-obstacles-elimination/submissions/
namespace _csharp
{
	public class _1293_shortest_path_in_a_grid_with_obstacles_elimination
	{
		public int ShortestPath(int[][] grid, int k) {
			int n = grid.Length; int m = grid[0].Length;
			if(n==1 && m==1) return 0;

			int[,] dir = {{0,-1}, {0,1}, {-1,0}, {1,0}};
			bool[,,] visited = new bool[n,m,k+1];

			int distance = 0;
			var qu = new Queue<int[]>();
			qu.Enqueue(new int[]{0,0,0});
			visited[0,0,0]=true;

			while(qu.Count > 0){
				int size = qu.Count;
				for(int x=0;x<size;++x){
					int[] p = qu.Dequeue();
					int i=p[0]; int j=p[1]; int kp=p[2];

					for(int d=0;d<4;++d){
						int next_i = i+dir[d,0];
						int next_j = j+dir[d,1];
						int next_k=kp;

						if(next_i<0 || next_i>=n || next_j<0 || next_j>=m) continue;
						if(next_i == n-1 && next_j == m-1) return distance + 1;                    

						if(grid[next_i][next_j] == 1) next_k++;
						if(next_k>k) continue;

						if(visited[next_i,next_j,next_k]) continue;
						qu.Enqueue(new int[]{next_i, next_j, next_k});
						visited[next_i,next_j,next_k]=true;

					}
				}
				++distance;
			}        

			return -1;
		}
	}
}