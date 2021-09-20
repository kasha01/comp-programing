using System;

// https://leetcode.com/problems/sum-of-beauty-in-the-array/
namespace _csharp
{
	public class _2012_sum_of_beauty_in_the_array
	{
		public int SumOfBeauties(int[] nums) {
			int n = nums.Length;
			int[] min = new int[n];    

			int mn = nums[n-1];
			min[n-1] = nums[n-1];
			for(int i=n-2;i>=0;--i){
				mn = Math.Min(mn, nums[i+1]);
				min[i] = mn;
			}

			int maxSoFar=nums[0];
			int sum = 0;
			for(int i=1;i<n-1;++i){
				maxSoFar = Math.Max(maxSoFar, nums[i-1]);
				int minFromRight = min[i];

				if(maxSoFar < nums[i] && nums[i] < minFromRight){
					sum = sum + 2;
				}
				else if(nums[i-1] < nums[i] && nums[i] < nums[i+1]){
					sum = sum + 1;
				}
			}

			return sum;
		}
	}
}