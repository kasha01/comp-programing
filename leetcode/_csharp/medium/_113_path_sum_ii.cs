using System;
using System.Collections.Generic;

// https://leetcode.com/problems/path-sum-ii/
namespace _csharp
{
	public class _113_path_sum_ii
	{
		private List<List<int>> ans;
		public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
			ans = new List<List<int>>();
			fn(root, new List<int>(), 0, targetSum);
			return ans.ToArray();
		}

		private void fn(TreeNode root, List<int> list, int sum, int targetSum){
			if(root == null) return;

			if(root.left==null && root.right==null){
				if(sum + root.val == targetSum){
					var l = new List<int>(list);
					l.Add(root.val);
					ans.Add(l);
				}
				return;
			}

			list.Add(root.val);
			fn(root.left, list, sum + root.val, targetSum);
			fn(root.right, list, sum + root.val, targetSum);
			list.RemoveAt(list.Count - 1);
		}
	}
}