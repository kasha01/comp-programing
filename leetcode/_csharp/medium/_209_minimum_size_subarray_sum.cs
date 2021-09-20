using System;

// https://leetcode.com/problems/minimum-size-subarray-sum/
namespace _csharp
{
	public class _209_minimum_size_subarray_sum
	{
		public int MinSubArrayLen(int target, int[] nums) {
			int r=0; int l=0; int n=nums.Length;
			int mn=int.MaxValue;
			int sum = 0;

			while(r<n){
				sum = sum + nums[r];

				while(sum>target && l<=r){
					if(sum - nums[l] < target)
						break;

					sum = sum - nums[l];
					++l;
				}

				if(sum >= target && r-l+1 < mn){
					mn = r-l+1;
				}

				++r;
			}

			if(sum < target)
				return 0;

			return mn;
		}
	}
}