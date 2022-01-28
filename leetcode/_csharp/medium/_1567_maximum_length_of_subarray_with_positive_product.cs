using System;

// https://leetcode.com/problems/maximum-length-of-subarray-with-positive-product/
namespace _csharp
{
	public class _1567_maximum_length_of_subarray_with_positive_product
	{
		public int GetMaxLen(int[] nums) {
			int n = nums.Length;
			int first_negative = -1; int last_negative=-1;
			int p = 1; int l=0; int ans = 0;

			for(int i=0;i<n;++i){
				if(nums[i]==0){                
					l=0; first_negative=-1; last_negative=-1; p=1;
				}
				else{
					p = p * (nums[i] > 0 ? 1 : -1);     // we do this because p will eventually overflow, we just
					// need to know if p is +/- ve
					++l;

					if(nums[i]<0){
						if(first_negative==-1){
							first_negative= l;
						}
						else{
							last_negative = l;
						}
					}

					if(p>0){
						ans = Math.Max(ans,l);
					}
					else{
						// if p<0 that means there is an odd count of negative values, get the max distance if I get
						// rid of the first negative or the last negative.
						int d1 = l - first_negative;
						int d2 = last_negative > -1 ? last_negative -1 : -1;
						ans = Math.Max(ans, Math.Max(d1,d2));
					}
				}
			}

			return ans;
		}
	}
}