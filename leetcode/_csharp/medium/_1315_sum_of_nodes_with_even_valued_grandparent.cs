using System;

// https://leetcode.com/problems/sum-of-nodes-with-even-valued-grandparent/
namespace _csharp
{
	public class _1315_sum_of_nodes_with_even_valued_grandparent
	{
		int sum;
		public int SumEvenGrandparent(TreeNode root) {
			sum = 0;
			preOrder(0,0,root);
			return sum;
		}

		private void preOrder(int parent, int grandParent, TreeNode root){
			if(root == null)
				return;

			if(grandParent>0 && grandParent%2==0){
				sum = sum + root.val;
			}

			preOrder(root.val, parent, root.left);
			preOrder(root.val, parent, root.right);
		}
	}
}

