using System;

// https://leetcode.com/problems/minimum-depth-of-binary-tree/
namespace _csharp
{
	public class _111_minimum_depth_of_binary_tree
	{
		public int MinDepth(TreeNode root) {
			if(root == null) return 0;

			return dfs(root) + 1;
		}

		private int dfs(TreeNode node){
			if(node == null) return int.MaxValue - 1;

			if(node.left==null && node.right==null) return 0;

			int l = dfs(node.left) + 1;
			int r = dfs(node.right) + 1;

			return Math.Min(l,r);
		}
	}
}