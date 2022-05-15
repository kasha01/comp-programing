using System;
using System.Collections.Generic;

// https://leetcode.com/problems/shortest-path-in-binary-matrix/
namespace _csharp
{
	public class _1091_shortest_path_in_binary_matrix
	{
		public int ShortestPathBinaryMatrix(int[][] grid) {
			if(grid[0][0] == 1)
				return -1;

			var directions = new int[,]{{1,0},{-1,0},{0,1},{0,-1}, {1,1},{1,-1},{-1,1},{-1,-1}};

			int n = grid.Length;
			int m = grid[0].Length;

			var visited = new bool[n,m];

			Queue<Tuple<int,int>> qu = new Queue<Tuple<int,int>>();
			qu.Enqueue(Tuple.Create(0,0));
			visited[0,0] = true;

			int distance=0;
			while(qu.Count > 0){
				int c = qu.Count;
				for(int k=0;k<c;++k){
					var tup = qu.Dequeue();
					int i=tup.Item1; int j=tup.Item2;

					if(i==n-1 && j==m-1) return distance+1; // +1 because I am counting the starting position

					for(int d=0;d<8;++d){
						int new_i = i + directions[d,0];
						int new_j = j + directions[d,1];

						if(new_i<0 || new_i>=n || new_j<0 || new_j>=m) continue;
						if(grid[new_i][new_j] == 1) continue;
						if(visited[new_i,new_j]) continue;

						qu.Enqueue(Tuple.Create(new_i,new_j));
						visited[new_i,new_j]=true;
					}
				}

				++distance;
			}

			return -1;
		}
	}
}

