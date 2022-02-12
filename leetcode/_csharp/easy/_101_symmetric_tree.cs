using System;

// https://leetcode.com/problems/symmetric-tree/
namespace _csharp
{
	public class _101_symmetric_tree
	{
		public bool IsSymmetric(TreeNode root) {
			if(root==null) return false;
			return isMirror(root.left, root.right);
		}

		public bool isMirror(TreeNode leftNode, TreeNode rightNode){
			if(leftNode==null && rightNode==null)
				return true;

			if(leftNode==null || rightNode==null)
				return false;

			if(leftNode.val != rightNode.val)
				return false;

			return
				isMirror(leftNode.left, rightNode.right) && 
				isMirror(leftNode.right, rightNode.left);
		}
	}
}