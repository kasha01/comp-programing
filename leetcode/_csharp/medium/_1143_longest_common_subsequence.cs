using System;

// https://leetcode.com/problems/longest-common-subsequence/
namespace _csharp
{
	public class _1143_longest_common_subsequence
	{
		public int LongestCommonSubsequence(string text1, string text2) {
			int n = text1.Length; int m = text2.Length;

			int[,] memo = new int[n+1,m+1];

			for(int i=1;i<=n;++i){
				for(int j=1;j<=m;++j){
					if(text1[i-1] == text2[j-1]){
						memo[i,j] = 1 + memo[i-1,j-1];
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