using System;

// https://leetcode.com/problems/product-of-array-except-self/
namespace _csharp
{
	public class _238_product_of_array_except_self
	{
		public int[] ProductExceptSelf(int[] nums) {
			int n = nums.Length;
			int[] prod1 = new int[n];
			int[] prod2 = new int[n];
			int[] ans = new int[n];

			int p=1;
			for(int i=0;i<n;++i){
				p=p*nums[i];
				prod1[i]= p;
			}

			p=1;
			for(int i=n-1;i>=0;--i){
				p=p*nums[i];
				prod2[i]= p;
			}

			for(int i=0;i<n;++i){
				int p1 = i-1 >= 0 ? prod1[i-1] : 1; 
				int p2 = i+1 <  n ? prod2[i+1] : 1;
				ans[i] = p1*p2;
			}

			return ans;
		}
	}
}

