using System;
using System.Collections.Generic;

// https://leetcode.com/problems/subsets/
// tags: backtrack
namespace _csharp
{
	public class _78_subsets
	{
		public IList<IList<int>> Subsets(int[] nums) {
			ans = new List<List<int>>();
			rc(0,new List<int>(), nums.Length, nums);
			return ans.ToArray();
		}

		private List<List<int>> ans;
		private void rc(int start, List<int> res, int n, int[] nums){
			var list = new List<int>();
			list.AddRange(res);
			ans.Add(list);

			for(int i=start;i<n;++i){
				res.Add(nums[i]);
				rc(i+1,res,n,nums);
				res.RemoveAt(res.Count - 1);
			}
		}
	}
}

