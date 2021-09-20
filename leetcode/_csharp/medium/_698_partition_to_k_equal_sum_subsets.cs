using System;

// https://leetcode.com/problems/partition-to-k-equal-sum-subsets/
namespace _csharp
{
	public class _698_partition_to_k_equal_sum_subsets
	{
		public bool CanPartitionKSubsets(int[] nums, int k) {
			int sum = 0;
			foreach(int x in nums){
				sum=sum+x;
			}

			if(sum%k!=0)
				return false;

			int targetSum = sum/k;
			bool[] used = new bool[nums.Length];

			return rc(0, 0, targetSum, used, nums, k);    
		}

		private bool rc(int start, int sumSoFar, int targetSum, bool[] used, int[] nums, int k){
			if(k==0)
				return true;

			if(sumSoFar == targetSum)
				return rc(0, 0, targetSum, used, nums, k-1);

			for(int i=start;i<nums.Length;++i){
				if(used[i] || sumSoFar + nums[i] > targetSum)
					continue;

				used[i] = true;
				bool res = rc(i+1, sumSoFar + nums[i], targetSum, used, nums, k);
				if(res == true)
					return true;

				used[i] = false;
			}

			return false;        
		}
	}
}