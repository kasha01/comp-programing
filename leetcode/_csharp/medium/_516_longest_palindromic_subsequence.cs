using System;

// https://leetcode.com/problems/longest-palindromic-subsequence/
namespace _csharp
{
	public class _516_longest_palindromic_subsequence
	{
		public int LongestPalindromeSubseq(string s) {
			int n = s.Length;
			int[,] memo = new int[n,n];

			for(int i=0;i<n;++i){
				memo[i,i] = 1;
			}

			// for l = 2
			for(int i=0;i<=n-2;++i){
				int j = i+1;

				if(s[i]==s[j]){
					memo[i,j] = 2;
				}
				else{
					memo[i,j] = 1;
				}
			}

			for(int l=3;l<=n;++l){
				for(int i=0;i<=n-l;++i){
					int j = i+l-1;

					if(s[i]==s[j]){
						memo[i,j] = memo[i+1,j-1]+2;
					}
					else{
						memo[i,j] = Math.Max(memo[i+1,j], memo[i,j-1]);
					}
				}
			}

			return memo[0,n-1];
		}
	}
}