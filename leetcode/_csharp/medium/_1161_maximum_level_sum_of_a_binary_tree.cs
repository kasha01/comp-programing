using System;
using System.Collections.Generic;

// https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree/
namespace _csharp
{
	public class _1161_maximum_level_sum_of_a_binary_tree
	{
		public int MaxLevelSum(TreeNode root) {
			int level = 0; int maxSum = int.MinValue; int maxSumLevel=0;

			Queue<TreeNode> qu = new Queue<TreeNode>();
			qu.Enqueue(root);

			while(qu.Count > 0){
				int n = qu.Count;
				++level;
				int sum = 0;

				for(int i=0;i<n;++i){
					var node = qu.Dequeue();
					sum = sum + node.val;

					if(node.left != null) qu.Enqueue(node.left);
					if(node.right != null) qu.Enqueue(node.right);
				}

				if(sum > maxSum){
					maxSum = sum;
					maxSumLevel = level;
				}
			}

			return maxSumLevel;
		}
	}
}

