using System;
using System.Collections.Generic;

// https://leetcode.com/problems/minimum-distance-between-bst-nodes/
namespace _csharp
{
	public class _783_minimum_distance_between_bst_nodes
	{
		class TreeNode {
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
				this.val = val;
				this.left = left;
				this.right = right;
			}
		}

		static void driver(){
			TreeNode root = new TreeNode (4);
			TreeNode n1 = new TreeNode (2);
			TreeNode n2 = new TreeNode (6);
			TreeNode n3 = new TreeNode (1);
			TreeNode n4 = new TreeNode (3);

			root.left = n1;
			root.right = n2;
			n1.left = n3;
			n1.right = n4;				

			list.Clear ();
			in_order (root);
			int r = solve ();
			Console.WriteLine (r);
		}

		static List<int> list = new List<int>();
		static void in_order(TreeNode root){
			if (root == null)
				return;

			in_order (root.left);
			list.Add (root.val);
			in_order (root.right);
		}

		static int solve(){
			int mx = Int16.MaxValue;
			int a = list [0];
			for (int i = 1; i < list.Count; ++i) {
				int b = list [i];

				mx = Math.Min (mx, Math.Abs (b - a));

				a = b;
			}

			return mx;
		}
	}
}