using System;
using System.Collections.Generic;

// https://leetcode.com/problems/count-number-of-nice-subarrays/
namespace _csharp
{
	public class _1248_count_number_of_nice_subarrays
	{
		public int NumberOfSubarrays(int[] nums, int k) {
			// key: count of 1s | value: how many nums items have this count of 1s
			Dictionary<int,int> prefix = new Dictionary<int,int>();
			prefix.Add(0,1);

			int ans = 0;
			int sum = 0;
			for(int i=0;i<nums.Length;++i){
				if((nums[i] & 1) == 1){
					// odd number
					sum = sum + 1;
				}

				if(prefix.ContainsKey(sum-k)){
					ans = ans + prefix[sum-k];    
				}

				if(!prefix.ContainsKey(sum)){
					prefix.Add(sum,0);
				}
				++prefix[sum];
			}

			return ans;
		}
	}
}