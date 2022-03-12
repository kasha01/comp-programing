using System;

// https://leetcode.com/problems/distinct-subsequences/
namespace _csharp
{
	public class _115_distinct_subsequences
	{
		public int NumDistinct(string s, string t) {
			int n = s.Length; int m = t.Length;
			int[,] memo = new int[n+1,m+1];

			memo[0,0] = 1;
			for(int i=0;i<=n;++i){
				memo[i,0] = 1;  // if length of target is zero, I can delete any chars of s to have an equal subsequence
			}

			for(int i=1;i<=n;++i){
				for(int j=1;j<=m;++j){
					if(s[i-1] == t[j-1]){
						memo[i,j] = memo[i-1,j-1] + memo[i-1,j];
					}
					else{
						// just carry over previous result
						memo[i,j] = memo[i-1,j];
					}
				}
			}

			return memo[n,m];
		}
	}
}