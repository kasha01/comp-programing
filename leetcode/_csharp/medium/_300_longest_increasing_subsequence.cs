using System;

// https://leetcode.com/problems/longest-increasing-subsequence/
namespace _csharp
{
	public class _300_longest_increasing_subsequence
	{
		// base on patience sort
		public int LengthOfLIS(int[] nums) {
			int n = nums.Length;
			int[] deck = new int[n];
			deck[0] = nums[0];
			int len = 1;

			for(int i=1;i<n;++i){
				int lb = lower_bound(0,len-1,nums[i],deck);

				if(lb == -1){
					deck[len] = nums[i];
					len++;
				}
				else{
					deck[lb] = nums[i];
				}
			}

			return len;
		}

		private int lower_bound(int lo, int hi, int target, int[] arr){
			int ans = -1;
			while(lo<=hi){
				int mid = lo + ((hi-lo)/2);

				if(arr[mid]>=target){
					ans = mid;
					hi = mid-1;
				}
				else{
					lo = mid+1;
				}
			}

			return ans;
		}
	}
}