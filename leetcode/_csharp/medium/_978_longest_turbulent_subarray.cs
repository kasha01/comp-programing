using System;

// https://leetcode.com/problems/longest-turbulent-subarray/
namespace _csharp
{
	public class _978_longest_turbulent_subarray
	{
		public int MaxTurbulenceSize(int[] arr) {
			int n = arr.Length;

			if(n==1)
				return 1;

			int mx=0; int c=1;
			int a=0; int ai=0;
			int b=0; int bi=1;
			bool a_must_be_greater_than_b = true;

			while(bi<n){
				a=arr[ai]; b=arr[bi];
				if(a==b){
					c=1;
				}
				else{
					if(a_must_be_greater_than_b){
						if(a>b){
							++c;
							a_must_be_greater_than_b = !a_must_be_greater_than_b;
						}
						else{
							c=2;
						}
					}
					else{
						if(a<b){
							++c;
							a_must_be_greater_than_b = !a_must_be_greater_than_b;
						}
						else{
							c=2;
						}
					}
				}

				mx = Math.Max(c,mx);
				++ai; ++bi;
			}

			return mx;
		}
	}
}

