using System;

// https://leetcode.com/problems/largest-odd-number-in-string/
namespace _csharp
{
	public class _1903_largest_odd_number_in_string
	{
		public string LargestOddNumber(string num) {
			int n = num.Length;
			int j = -1;
			for(int i=n-1;i>=0;--i){
				int x = num[i] - '0';
				if(x%2 != 0){
					j = i;
					break;
				}
			}

			return j==-1 ? "" : num.Substring(0,j+1);
		}		
	}
}