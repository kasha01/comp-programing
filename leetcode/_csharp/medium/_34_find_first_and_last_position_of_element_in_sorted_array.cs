using System;

// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
namespace _csharp
{
	public class __34_find_first_and_last_position_of_element_in_sorted_array
	{
		public int[] SearchRange(int[] nums, int target) {
			int leftBound = getLeftBound(nums, target);
			if(leftBound == -1)
				return new int[2]{-1,-1};

			int rightBound = getRightBound(nums, target);

			return new int[2]{leftBound,rightBound};
		}

		private int getLeftBound(int[] nums, int target){
			int ans = -1;
			int lo=0; int hi=nums.Length-1;

			while(lo<=hi){
				int mid = lo + (hi-lo)/2;

				if(nums[mid] >= target){
					ans = nums[mid] == target ? mid : ans;
					hi = mid-1;
				}
				else{
					lo = mid+1;
				}
			}

			return ans;
		}

		private int getRightBound(int[] nums, int target){
			int ans = -1;
			int lo=0; int hi=nums.Length-1;

			while(lo<=hi){
				int mid = lo + (hi-lo)/2;

				if(nums[mid] <= target){
					ans = nums[mid] == target ? mid : ans;
					lo = mid+1;
				}
				else{
					hi = mid-1;
				}
			}

			return ans;
		}
	}
}