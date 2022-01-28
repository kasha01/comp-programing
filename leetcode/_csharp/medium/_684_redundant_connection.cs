using System;

// https://leetcode.com/problems/redundant-connection/
namespace _csharp
{
	public class _684_redundant_connection
	{
		int[] union;
		int[] rank;
		public int[] FindRedundantConnection(int[][] edges) {
			union = new int[1001];
			rank = new int[1001];

			for(int i=0;i<=1000;++i){
				union[i] = i;
			}

			int[] ans = new int[2];
			for(int i=0;i<edges.Length;++i){
				int a = edges[i][0];
				int b = edges[i][1];

				int pa = getParent(a);
				int pb = getParent(b);

				if(pa==pb){
					// already joined. 
					ans[0]=a; ans[1]=b;
				}
				else {
					if(rank[pa] >= rank[pb]){
						union[pb] = pa; rank[pa]++;
					}
					else{
						union[pa] = pb; rank[pb]++;
					}
				}
			}

			return ans;
		}

		private int getParent(int i){
			if(union[i]==i) return i;
			return union[i] = getParent(union[i]);
		}
	}
}