using System;

// https://leetcode.com/problems/partition-array-for-maximum-sum/
namespace _csharp
{
	public class _1043_partition_array_for_maximum_sum
	{
		public int MaxSumAfterPartitioning(int[] arr, int k) {
			int n = arr.Length;
			int[] memo = new int[n];
			return rc(0,k,arr,memo);
		}

		private int rc(int s, int k, int[] arr, int[] memo){
			if(s>= arr.Length)
			{
				return 0;
			}

			if(memo[s] > 0)
				return memo[s];

			int resultMx = 0;
			int mx=-1;
			for(int i=s; i<arr.Length && i<s+k; ++i){
				mx = Math.Max(mx, arr[i]);
				int localSum = mx * (i-s+1);
				resultMx = Math.Max(resultMx, localSum + rc(i+1, k, arr, memo));
			}
			memo[s] = resultMx;
			return memo[s];
		}
	}
}