using System;

// https://practice.geeksforgeeks.org/problems/palindrome-numbers/0
namespace GeeksForGeeks_csharp
{
	public class palindrome_numbers
	{
		static bool solve(long n){
			//int bitsCount = (int)(Math.Log10 (n) / Math.Log10 (2)) + 1;
			int bitsCount = log2(n);

			long[] arr = new long[bitsCount];

			for (int k = 0; k < bitsCount; ++k) {
				arr [k] = n & 1;
				n = n >> 1;
			}

			bool isPalindrom = true;
			int i = 0; int j = bitsCount-1;
			while(i<=j){
				if(arr[i] != arr[j]){
					isPalindrom = false;
					break;
				}
				i++;j--;
			}
			return isPalindrom;
		}

		static int log2(long x) 
		{ 
			int res = 0; 
			while (x != 0) {
				res++; 
				x = x >> 1;
			}
			return res; 
		} 
	}
}

