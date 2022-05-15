using System;
using System.Collections.Generic;

// https://leetcode.com/problems/range-sum-of-bst/
namespace _csharp
{
	public class _938_range_sum_of_bst
	{
		public int RangeSumBST(TreeNode root, int L, int R) {
			var list = bst (root, L, R);
			int sum = 0;

			foreach(int x in list)
				sum = sum + x;

			return sum;
		}

		private List<int> bst(TreeNode root, int l, int r){
			if (root == null)
				return new List<int>(0);

			List<int> list = new List<int>();
			if (root.val >= l && root.val <= r) {
				list.Add(root.val);
			}        

			if(root.val > l)
			{
				list.AddRange(bst(root.left,l,r));   
			}

			if(root.val < r){
				list.AddRange(bst(root.right,l,r));    
			}

			return list;
		}


		// solution with global variables
		static int sum = 0;
		static int r = 0;
		static int l = 0;
		private void bst_void(TreeNode root){
			if (root == null)
				return;

			if (root.val >= l && root.val <= r) {
				sum = sum + root.val;
			}        

			if(root.val > l)
			{
				bst_void (root.left);   
			}

			if(root.val < r){
				bst_void (root.right);    
			}
		}
	}
}

