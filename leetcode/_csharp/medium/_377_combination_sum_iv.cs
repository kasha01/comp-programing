using System;

// https://leetcode.com/problems/combination-sum-iv/
namespace _csharp
{
	public class _377_combination_sum_iv
	{
		int[] memo;
		public int CombinationSum4(int[] nums, int target) {
			memo = new int[1001];
			for(int i=0;i<1001;++i)
				memo[i] = -1;

			Array.Sort(nums);
			return rc(0,nums,target);
		}

		private int rc(int sum, int[] nums, int target){
			if(sum==target)
				return 1;

			if(sum>target)
				return 0;

			if(memo[sum]!=-1)
				return memo[sum];

			int s = 0;
			for(int i=0;i<nums.Length;++i){
				int x = sum + nums[i];
				if(x>target)
					break;

				s = s + rc(x,nums,target);
			}

			memo[sum]=s;
			return s;
		}
	}
}