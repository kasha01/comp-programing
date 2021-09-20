using System;
using System.Collections.Generic;

// https://leetcode.com/problems/divide-array-in-sets-of-k-consecutive-numbers/
namespace _csharp
{
	public class _1296_divide_array_in_sets_of_k_consecutive_numbers
	{
		public bool IsPossibleDivide(int[] nums, int k) {
			int n = nums.Length;
			if(n%k!=0)
				return false;

			Dictionary<int,int> map = new Dictionary<int,int>();
			foreach(int x in nums){
				if(!map.ContainsKey(x))
					map.Add(x,0);

				map[x]++;            
			}

			Array.Sort(nums);

			for(int i=0;i<n;++i){
				int head = nums[i];
				if(map[head]==0){
					// this value was used before. skip it
					continue;
				}

				int c = 1;
				int j = 0;
				while(c<=k){
					if(!map.ContainsKey(head+j))
						return false;

					if(map[head+j]==0)
						return false;

					--map[head+j];
					++j; ++c;
				}
			}

			return true;
		}
	}
}