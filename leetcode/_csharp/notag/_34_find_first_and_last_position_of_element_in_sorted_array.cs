using System;

// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
namespace _csharp
{
	public class _34_find_first_and_last_position_of_element_in_sorted_array
	{
		public int[] SearchRange(int[] nums, int target) {
			int n = nums.Length;
			if(n==0)
				return new[] {-1,-1};

			int index = bs(nums, target, 0, n-1);
			if(index == -1){
				return new[] {-1,-1};
			}

			int resLo=index; int resHi=index;
			int lo=index; int hi=index;

			if(index == 0){
				resLo=0; lo=-1;
			}

			if(index == n-1){
				resHi=n-1; hi=-1;
			}

			while(lo!=-1 || hi!=-1){
				if(lo!=-1){
					lo = bs(nums, target, 0, lo-1);   
				}

				if(hi!=-1){
					hi = bs(nums, target, hi+1,n-1);   
				}

				if(lo!=-1){
					resLo = Math.Min(lo,resLo);
				}

				if(hi!=-1){
					resHi = Math.Max(hi,resHi);
				}
			}

			return new[]{resLo, resHi};
		}

		int bs(int[] nums, int target, int l, int h){

			if(h>=l){
				int m = l + (h-l)/2;

				if(nums[m] == target)
					return m;

				else if(nums[m] > target)
					return bs(nums, target, l, m-1);

				else if(nums[m] < target)
					return bs(nums, target, m+1, h);
			}
			return -1;
		}
	}
}