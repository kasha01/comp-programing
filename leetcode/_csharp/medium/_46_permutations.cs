using System;
using System.Collections.Generic;

// https://leetcode.com/problems/permutations/
namespace _csharp
{
	public class _46_permutations
	{
		public IList<IList<int>> Permute(int[] nums) {
			int n= nums.Length;
			backtrack(new List<int>(), new bool[n], n, nums);
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

			for(int i=0;i<nums.Length;++i){
				if(used[i]) continue;

				used[i] = true;
				temp.Add(nums[i]);
				backtrack(temp,used,n,nums);
				temp.RemoveAt(temp.Count - 1);
				used[i] = false;
			}
		}
	}
}