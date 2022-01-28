using System;

// https://leetcode.com/problems/diameter-of-binary-tree/
namespace _csharp
{
	public class _543_diameter_of_binary_tree
	{
		int diameter=0;
		public int DiameterOfBinaryTree(TreeNode root) {
			dfs(root);
			return diameter;
		}

		private int dfs(TreeNode node){
			if(node == null) return 0;

			int l = node.left != null ? dfs(node.left) + 1 : 0;
			int r = node.right != null ? dfs(node.right) + 1 : 0;

			diameter = Math.Max(diameter,l+r);

			return Math.Max(l,r);
		}
	}
}