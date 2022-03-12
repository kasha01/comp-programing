using System;
using System.Collections.Generic;

// https://leetcode.com/problems/populating-next-right-pointers-in-each-node/
namespace _csharp
{
	public class _116_populating_next_right_pointers_in_each_node
	{
		public TreeNode Connect(TreeNode root) {
			if(root == null)
				return root;

			Queue<TreeNode> qu = new Queue<TreeNode>();
			qu.Enqueue(root);

			while(qu.Count > 0){
				int n = qu.Count;
				TreeNode prev = null;
				for(int i=0;i<n;++i){
					var node = qu.Dequeue();
					if(prev != null)
						prev.next = node;

					prev = node;

					if(node.left != null) qu.Enqueue(node.left);
					if(node.right != null) qu.Enqueue(node.right);
				}
			}

			return root;
		}
	}
}