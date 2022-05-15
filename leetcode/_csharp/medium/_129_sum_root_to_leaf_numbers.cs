using System;

// https://leetcode.com/problems/sum-root-to-leaf-numbers/
namespace _csharp
{
	public class _129_sum_root_to_leaf_numbers
	{
		public int SumNumbers_better(TreeNode root) {
			return solve_better(root,0);
		}

		private int solve_better(TreeNode root, int sum){
			if(root==null)
				return 0;

			int s = (sum*10)+root.val;

			if(root.left==null && root.right==null){
				return s;    
			}

			return  solve_better(root.left, s) + solve_better(root.right, s);
		}


		// using global variable
		public int SumNumbers(TreeNode root) {
			solve(root,0);
			return grandSum;
		}

		int grandSum = 0;
		private void solve(TreeNode root, int sum){
			if(root==null)
				return;

			int s = (sum*10)+root.val;

			if(root.left==null && root.right==null){
				grandSum = grandSum + s;
				return;    
			}

			solve(root.left, s);
			solve(root.right, s);
		}
	}
}