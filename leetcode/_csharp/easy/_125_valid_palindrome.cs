using System;

// https://leetcode.com/problems/valid-palindrome/
namespace _csharp
{
	public class _125_valid_palindrome
	{
		public bool IsPalindrome(string s) {
			int n = s.Length;
			int i=0; int j=n-1;

			while(i<j){
				while(i<n && !isAlphNumberical(s[i])){
					++i;
				}

				while(j>i && !isAlphNumberical(s[j])){
					--j;
				}

				if(i<j){
					char ic = Char.ToLower(s[i]);
					char jc = Char.ToLower(s[j]);

					if(ic==jc){
						++i; --j;
					}
					else{
						return false;
					}
				}
			}

			return true;
		}

		private bool isAlphNumberical(char c){
			return 
				(c>='a' && c<='z') || (c>='A' && c<='Z') ||
				(c>='0' && c<='9');
		}		
	}
}

