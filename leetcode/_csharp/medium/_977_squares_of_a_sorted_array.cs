using System;

// https://leetcode.com/problems/squares-of-a-sorted-array/
namespace _csharp
{
	public class _977_squares_of_a_sorted_array
	{
		public int[] SortedSquares(int[] nums) {
			int l=0; int r = nums.Length-1;
			var ans = new int[r+1];

			int k = r;
			while(l<=r){
				int left = Math.Abs(nums[l]);
				int right = Math.Abs(nums[r]);

				if(right > left){
					ans[k] = nums[r] * nums[r]; --k; --r;
				}
				else{
					ans[k] = nums[l] * nums[l]; --k; ++l;
				}
			}

			return ans;
		}
	}
}

