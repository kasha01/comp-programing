using System;

// https://leetcode.com/problems/sum-of-all-odd-length-subarrays/
namespace _csharp
{
	public class _1588_sum_of_all_odd_length_subarrays
	{
		public int SumOddLengthSubarrays(int[] arr) {
			int n = arr.Length;
			int sum = 0;

			for(int i=0;i<n;++i){
				int l = i+1;
				int r = n-i;

				int m = l*r;
				int c = (m/2) + (m%2);

				sum = sum + (c*arr[i]);
			}

			return sum;
		}
	}
}