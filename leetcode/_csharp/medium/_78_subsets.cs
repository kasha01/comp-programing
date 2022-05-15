using System;
using System.Collections.Generic;

// https://leetcode.com/problems/subsets/
// tags: backtrack
namespace _csharp
{
	public class _78_subsets
	{
		// bit manipulation O(n * 2^n)
		public IList<IList<int>> Subsets(int[] nums) {
			int n = nums.Length;
			int m = 1<<n;   // 2^n

			List<List<int>> ans = new List<List<int>>();
			ans.Add(new List<int>());

			for(int i=1;i<m;++i){
				List<int> temp = new List<int>();
				for(int j=0;j<n;++j){
					if( ((1<<j) & i) != 0 ){
						temp.Add(nums[j]);
					}
				}

				ans.Add(temp);
			}

			return ans.ToArray();
		}

		// recursion O(n * 2^n)
		public IList<IList<int>> Subsets_rc(int[] nums) {
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

