using System;
using System.Collections.Generic;

// https://leetcode.com/problems/subsets-ii/
// tags: backtrack
namespace _csharp
{
	public class _90_subsets_ii
	{
		public IList<IList<int>> SubsetsWithDup(int[] nums) {
			Array.Sort(nums);

			backtrack(0,new List<int>(), nums.Length, nums);

			return ans.ToArray();
		}

		List<List<int>> ans = new List<List<int>>();
		private void backtrack(int start, List<int> temp, int n, int[] nums){
			var list = new List<int>();
			list.AddRange(temp);
			ans.Add(list);

			for(int i=start;i<n;++i){
				if(i>start && nums[i] == nums[i-1]) continue;

				temp.Add(nums[i]);
				backtrack(i+1,temp,n,nums);
				temp.RemoveAt(temp.Count -1);
			}
		}
	}
}

