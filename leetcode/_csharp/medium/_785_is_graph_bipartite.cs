using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

// https://leetcode.com/problems/is-graph-bipartite/
namespace _csharp
{
	public class _785_is_graph_bipartite
	{
		public bool IsBipartite(int[][] graph) {
			int n = graph.Length;
			var edges = new Dictionary<int,List<int>>();
			var groups = new Dictionary<int,char>();

			for(int i=0;i<n;++i){
				int src = i;
				edges.Add(src, graph[i].ToList());
			}

			for(int i=0;i<n;++i){
				if(groups.ContainsKey(i)) continue; // visited

				if(!bfs(i,edges,groups)) return false;
			}

			return true;
		}

		private bool bfs(int root, Dictionary<int,List<int>> edges, Dictionary<int,char> groups){
			Queue<int> qu = new Queue<int>();

			qu.Enqueue(root);
			groups.Add(root,'A');

			while(qu.Count > 0){
				int n = qu.Count;
				for(int i=0;i<n;++i){
					var node = qu.Dequeue();
					var set_name = groups[node];
					var adj = edges[node];

					foreach(int x in adj){
						// cannot have an adjacent node in same set
						if(groups.ContainsKey(x) && groups[x] == set_name) return false;
						if(groups.ContainsKey(x)) continue; // visited

						groups.Add(x,set_name == 'A' ? 'B' : 'A');
						qu.Enqueue(x);
					}                
				}
			}

			return true;
		}
	}
}