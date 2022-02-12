using System;

// https://leetcode.com/problems/break-a-palindrome/
namespace _csharp
{
	public class _1328_break_a_palindrome
	{
		public string BreakPalindrome(string palindrome) {
			int n = palindrome.Length;
			int m = n/2;

			if(n<=1)
				return "";

			for(int i=0;i<m;++i){
				var c = palindrome[i];
				if(c > 'a')
					return palindrome.Substring(0,i) + 'a' + palindrome.Substring(i+1,n-i-1);
			}

			return palindrome.Substring(0,n-1) + 'b';
		}
	}
}