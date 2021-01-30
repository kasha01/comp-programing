using System;

// https://leetcode.com/problems/remove-duplicates-from-sorted-array/
namespace _csharp
{
	public class _26_remove_duplicates_from_sorted_array
	{
		public int RemoveDuplicates(int[] nums) {
			int n = nums.Length;

			int newLength = 0;
			int prev = 100000;
			int j = 0;
			for(int i=0;i<n;++i){
				if(nums[i] != prev){
					++newLength;
					nums[j] = nums[i];
					++j;
					prev = nums[i];
				}
			}

			return newLength;
		}
	}
}