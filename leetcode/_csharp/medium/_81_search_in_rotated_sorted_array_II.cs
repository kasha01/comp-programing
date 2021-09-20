using System;

// https://leetcode.com/problems/search-in-rotated-sorted-array-ii/
namespace _csharp
{
	public class _81_search_in_rotated_sorted_array_II
	{
		public bool Search(int[] nums, int target) {
			int lo = 0; int hi = nums.Length-1;

			while(lo<=hi){
				int mid = lo + (hi-lo)/2;

				if(nums[mid] == target)
					return true;

				if(nums[lo] == nums[mid]){
					while(lo<=mid && nums[lo] == nums[mid]){
						lo++;
					}
					continue;   // to recompute lo,hi,mid
				}

				if(nums[hi] == nums[mid]){
					while(hi>=mid && nums[hi] == nums[mid]){
						hi--;
					}
					continue;   // to recompute lo,hi,mid
				}

				if(nums[mid] < nums[hi]){
					// right half is in order
					if(target > nums[mid] && target <= nums[hi]){
						// target is within the range of the in-order right half
						lo = mid+1;
					}
					else{
						// otherwise, target must be in the left half.
						hi = mid-1;                    
					}
				}
				else{
					// left half is in order (since right half is not)
					if(target >= nums[lo] && target < nums[mid]){
						// target is within the range of in-order left half.
						hi = mid-1;
					}
					else{
						// otherwise, target must be in the right half.
						lo = mid+1;
					}
				}
			}

			return false;
		}
	}
}