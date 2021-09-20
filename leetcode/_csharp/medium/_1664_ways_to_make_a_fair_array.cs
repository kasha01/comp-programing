using System;

// https://leetcode.com/problems/ways-to-make-a-fair-array/
namespace _csharp
{
	public class _1664_ways_to_make_a_fair_array
	{
		public int WaysToMakeFair(int[] nums) {
			int n = nums.Length;
			int[] memo_even_left = new int[n];
			int[] memo_odd_left = new int[n];
			int[] memo_even_right = new int[n];
			int[] memo_odd_right = new int[n];

			int even=0; int odd=0;
			for(int i=0;i<n;++i){
				if(i%2 == 0){
					even = even + nums[i];                
				}
				else{
					odd = odd + nums[i];
				}
				memo_even_left[i] = even;
				memo_odd_left[i] = odd;
			}

			even=0; odd=0;
			for(int i=n-1;i>=0;--i){
				if(i%2 == 0){
					even = even + nums[i];
				}
				else{
					odd = odd + nums[i];
				}
				memo_even_right[i] = even;
				memo_odd_right[i] = odd;
			}

			int ans = 0;
			for(int i=0; i<n; ++i){
				// removing i index
				int ev = i>0 ? memo_even_left[i-1] : 0;
				int od = i>0 ? memo_odd_left[i-1] : 0;

				ev = i+1<n ? ev + memo_odd_right[i+1] : ev;
				od = i+1<n ? od + memo_even_right[i+1] : od;

				if (ev == od)
					ans++;
			}

			return ans;
		}
	}
}