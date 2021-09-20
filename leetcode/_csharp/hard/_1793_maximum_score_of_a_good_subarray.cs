using System;

// https://leetcode.com/problems/maximum-score-of-a-good-subarray/
namespace _csharp
{
	public class _1793_maximum_score_of_a_good_subarray
	{
		public int MaximumScore(int[] nums, int k) {
			int i=k; int j=k; int n = nums.Length;
			int sum = nums[k]; int mn=nums[k];

			while(true){
				if(i-1 < 0 && j+1 >=n) break;

				int l=-1; int r=-1;

				if(i-1>=0){
					l = nums[i-1];
				}

				if(j+1<n){
					r = nums[j+1];
				}

				if(l>r){
					// expand left. I get more max num from expanding left.
					--i; mn = Math.Min(mn, nums[i]);
				}
				else if(l<r){
					// expand right. I get more max num from expanding right.
					++j; mn = Math.Min(mn, nums[j]);
				}
				else{
					// expand both directions as both directions are greedily valid.
					--i; ++j; mn = Math.Min(mn, Math.Min(nums[i],nums[j]));
				}

				sum = Math.Max(sum, mn * (j-i+1)); 
			}             

			return sum;
		}
	}
}

