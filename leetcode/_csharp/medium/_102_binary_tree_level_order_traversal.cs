using System;
using System.Collections.Generic;

namespace _csharp
{
	public class _102_binary_tree_level_order_traversal
	{
		public IList<IList<int>> LevelOrder(TreeNode root) {
			var ans = new List<List<int>>();
			if(root == null)
				return ans.ToArray();

			Queue<TreeNode> qu = new Queue<TreeNode>(); 
			qu.Enqueue(root);

			while(qu.Count > 0){
				int n = qu.Count;
				var temp = new List<int>();
				for(int i=0;i<n;++i){
					var node = qu.Dequeue();

					temp.Add(node.val);

					if(node.left != null) qu.Enqueue(node.left);
					if(node.right != null) qu.Enqueue(node.right);
				}
				ans.Add(temp);
			}

			return ans.ToArray();
		}
	}
}