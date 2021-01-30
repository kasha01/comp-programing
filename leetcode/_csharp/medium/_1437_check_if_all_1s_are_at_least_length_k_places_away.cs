using System;

// https://leetcode.com/problems/check-if-all-1s-are-at-least-length-k-places-away/
namespace _csharp
{
	public class _1437_check_if_all_1s_are_at_least_length_k_places_away
	{
		public bool KLengthApart(int[] nums, int k) {
			int n = nums.Length;

			int ii=0;
			int a=0;

			// finding first 1
			for(int i=0;i<n;++i){
				if(nums[i] == 1){
					a=i;ii=i+1;
					break;
				}
			}

			for(int i=ii;i<n;++i){
				if(nums[i] == 1){
					if(i-a-1<k){
						return false;
					}
					a=i;
				}
			}

			return true;
		}
	}
}