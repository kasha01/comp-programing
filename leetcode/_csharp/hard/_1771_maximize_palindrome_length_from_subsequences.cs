using System;

// https://leetcode.com/problems/maximize-palindrome-length-from-subsequences/
namespace _csharp
{
	public class _1771_maximize_palindrome_length_from_subsequences
	{
		public int LongestPalindrome(string word1, string word2) {
			string s = word1+word2; int n = s.Length;
			int n1 = word1.Length; int n2 = word2.Length;

			if(n1==0 || n2==0)
				return 0;

			int[,] memo = new int[n,n];

			for(int i=0;i<n;++i){
				memo[i,i] = 1;
			}

			for(int l=2;l<=n;++l){
				for (int i=0;i<=n-l;++i){
					int j = i+l-1;

					if(s[i] == s[j]){
						memo[i,j] = (l==2 ? 2 : memo[i+1,j-1] + 2);
					}
					else{
						memo[i,j] = Math.Max(memo[i+1,j],memo[i,j-1]);
					}
				}
			}

			int ans = 0;
			// this way I am ensuring that I don't have an empty word1 or word2 sequence.
			for(int i=0;i<word1.Length;++i){
				for(int j=0;j<word2.Length;++j){
					if(word1[i] == word2[j]){
						ans = Math.Max(ans, 2 + memo[i+1, word1.Length + j - 1]);       
					}
				}
			}

			return ans;
		}
	}
}