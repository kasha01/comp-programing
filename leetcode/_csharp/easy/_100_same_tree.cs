using System;

// https://leetcode.com/problems/same-tree/
namespace _csharp
{
	public class _100_same_tree
	{
		public bool IsSameTree(TreeNode p, TreeNode q) {
			if(p==null && q==null)
				return true;

			if((p==null && q!=null) || (p!=null && q==null))
				return false;

			bool areValuesEqual = p.val == q.val;
			if(!areValuesEqual)
				return false;

			bool l = IsSameTree(p.left, q.left);
			bool r = IsSameTree(p.right, q.right);

			return l&&r;
		}
	}
}