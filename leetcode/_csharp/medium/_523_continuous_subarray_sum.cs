using System;
using System.Collections.Generic;

// https://leetcode.com/problems/continuous-subarray-sum/
namespace _csharp
{
	public class _523_continuous_subarray_sum
	{
		public bool CheckSubarraySum(int[] nums, int k) {
			// key: mod, value: index
			Dictionary<int,int> map = new Dictionary<int,int>();
			int sum = 0;
			map.Add(0,-1);

			for(int i=0;i<nums.Length;++i){
				sum = sum + nums[i];
				int mod = sum%k;

				// if the mod is repeated that means, between i and j (i included), there are numbers whom their mod sum = 0 which means they are
				// multiples of K.
				if(map.ContainsKey(mod)) {
					if(i-map[mod] >=2)
						return true;
				}
				else{
					map.Add(mod,i);   
				}
			}

			return false;
		}
	}
}