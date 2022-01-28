using System;

// https://leetcode.com/problems/maximum-difference-between-increasing-elements/
namespace _csharp
{
	public class _2016_maximum_difference_between_increasing_elements
	{
		public int MaximumDifference(int[] nums) {
			int n = nums.Length;
			int[] min_so_far = new int[n];

			int prev = int.MaxValue;
			for(int i=0;i<n;++i){
				min_so_far[i] = Math.Min(prev,nums[i]);
				prev = min_so_far[i];
			}

			int ans = -1;
			for(int i=n-1;i>=0;--i){
				int b = nums[i];
				int a = min_so_far[i];
				int diff = b - a;
				if(diff > 0) ans = Math.Max(diff,ans);
			}

			return ans;
		}
	}
}