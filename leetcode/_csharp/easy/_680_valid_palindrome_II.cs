using System;

// https://leetcode.com/problems/valid-palindrome-ii/
namespace _csharp
{
	public class _680_valid_palindrome_II
	{
		public bool ValidPalindrome(string s) {
			return ValidPalindrome(0,s.Length-1,true,s);
		}

		bool ValidPalindrome(int l, int r, bool canDelete, string s) {
			if (l > r)
				return true;

			if(s[l]==s[r])
				return ValidPalindrome (l + 1, r - 1, canDelete, s);

			return canDelete && (ValidPalindrome (l + 1, r, false, s) || ValidPalindrome (l, r-1, false, s));
		}
	}
}