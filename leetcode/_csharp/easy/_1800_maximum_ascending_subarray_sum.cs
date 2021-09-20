using System;

// https://leetcode.com/problems/maximum-ascending-subarray-sum/
namespace _csharp
{
	public class _1800_maximum_ascending_subarray_sum
	{
		public int MaxAscendingSum(int[] nums) {
			int n = nums.Length;
			int prev = nums[0]; int sum = prev; int maxSum=prev;
			for(int i=1;i<n;++i){
				if(nums[i] > prev){
					sum = sum + nums[i];
					prev= nums[i];
				}
				else{
					prev=nums[i];
					sum = prev;
				}

				maxSum = Math.Max(sum, maxSum);
			}

			return maxSum;        
		}
	}
}