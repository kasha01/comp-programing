using System;

// https://leetcode.com/problems/range-sum-of-bst/solution/
namespace _csharp
{
	public class _938_range_sum_of_bst
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

		static int sum = 0;
		static int r = 0;
		static int l = 0;
		static void driver(){
			sum = 0;
			TreeNode root = new TreeNode ();
			bst (root);
		}

		static void bst(TreeNode root){
			if (root == null)
				return;

			if (root.val >= l && root.val <= r) {
				sum = sum + root.val;
			}        

			if(root.val > l)
			{
				bst (root.left);   
			}

			if(root.val < r){
				bst (root.right);    
			}
		}
	}
}

