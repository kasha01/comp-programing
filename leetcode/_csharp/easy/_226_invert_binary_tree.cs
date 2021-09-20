using System;

// https://leetcode.com/problems/invert-binary-tree/
namespace _csharp
{
	public class _226_invert_binary_tree
	{
		public TreeNode InvertTree(TreeNode root) {
			return preOrder(root);
		}

		private TreeNode preOrder(TreeNode root){
			if(root == null)
				return null;

			var newRoot = new TreeNode(root.val);

			newRoot.right = preOrder(root.left);
			newRoot.left = preOrder(root.right);

			return newRoot;
		}
	}
}