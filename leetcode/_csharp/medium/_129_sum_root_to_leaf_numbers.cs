using System;

// https://leetcode.com/problems/sum-root-to-leaf-numbers/
namespace _csharp
{
	public class _129_sum_root_to_leaf_numbers
	{
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