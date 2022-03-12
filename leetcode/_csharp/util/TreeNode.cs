using System;

namespace _csharp
{
	public class TreeNode {
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode next;

		public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
			this.val = val;
			this.left = left;
			this.right = right;
		}
	}
}