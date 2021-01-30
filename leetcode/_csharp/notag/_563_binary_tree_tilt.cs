using System;

// https://leetcode.com/problems/binary-tree-tilt/
namespace _csharp
{
	public class _563_binary_tree_tilt
	{
		public int FindTilt(TreeNode root) {
			int sum = 0;
			postOrder(root,ref sum);
			return sum;
		}

		private int postOrder(TreeNode root,ref int sum){
			if(root == null)
				return 0;

			int l = postOrder(root.left,ref sum);
			int r = postOrder(root.right,ref sum);
			int d = Math.Abs(l-r);
			sum = sum + d;
			return l+r+root.val;
		}
	}
}

