using System;

// https://leetcode.com/problems/single-element-in-a-sorted-array/
namespace _csharp
{
	public class _540_single_element_in_a_sorted_array
	{
		private int split(int s, int e, int[] nums){
			int n = e-s;

			if(n==0)
				return nums[s];

			int m = (n/2) + s;
			int x = nums[m];
			int a = nums[m-1];
			int b = nums[m+1];

			if(x!=a && x!=b)
				return x;

			if(n==2){
				if(x==a) return b;
				return a;
			}

			if(m%2==0){
				// I have even index median, which means, I have even length left&right side arrays
				if(x==a){
					// i took from the right side array which made it odd, pass in right side
					return split(s, m-2, nums);    
				}
				// else i took from the left side array which made it odd, pass in left side.
				return split(m+2,e,nums);
			}

			//Else I have odd index median, which means, I have odd length left&right side arrays
			if(x==a){            
				// i took from the left side array which made it even, pass in right side
				return split(m+1,e,nums);
			}
			// else i took from the rigth side array which made it even, pass in left side.
			return split(s,m-1,nums);
		}
	}
}

