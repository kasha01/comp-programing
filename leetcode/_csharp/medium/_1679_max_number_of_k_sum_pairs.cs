using System;

// https://leetcode.com/problems/max-number-of-k-sum-pairs/
namespace _csharp
{
	public class _1679_max_number_of_k_sum_pairs
	{
		public int MaxOperations(int[] nums, int k) {
			Array.Sort(nums);
			int c = 0;
			int i=0; int j = nums.Length-1;
			while(i<j){
				int sum = nums[i] + nums[j];
				if(sum < k){
					++i;
				}
				else if (sum > k){
					--j;
				}
				else{
					++c;
					++i; --j;
				}
			}

			return c;
		}
	}
}

