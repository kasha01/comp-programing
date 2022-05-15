using System;
using System.Collections.Generic;

// tags: permutation backtracking

// https://leetcode.com/problems/permutations-ii/
namespace _csharp
{
	public class _47_permutations_ii
	{
		public IList<IList<int>> PermuteUnique(int[] nums) {
			Array.Sort(nums); 
			int n = nums.Length;
			backtrack(new List<int>(), new bool[n], n , nums);
			return ans.ToArray();
		}

		List<List<int>> ans = new List<List<int>>();
		private void backtrack(List<int> temp, bool[] used, int n, int[] nums){
			if(temp.Count == n){
				var list = new List<int>();
				list.AddRange(temp);
				ans.Add(list);
				return;
			}

			for(int i=0;i<n;++i){
				if(used[i]) continue;
				if((i>0 && used[i-1] && nums[i] == nums[i-1])) continue;

				used[i] = true;
				temp.Add(i);
				backtrack(temp,used,n,nums);
				temp.RemoveAt(temp.Count - 1);
				used[i] = false;
			}
		}
	}
}