using System;

// https://leetcode.com/problems/maximum-subarray/
namespace _csharp
{
	public class _53_maximum_subarray
	{
		public int MaxSubArray(int[] nums) {
			int n = nums.Length;
			int localSum = nums[0];
			int maxSum = nums[0];

			for(int i=1;i<n;++i){
				if(localSum + nums[i] < nums[i]){
					localSum = 0;
				}

				localSum = localSum + nums[i];
				maxSum = Math.Max(maxSum, localSum);
			}

			return maxSum;
		}
	}
}