using System;

// https://leetcode.com/problems/subtree-of-another-tree/
namespace _csharp
{
	public class _572_subtree_of_another_tree
	{
		public bool IsSubtree(TreeNode root, TreeNode subRoot) {
			return dfs(root,subRoot);
		}

		// compare all roots of the main tree agains subRoot
		private bool dfs(TreeNode root, TreeNode subRoot){
			if(root == null || subRoot == null)
				return false;

			// check every root
			if(checkTree(root,subRoot))
				return true;

			// notice here I am keeping the Sub tree root the same.
			return dfs(root.left, subRoot) || dfs(root.right, subRoot);
		}

		private bool checkTree(TreeNode root, TreeNode subRoot){
			if(root == null && subRoot == null)
				return true;

			if(root == null || subRoot == null)
				return false;

			if(root.val != subRoot.val)
				return false;

			return checkTree(root.left, subRoot.left) && checkTree(root.right, subRoot.right);
		}
	}
}