using System;

// https://leetcode.com/problems/longest-univalue-path/
namespace _csharp
{
	public class TreeNode {
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
			this.val = val;
			this.left = left;
			this.right = right;
		}
	}

	public class longest_univalue_path
	{
		public static void driver ()
		{
			TreeNode root = new TreeNode (5);
			TreeNode n1 = new TreeNode (5);
			TreeNode n2 = new TreeNode (4);
			TreeNode n3 = new TreeNode (4);
			TreeNode n4 = new TreeNode (5);
			TreeNode n5 = new TreeNode (1);
			TreeNode n6 = new TreeNode (1);

			root.left = n1;
			root.right = n2;
			n2.left = n5;
			n2.right = n6;
			n1.left = n3;
			n1.right = n4;

			rc (root);
			Console.WriteLine (mx);
		}

		static int mx = 1;
		static int rc(TreeNode root){
			if (root == null)
				return 0;

			int l = rc (root.left);
			int r = rc (root.right);

			int s = 1;
			int sl = 1;
			if (root.left != null && root.val == root.left.val) {
				s = s + l;
				sl = sl + l;
			}

			int sr = 1;
			if (root.right != null && root.val == root.right.val) {
				s = s + r;
				sr = sr + r;
			}

			mx = Math.Max (s, mx);
			return Math.Max (sr, sl);
		}
	}
}

