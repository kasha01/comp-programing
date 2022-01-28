using System;

// https://leetcode.com/problems/minimum-difference-between-largest-and-smallest-value-in-three-moves/
namespace _csharp
{
	public class _1509_minimum_difference_between_largest_and_smallest_value_in_three_moves
	{
		public int MinDifference(int[] nums) {
			int n = nums.Length;
			if(n<=4) return 0;

			Array.Sort(nums);

			int i=2; int j=n; int d=int.MaxValue;
			for(int x=1;x<=4;++x){
				d = Math.Min(d,nums[j-1] - nums[i+1]);
				--i; --j;
			}

			return d;
		}
	}
}