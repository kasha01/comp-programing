using System;
using System.Collections.Generic;

// https://leetcode.com/problems/maximum-erasure-value/
namespace _csharp
{
	public class _1695_maximum_erasure_value
	{
		public int MaximumUniqueSubarray(int[] nums) {
			HashSet<int> set = new HashSet<int>();

			int i=0; int j=0; int sum=0; int ans=0;

			while(j<nums.Length){
				int x = nums[j];
				sum=sum+x;

				if(set.Contains(x)){
					while(i<j){
						int itemToRemove = nums[i];
						set.Remove(itemToRemove);
						sum = sum - itemToRemove;
						++i;
						if(itemToRemove==x){
							// I removed the duplicate element.
							break;
						}
					}
				}

				set.Add(x);
				ans = Math.Max(ans,sum);
				++j;
			}

			return ans;
		}
	}
}