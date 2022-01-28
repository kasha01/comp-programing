using System;
using System.Collections.Generic;

// https://leetcode.com/problems/minimum-height-trees/
namespace _csharp
{
	public class _310_minimum_height_trees
	{
		bool[] visited;
		Dictionary<int, List<int>> map;
		int[] indegree;
		Queue<int> qu;

		public IList<int> FindMinHeightTrees(int n, int[][] edges) {
			if(n==1) return new int[]{0};
			if(n==2) return new int[]{0,1};

			visited = new bool[n];
			indegree = new int[n];
			qu = new Queue<int>();
			map = new Dictionary<int, List<int>>();

			for(int i=0;i<edges.Length;++i){
				int a = edges[i][0];
				int b = edges[i][1];
				if(!map.ContainsKey(a))
					map.Add(a, new List<int>());

				if(!map.ContainsKey(b))
					map.Add(b, new List<int>());

				map[a].Add(b);
				map[b].Add(a);

				indegree[a]++;
				indegree[b]++;
			}

			for(int i=0;i<n;++i){
				if(indegree[i] == 1)
					qu.Enqueue(i);
			}

			// I have to do this, counting how many nodes left. once it reaches 2 or below (maximum number)
			// of roots to produce tree with minimum height -> break.
			int remainingNodes = n;
			while(remainingNodes > 2){
				int m = qu.Count;
				remainingNodes = remainingNodes - m;
				while(m>0){
					--m;
					int node = qu.Dequeue();
					var adj = map[node];
					foreach(int neighbor in adj){
						indegree[neighbor]--;
						if(indegree[neighbor] == 1){
							qu.Enqueue(neighbor);
							indegree[neighbor]=-1;  // a hack so the neighbor node won't be double added.
						}
					}
				}
			}

			List<int> ans = new List<int>();
			while(qu.Count > 0){
				ans.Add(qu.Dequeue());
			}

			return ans;
		}
	}
}