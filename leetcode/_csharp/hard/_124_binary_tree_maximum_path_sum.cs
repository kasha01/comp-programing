using System;

// https://leetcode.com/problems/binary-tree-maximum-path-sum/
namespace _csharp
{
	public class _124_binary_tree_maximum_path_sum
	{
		int maxSum = -2000;
		public int MaxPathSum(TreeNode root) {
			solve(root);
			return maxSum;
		}

		private int solve(TreeNode root){
			if(root == null)
				return 0;

			int l = solve(root.left);
			int r = solve(root.right);

			int s1 = root.val + l;
			int s2 = root.val + r;
			int s3 = root.val + l + r;
			int s4 = root.val;

			maxSum = Math.Max(maxSum,Math.Max(s1, Math.Max(s2,Math.Max(s3,s4))));

			return Math.Max(Math.Max(l,r) + root.val, root.val);
		}
	}
}