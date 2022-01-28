using System;
using System.Collections.Generic;

// https://leetcode.com/problems/contiguous-array/
namespace _csharp
{
	public class _525_contiguous_array
	{
		public int FindMaxLength(int[] nums) {
			Dictionary<int,int> presum = new Dictionary<int,int>();

			// key:sum | value:index 
			presum.Add(0,-1);

			int sum = 0; int maxSoFar=0;
			for(int i=0;i<nums.Length;++i){
				int x = nums[i] == 1 ? 1 : -1;
				sum = sum+x;

				if(presum.ContainsKey(sum)){
					maxSoFar = Math.Max(maxSoFar, i - presum[sum]);
				}
				else{
					presum.Add(sum,i);
				}
			}

			return maxSoFar;
		}
	}
}