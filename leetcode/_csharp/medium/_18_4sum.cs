using System;
using System.Collections.Generic;

// https://leetcode.com/problems/4sum/
// tags: four sum 4sum ksum
namespace _csharp
{
	public class _18_4sum
	{
		public IList<IList<int>> FourSum(int[] nums, int target) {
			Array.Sort(nums);
			return kSum(nums, target, 0, 4).ToArray();
		}

		public List<List<int>> kSum(int[] nums, int target, int start, int k) {
			List<List<int>> res = new List<List<int>>();
			if (start == nums.Length || 
				nums[start] * k > target || 
				(start+target-1 >= 0 && start+target-1 < nums.Length && target > nums[start + target-1] * k)){
				return res;
			}

			if (k == 2)
				return twoSum(nums, target, start);

			for (int i = start; i < nums.Length; ++i)
				if (i == start || nums[i - 1] != nums[i])
					foreach (var set in kSum(nums, target - nums[i], i + 1, k - 1)) {	// reduce k sum into k-1 sum
						res.Add(new List<int>(){nums[i]});
						res[res.Count - 1].AddRange(set);
					}
			return res;
		}

		public List<List<int>> twoSum(int[] nums, int target, int start) {
			List<List<int>> res = new List<List<int>>();
			int lo = start, hi = nums.Length - 1;
			while (lo < hi) {
				int sum = nums[lo] + nums[hi];
				if (sum < target || (lo > start && nums[lo] == nums[lo - 1]))
					++lo;
				else if (sum > target || (hi < nums.Length - 1 && nums[hi] == nums[hi + 1]))
					--hi;
				else
					res.Add(new List<int>(){nums[lo++], nums[hi--]});
			}
			return res;
		}
	}
}