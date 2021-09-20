using System;

// https://leetcode.com/problems/target-sum/
namespace _csharp
{
	// brute force
	public class _494_target_sum
	{
		public int FindTargetSumWays(int[] nums, int S) {
			return rc(0,0,nums,S);
		}

		public int rc(int i, int sum, int[] nums, int S){
			if(i >= nums.Length){
				if(sum == S) return 1;
				return 0;
			}

			return rc(i+1, sum + nums[i], nums, S) + rc(i+1, sum - nums[i], nums, S);
		}

		// ****************************************************************************** //
		// memoization solution
		public int FindTargetSumWaysMemo(int[] nums, int S) {
			int[,] memo = new int[nums.Length, 2001];
			for(int i=0;i<nums.Length;++i){
				for(int j=0;j<2001;++j){
					memo[i,j] = 5000;
				}
			}
			return rcMemo(0,0,nums,S, memo);
		}

		public int rcMemo(int i, int sum, int[] nums, int S, int[,] memo){
			if(i >= nums.Length){
				if(sum == S) return 1;
				return 0;
			}

			int sumIndex = sum + 1000;

			if(memo[i,sumIndex]!= 5000)
				return memo[i,sumIndex];

			memo[i,sumIndex] = rcMemo(i+1, sum + nums[i], nums, S, memo) + rcMemo(i+1, sum - nums[i], nums, S, memo);
			return memo[i,sumIndex];
		}
	}
}