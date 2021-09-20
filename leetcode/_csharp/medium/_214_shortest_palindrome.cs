using System;
using System.Text;

// https://leetcode.com/problems/shortest-palindrome/
namespace _csharp
{
	// O(N^2)...there is a better solution using O(N) with KMP.
	public class _214_shortest_palindrome
	{
		public string ShortestPalindrome(string s) {
			int n = s.Length;
			int k=n-1;
			int j=k; int i=0; 
			while(i<j){
				if(s[i] == s[j]){
					++i; --j;
				}
				else{
					i=0; --k; j=k;
				}
			}

			int lengthOfPalindrome = k+1;

			if(lengthOfPalindrome==n) return s;

			string palindromeInBeginningOfString = s.Substring(0,lengthOfPalindrome);
			string remaining = s.Substring(k+1,n-lengthOfPalindrome);
			string remainingReverse = "";
			//remainingReverse = new string(remaining.Reverse().ToArray());

			return remainingReverse + palindromeInBeginningOfString + remaining;
		}
	}
}

