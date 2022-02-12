using System;
using System.Collections.Generic;

// https://leetcode.com/problems/pacific-atlantic-water-flow/
namespace _csharp
{
	public class _417_pacific_atlantic_water_flow
	{
		public IList<IList<int>> PacificAtlantic(int[][] heights) {
			var ans = new List<List<int>>();
			int n = heights.Length; int m = heights[0].Length;
			for(int i=0;i<n;++i){
				for(int j=0;j<m;++j){
					if((i==n-1 && j==0) || (i==0 && j==m-1)){
						ans.Add(new List<int>(){i,j});
					}
					else{
						if(bfs(i,j,n,m,heights)){
							ans.Add(new List<int>(){i,j});
						}
					}
				}
			}

			return ans.ToArray();
		}

		private bool bfs(int i, int j, int n, int m, int[][] heights){
			Queue<int[]> qu = new Queue<int[]>();
			var visited = new bool[n,m];
			var directions = new int[,]{{1,0}, {-1,0}, {0,1}, {0,-1}};

			bool isPacific = false; bool isAtlantic = false;
			qu.Enqueue(new int[]{i,j,heights[i][j]});
			visited[i,j]=true;

			while(qu.Count>0){
				int k = qu.Count;
				for(int x=0;x<k;++x){
					var node = qu.Dequeue();
					int ii = node[0];
					int jj = node[1];
					int vv = node[2];

					isPacific = isPacific || (ii==0 || jj==0);
					isAtlantic = isAtlantic || (ii==n-1 || jj==m-1);

					if(isPacific && isAtlantic)
						return true;

					for(int d=0;d<4;++d){
						int new_ii = ii + directions[d,0];    
						int new_jj = jj + directions[d,1];

						if(new_ii<0 || new_ii>=n || new_jj<0 || new_jj>=m)
							continue;

						if(visited[new_ii,new_jj])
							continue;

						if(vv < heights[new_ii][new_jj])
							continue;

						visited[new_ii,new_jj] = true;
						qu.Enqueue(new int[]{new_ii, new_jj, heights[new_ii][new_jj]});
					}
				}            
			}

			return false;
		}

	}
}