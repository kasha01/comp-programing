using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// https://leetcode.com/problems/shifting-letters/
namespace _csharp
{
	public class _848_shifting_letters
	{
		public string ShiftingLetters(string s, int[] shifts) {
			int n = s.Length - 1;

			StringBuilder sb = new StringBuilder();

			long shift_value = 0;
			while(n>=0){
				shift_value = shift_value + shifts[n];
				char c = s[n];
				long c_numerical = c-'a';
				long c_numerical_shifted = c_numerical + shift_value;
				long c_numerical_shifted_ascii = (c_numerical_shifted)%26 + 'a';
				char shifted_c = Convert.ToChar(c_numerical_shifted_ascii);
				sb.Append(shifted_c);
				--n;
			}

			var arr = sb.ToString().ToCharArray();
			Array.Reverse(arr);
			return new String(arr);
		}
	}
}