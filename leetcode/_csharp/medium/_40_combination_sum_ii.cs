using System;
using System.Collections.Generic;

// https://leetcode.com/problems/combination-sum-ii/
namespace _csharp
{
	public class _40_combination_sum_ii
	{
		public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
			Array.Sort(candidates);
			int n = candidates.Length;
			backtrack(0,new List<int>(), 0, n, candidates, target);
			return ans.ToArray();
		}

		List<List<int>> ans = new List<List<int>>();
		private void backtrack(int start, List<int> temp, int sum, int n, int[] candidates, int target){
			if(sum == target){
				var list = new List<int>();
				list.AddRange(temp);
				ans.Add(list);
				return;
			}

			if(sum > target) return;

			for(int i=start;i<n;++i){
				if(i>start && candidates[i] == candidates[i-1]) continue;

				temp.Add(candidates[i]);
				backtrack(i+1,temp,sum+candidates[i],n,candidates,target);
				temp.RemoveAt(temp.Count - 1);
			}
		}
	}
}