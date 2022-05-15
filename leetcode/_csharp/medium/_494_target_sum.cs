using System;

// https://leetcode.com/problems/target-sum/
namespace _csharp
{
	public class _494_target_sum
	{
		public int FindTargetSumWays(int[] nums, int S) {
			int[,] memo = new int[nums.Length, 2001];   // target cannot exceeds 2000 possibilities [-1000,1000]
			return rc(0,0,nums,S, memo);
		}

		public int rc(int i, int sum, int[] nums, int S, int[,] memo){
			if(i >= nums.Length){
				if(sum == S) return 1;

				return 0;
			}

			int sumIndex = sum + 1000;

			if(memo[i,sumIndex] > 0)
				return memo[i,sumIndex] - 1;

			int expressionsCount = rc(i+1, sum + nums[i], nums, S, memo) + rc(i+1, sum - nums[i], nums, S, memo);
			memo[i,sumIndex] = expressionsCount + 1;

			return expressionsCount;
		}
	}
}