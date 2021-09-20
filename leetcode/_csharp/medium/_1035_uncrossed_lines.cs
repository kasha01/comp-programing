using System;
using System.Collections.Generic;

// https://leetcode.com/problems/uncrossed-lines/
namespace _csharp
{
	public class _1035_uncrossed_lines
	{
		// may weird solution!
		public int MaxUncrossedLines(int[] A, int[] B) {
			Dictionary<int,List<int>> map = new Dictionary<int,List<int>>();
			int[,] memo = new int[A.Length, B.Length];

			for(int i=0; i<B.Length;++i){
				int x = B[i];
				if(!map.ContainsKey(x)){
					map.Add(x,new List<int>());
				}
				map[x].Add(i);
			}

			return rc(0,-1,A,B,map,memo);
		}

		private int rc(int i, int minJ, int[] A, int[] B, Dictionary<int,List<int>> map, int[,] memo){
			if(i>= A.Length || minJ>=B.Length){
				return 0;
			}

			if(minJ != -1 && memo[i,minJ] != 0)
				return memo[i,minJ];

			int r1=0; int r2=0;
			int ai = A[i];
			if(map.ContainsKey(ai)){
				var listOfIndexes = map[ai];
				foreach(int x in listOfIndexes){
					if(x > minJ){
						r1 = 1 + rc(i+1, x, A,B,map, memo);
						break;
					}    
				}           
			}

			r2 = rc(i+1, minJ, A, B, map, memo);
			if(minJ!=-1)
				memo[i,minJ] = Math.Max(r1,r2);
			return Math.Max(r1,r2);
		}

		// easier solution. the question is actually longest common subsequence.
		public int MaxUncrossedLines_lcs(int[] A, int[] B) {
			int n = A.Length;
			int m = B.Length;
			int[,] memo = new int[n+1,m+1];

			for(int i=0;i<=n;++i){
				for(int j=0;j<=m;++j){
					if(i==0 || j==0)
					{
						memo[i,j] = 0;
						continue;
					}

					if(A[i-1] == B[j-1]){
						memo[i,j] = memo[i-1,j-1] + 1;
					}
					else{
						memo[i,j] = Math.Max(memo[i-1,j], memo[i,j-1]);
					}
				}
			}

			return memo[n,m];
		}
	}
}