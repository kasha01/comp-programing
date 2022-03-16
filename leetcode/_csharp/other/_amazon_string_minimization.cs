using System;

namespace _csharp
{
	// https://leetcode.com/discuss/interview-question/883784/Amazon-String-minimization
	public class _amazon_string_minimization
	{
		int solve(string s) {
			int l = 0;
			int r = s.Length - 1;
			while (l < r && s[l] == s[r]) {
				int c = s[l];
				while (l < r && s[l] == c) l++;
				while (l <= r && s[r] == c) r--;
			}
			return r - l + 1;
		}
	}
}

