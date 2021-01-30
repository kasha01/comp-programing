using System;

// https://leetcode.com/problems/longest-palindromic-substring/solution/
namespace _csharp
{
	public class _5_longest_palindromic_substring
	{
		public string LongestPalindrome(string s) {
			if(s == null || s.Length == 0){
				return "";
			}

			int n = s.Length;
			int maxLength=1;
			int a=0; int b=-1;

			var memo = new bool[n,n];
			for(int i=0; i<n;++i){
				memo[i,i]=true; 
			}

			for(int l=2;l<=n;++l){
				for(int start=0;start<=n-l;++start){
					int end = start+l-1;

					bool memoValue = true;
					if(l>2){
						memoValue = memo[start+1,end-1];
					}

					if(s[start] == s[end] && memoValue){
						memo[start,end] = true;

						if(end-start+1 > maxLength){
							maxLength = end-start+1;
							a=start; b = end;
						}
					}
					else{
						memo[start,end] = false;
					}
				}
			}

			string result = s.Substring(a,maxLength);

			return result;
		}
	}
}

