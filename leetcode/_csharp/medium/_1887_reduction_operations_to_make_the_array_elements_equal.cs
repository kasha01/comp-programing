using System;

// https://leetcode.com/problems/reduction-operations-to-make-the-array-elements-equal/
namespace _csharp
{
	public class _1887_reduction_operations_to_make_the_array_elements_equal
	{
		public int ReductionOperations(int[] nums) {
			Array.Sort(nums);
			int n = nums.Length;

			int l = n-2; int r=n-1;
			int ans = 0;

			while(l>=0){
				if(nums[l] < nums[r]){
					int d = n-1-l;
					ans = ans + d;

					r=l;
				}

				--l;
			}        

			return ans;
		}
	}
}