using System;

// https://leetcode.com/problems/find-peak-element/
namespace _csharp
{
	public class _162_find_peak_element
	{
		public int FindPeakElement(int[] nums) {
			int n = nums.Length;

			int peak=0;
			int lo=0; int hi=n-1;

			while(lo<hi){
				int mid = lo + (hi-lo)/2;

				if(nums[mid] <= nums[mid+1]){
					//asc
					peak = mid+1;
					lo = mid+1;
				}
				else{
					hi = mid;
				}
			}

			Console.WriteLine (peak);
			return peak;
		}

		public int FindMinPeakElement(int[] nums) {
			int n = nums.Length;

			int peak=0;
			int lo=0; int hi=n-1;

			while(lo<hi){
				int mid = lo + (hi-lo)/2;

				if(nums[mid] >= nums[mid+1]){
					//desc
					peak = mid+1;
					lo = mid+1;
				}
				else{
					hi = mid;
				}
			}

			Console.WriteLine (nums[peak]);
			return peak;
		}
	}
}

