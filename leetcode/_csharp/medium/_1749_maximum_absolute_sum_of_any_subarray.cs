using System;

// https://leetcode.com/problems/maximum-absolute-sum-of-any-subarray/
namespace _csharp
{
	public class _1749_maximum_absolute_sum_of_any_subarray
	{
		public int MaxAbsoluteSum(int[] nums) {
			int n = nums.Length;
			int localSumMax = nums[0];
			int localSumMin = nums[0];
			int maxSum = Math.Abs(nums[0]);

			for(int i=1;i<n;++i){
				if(localSumMax + nums[i] < nums[i]){
					localSumMax=0;
				}

				if(localSumMin + nums[i] > nums[i]){
					localSumMin=0;
				}

				localSumMax = nums[i] + localSumMax;
				localSumMin = nums[i] + localSumMin;

				maxSum = Math.Max(maxSum, Math.Max(Math.Abs(localSumMax), Math.Abs(localSumMin)));
			}

			return maxSum;
		}
	}
}