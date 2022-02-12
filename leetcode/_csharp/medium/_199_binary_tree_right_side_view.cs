using System;
using System.Collections.Generic;

// https://leetcode.com/problems/binary-tree-right-side-view/
namespace _csharp
{
	public class _199_binary_tree_right_side_view
	{
		public IList<int> RightSideView(TreeNode root) {
			if(root == null)
				return new List<int>(0);

			Queue<TreeNode> qu = new Queue<TreeNode>();
			qu.Enqueue(root);
			List<int> ans = new List<int>();

			while(qu.Count>0){
				int m = qu.Count;
				bool rightNodeFound = false;
				for(int i=0;i<m;++i){
					var node = qu.Dequeue();
					if(!rightNodeFound){
						rightNodeFound = true;
						ans.Add(node.val);
					}

					if(node.right != null) qu.Enqueue(node.right);
					if(node.left != null) qu.Enqueue(node.left);
				}
			}

			return ans.ToArray();
		}
	}
}