using System;

// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
namespace _csharp
{
	public class _153_find_minimum_in_rotated_sorted_array
	{
		public int FindMin(int[] nums) {
			int lo=0; int hi=nums.Length-1;
			while(lo<hi){
				int mid = (hi-lo)/2 + lo;

				if(nums[lo] > nums[mid]){
					// 1st half is descending. count the mid in b/c nums[mid]<nums[lo]
					hi = mid;
				}
				else if(nums[mid] > nums[hi]){
					// 2nd half is descending
					lo = mid+1;
				}
				else{
					// both halves are in order..break. nums[lo] is the answer.
					break;
				}
			}

			return nums[lo];
		}
	}
}