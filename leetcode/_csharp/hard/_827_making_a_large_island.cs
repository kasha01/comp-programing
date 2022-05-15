using System;
using System.Collections.Generic;

// https://leetcode.com/problems/making-a-large-island/
// tags: island large

namespace _csharp
{
	public class _827_making_a_large_island
	{
		private static int[,] directions = new int[,]{{1,0},{-1,0},{0,1},{0,-1}};

		public int LargestIsland(int[][] grid) {
			int n = grid.Length;
			int island_name = -1;
			// key: island_name | value: island size
			Dictionary<int,int> island_name_size = new Dictionary<int,int>();
			List<int[]> zeros = new List<int[]>();
			int largestIsland = 0;

			for(int i=0;i<n;++i){
				for(int j=0;j<n;++j){
					if(grid[i][j] == 1){
						int island_size = bfs(i,j,island_name,n,grid);
						island_name_size.Add(island_name, island_size);
						largestIsland = Math.Max(largestIsland, island_size);
						--island_name;
					}
					else if(grid[i][j] == 0){
						zeros.Add(new int[2]{i,j});
					}
				}
			}

			foreach(var coordinate in zeros){
				int current_island_size = 1; // set to 1 to count for the current zero flipped to 1 island
				HashSet<int> islands = new HashSet<int>();
				for(int d=0;d<4;++d){
					int new_i = coordinate[0] + directions[d,0];
					int new_j = coordinate[1] + directions[d,1];

					if(new_i<0 || new_i>=n || new_j<0 || new_j>=n) continue;
					if(grid[new_i][new_j] == 0) continue;   // it is not connected to an island.

					var neighbor_island_name = grid[new_i][new_j]; 
					if(!islands.Contains(neighbor_island_name)){
						islands.Add(neighbor_island_name);
						current_island_size = current_island_size + island_name_size[neighbor_island_name];
					}
				}

				largestIsland = Math.Max(largestIsland, current_island_size);
			}

			return largestIsland;
		}

		public int bfs(int i, int j, int island_name, int n, int[][] grid){
			Queue<int[]> qu = new Queue<int[]>();
			qu.Enqueue(new int[2]{i,j});
			grid[i][j] = island_name;

			int sz = 1;
			while(qu.Count > 0){
				for(int k=0;k<qu.Count;++k){
					var node = qu.Dequeue();

					for(int d=0;d<4;++d){
						int new_i = node[0] + directions[d,0];
						int new_j = node[1] + directions[d,1];

						if(new_i<0 || new_i>=n || new_j<0 || new_j>=n) continue;
						if(grid[new_i][new_j] != 1) continue;

						++sz;
						grid[new_i][new_j] = island_name;
						qu.Enqueue(new int[]{new_i,new_j});
					}
				}
			}

			return sz;
		}

	}
}