using System;
using System.Collections.Generic;

// https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
namespace _csharp
{
	public class _103_binary_tree_zigzag_level_order_traversal
	{
		public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
			if(root == null) return new List<int>[0];

			bool isEvenLevel = true;
			List<int[]> list = new List<int[]>();
			Queue<TreeNode> qu = new Queue<TreeNode>();
			qu.Enqueue(root);

			while(qu.Count > 0){
				int n = qu.Count;
				var arr = new int[n];
				for(int i=0;i<n;++i){
					var node = qu.Dequeue();

					if(isEvenLevel){
						arr[i] = node.val;
					}
					else{
						arr[n-1-i] = node.val;
					}

					if(node.left != null) qu.Enqueue(node.left);
					if(node.right != null) qu.Enqueue(node.right);
				}

				isEvenLevel = !isEvenLevel;
				list.Add(arr);
			}

			return list.ToArray();
		}
	}
}