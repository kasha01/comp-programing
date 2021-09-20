using System;

// https://leetcode.com/problems/maximum-product-of-three-numbers/
namespace _csharp
{
	public class _28_maximum_product_of_three_numbers
	{
		public int MaximumProduct(int[] nums) {
			int p1 = -2000; int p2 = -2000; int p3 = -2000;
			int n1 = 2000; int n2 = 2000; int m = -2000;

			for(int i=0;i<nums.Length;++i){
				int x = nums[i];
				m = Math.Max(m,x);

				// get the smallest number among p1,p2,p3
				if(p1<=p2){
					if(p1<=p3){
						p1 = Math.Max(p1,x);
					}
					else{
						p3 = Math.Max(p3,x);
					}
				}
				else{
					if(p2<=p3){
						p2 = Math.Max(p2,x);
					}
					else{
						p3 = Math.Max(p3,x);
					}
				}

				// pick the largest among n1,n2
				if(n1>=n2){
					n1 = Math.Min(n1,x);
				}
				else{
					n2 = Math.Min(n2,x);
				}
			}

			return Math.Max(n1*n2*m, p1*p2*p3);
		}
	}
}

