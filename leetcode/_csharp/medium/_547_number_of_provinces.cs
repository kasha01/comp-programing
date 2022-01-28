using System;
using System.Collections.Generic;

// https://leetcode.com/problems/number-of-provinces/
namespace _csharp
{
	public class _547_number_of_provinces
	{
		public int FindCircleNum(int[][] isConnected) {
			int n = isConnected.Length;
			bool[] visited = new bool[n];

			int provinces = 0;

			// loop through all nodes
			for(int i=0;i<n;++i){
				if(!visited[i]){
					++provinces;
					visited[i] = true;
					bfs(i, visited, isConnected, n);
				}
			}

			return provinces;
		}

		private void bfs(int root, bool[] visited, int[][] isConnected, int n){
			Queue<int> qu = new Queue<int>();
			qu.Enqueue(root);

			while(qu.Count > 0){
				int node = qu.Dequeue();
				visited[node] = true;

				// get connected
				for(int neighorNode=0;neighorNode<n;++neighorNode){
					if(node != neighorNode && isConnected[node][neighorNode] == 1 && !visited[neighorNode]){
						qu.Enqueue(neighorNode);
					}
				}
			}
		}
	}
}