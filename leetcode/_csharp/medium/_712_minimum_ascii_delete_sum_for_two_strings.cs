using System;

// https://leetcode.com/problems/minimum-ascii-delete-sum-for-two-strings/
namespace _csharp
{
	public class _712_minimum_ascii_delete_sum_for_two_strings
	{
		public int MinimumDeleteSum(string s1, string s2) {
			int n = s1.Length; int m = s2.Length;
			int[,] memo = new int[n+1,m+1];

			for(int i=1;i<=n;++i){
				memo[i,0]=(s1[i-1]-0) + memo[i-1,0];
			}

			for(int i=1;i<=m;++i){
				memo[0,i]=(s2[i-1]-0) + memo[0,i-1];
			}

			for(int i=1;i<=n;++i){
				for(int j=1;j<=m;++j){
					if(s1[i-1]==s2[j-1]){
						memo[i,j] = memo[i-1,j-1];
					}
					else{
						memo[i,j] = Math.Min((s1[i-1]-0) + memo[i-1,j], (s2[j-1]-0) + memo[i,j-1]);
					}
				}
			}

			return memo[n,m];
		}
	}
}