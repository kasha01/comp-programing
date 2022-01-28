using System;

// https://leetcode.com/problems/minimum-degree-of-a-connected-trio-in-a-graph/
namespace _csharp
{
	public class _1761_minimum_degree_of_a_connected_trio_in_a_graph
	{
		public int MinTrioDegree(int n, int[][] edges) {
			var matrix = new bool[n+1,n+1];
			var count = new int[n+1];

			foreach(var e in edges){
				int start=e[0]; int end=e[1];
				matrix[start,end]=true;
				matrix[end,start]=true;

				count[start]++; count[end]++;
			}

			int minTrio = int.MaxValue;
			for(int i=1;i<=n-2;++i){
				for(int j=i+1;j<=n-1;++j){
					if(matrix[i,j]){
						for(int k=j+1;k<=n;++k){
							if(matrix[j,k] && matrix[i,k]){
								// it is a trio. 6 represents the trio edges 3*2
								int degree = count[i] + count[j] + count[k] - 6;
								minTrio = Math.Min(minTrio, degree);
							}
						}
					}
				}
			}

			return minTrio == int.MaxValue ? -1 : minTrio;
		}
	}
}