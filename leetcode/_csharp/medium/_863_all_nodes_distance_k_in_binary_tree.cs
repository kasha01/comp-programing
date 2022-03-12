using System;
using System.Collections.Generic;

// https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree/
namespace _csharp
{
	public class _863_all_nodes_distance_k_in_binary_tree
	{
		List<int> list;
		TreeNode target;
		int k;
		public IList<int> DistanceK(TreeNode root, TreeNode Target, int K) {
			list = new List<int>();
			k = K;
			target=Target;

			dfs(root);
			return list.ToArray();
		}

		private int dfs(TreeNode root){
			if(root == null)
				return -1;

			if(root.val == target.val){
				dfs_subtree(root,0);
				return 1;
			}

			int left = dfs(root.left);
			int right = dfs(root.right);

			if(left!=-1){
				if(left == k){
					// root node is at distance k. there is no need to dig deeper.
					list.Add(root.val);
					return -1;
				}

				// target was found on left branch - re-dfs right branch
				dfs_subtree(root.right,left+1);
				return left+1;
			}
			else if(right!=-1){
				if(right == k) {
					// root node is at distance k. there is no need to dig deeper.
					list.Add(root.val);
					return -1;
				}

				// target was found on right branch - re-dfs left branch
				dfs_subtree(root.left,right+1);
				return right+1;
			}

			return -1;
		}

		private void dfs_subtree(TreeNode root, int dist){
			if(root==null)
				return;

			if(dist == k){
				list.Add(root.val);
				return;
			}

			dfs_subtree(root.left,dist+1);
			dfs_subtree(root.right,dist+1);
		}
	}
}