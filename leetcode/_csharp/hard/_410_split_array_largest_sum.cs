using System;

// https://leetcode.com/problems/split-array-largest-sum/
namespace _csharp
{
	public class _410_split_array_largest_sum
	{

		// dp solution
		int[,] dp;
		public int SplitArray(int[] nums, int m) {
			int n = nums.Length;
			dp = new int[n+1,m+1];

			return fn(0,m,n,nums);
		}

		private int fn(int start, int m, int n, int[] nums){
			if(m==0 && start==n)
				return 0;

			if(m==0 || start>=n) return -1;

			if(dp[start,m]>0) return dp[start,m]-1;

			int sum = 0; int minGlobalSum=int.MaxValue-1;
			for(int i=start;i<n;++i){
				sum = sum + nums[i];

				int ret = fn(i+1,m-1,n,nums);

				if(ret==-1) continue;

				int largestSum = Math.Max(sum,ret);                 // maximize sum among differet blocks
				minGlobalSum = Math.Min(minGlobalSum,largestSum);   // pick the minimum of all these sums
			}

			dp[start,m] = minGlobalSum + 1;
			return minGlobalSum;
		}


		// binary search solution
		public int SplitArray_binary_search(int[] nums, int m) {
			int n = nums.Length;

			int sum = 0;
			foreach(int x in nums){
				sum = sum + x;
			}

			int lo = 0; int hi=sum; int ans = 0;
			while(lo<=hi){
				int mid = lo + (hi-lo)/2;
				if(isValid(mid, m, nums)){
					ans = mid;
					hi=mid-1;
				}
				else{
					lo=mid+1;
				}
			}

			return ans;
		}

		private bool isValid(int sumLimit, int m, int[] nums){
			// sum cannot exceed sumLimit

			int sum = 0; int i=0;
			while(i<nums.Length && m>0){
				if(sum + nums[i] > sumLimit){
					sum = 0;
					--m;
					continue;
				}
				else{
					sum = sum + nums[i];
				}

				++i;
			}

			return m>0;
		}
	}
}