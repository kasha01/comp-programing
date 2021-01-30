using System;
using System.Collections.Generic;

// https://leetcode.com/problems/all-paths-from-source-to-target/
namespace _csharp
{
	public class _797_all_paths_from_source_to_target
	{
		List<List<int>> result;

		void driver() {
			int[][] graph = new int[4][];
			graph[0]= new int[]{1,2};
			graph[1]= new int[]{3};
			graph[2]= new int[]{3};
			graph[3]= new int[0]{};
			AllPathsSourceTarget (graph);
		}

		public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
			int n = graph.Length-1;
			result = new List<List<int>>();

			List<int> path = new List<int>();
			dfs(0,n,path,graph);    

			return result.ToArray();
		}

		private void dfs(int i,int n, List<int> path, int[][] graph){
			path.Add(i);
			if(i==n){
				var ls = new List<int> ();
				ls.AddRange (path);
				result.Add (ls);
				path.RemoveAt(path.Count - 1);
				return;
			}

			int[] neighbors = graph[i];
			int m = neighbors.Length;
			for(int j=0;j<m;++j){
				dfs(neighbors[j],n,path,graph);
			}
			path.RemoveAt(path.Count - 1);
		}
	}
}

