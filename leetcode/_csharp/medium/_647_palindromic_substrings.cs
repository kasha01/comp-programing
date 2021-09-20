using System;

// https://leetcode.com/problems/palindromic-substrings/
namespace _csharp
{
	public class _647_palindromic_substrings
	{
		public int CountSubstrings(string s) {
			int n = s.Length;
			bool[,] memo = new bool[n,n];

			for(int i=0;i<n;++i){
				memo[i,i] = true;
			}

			int c=n;
			for(int l=2;l<=n;++l){
				for(int i=0;i<=n-l;++i){
					int j = i+l-1;

					bool prev = l==2 ? true : memo[i+1,j-1];

					if(s[i] == s[j] && prev){
						++c;
						memo[i,j] = true;
					}
					else{
						memo[i,j] = false;
					}
				}
			}

			return c;
		}
	}
}