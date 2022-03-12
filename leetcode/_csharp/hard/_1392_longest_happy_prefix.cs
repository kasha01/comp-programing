using System;

// https://leetcode.com/problems/longest-happy-prefix/
namespace _csharp
{
	public class _1392_longest_happy_prefix
	{
		public string LongestPrefix(string s) {
			int i=1; int j=0; int n = s.Length;
			var lps = new int[n];

			while(i<n && j<n){
				if(s[i] == s[j]){
					lps[i] = j+1;
					++j; ++i;
				}
				else{
					if(j==0){
						++i;
					}
					else{
						j = lps[j-1];
					}
				}
			}

			return s.Substring(0,j);    
		}
	}
}