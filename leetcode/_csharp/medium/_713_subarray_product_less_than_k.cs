using System;

// https://leetcode.com/problems/subarray-product-less-than-k/
namespace _csharp
{
	public class _713_subarray_product_less_than_k
	{
		public int NumSubarrayProductLessThanK(int[] nums, int k) {
			int l=0; int r=0; int p=1;
			int n = nums.Length;
			int sum=0;

			while(r<n){
				p = p * nums[r];

				while(p>=k && l<r){
					p=p/nums[l];
					++l;                
				}

				if(p<k)
					sum = sum + (r-l+1);        

				++r;
			}

			return sum;
		}
	}
}

