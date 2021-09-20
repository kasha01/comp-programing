using System;

// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
namespace _csharp
{
	public class _236_lowest_common_ancestor_of_a_binary_tree
	{
		TreeNode lca=null; int pNode; int qNode;

		public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
			pNode = p.val; qNode=q.val;
			dfs(root); 
			return lca;
		}

		private bool dfs(TreeNode node){
			if(node == null) return false;

			bool l = dfs(node.left);
			bool r = dfs(node.right);

			if(l && r && lca==null){
				// found in left and right subtree --> set lca
				lca = node;
			}

			if((node.val==pNode || node.val==qNode) && (l || r) && lca==null){
				// edge case if target node is a parent of itself.
				// if one of the nodes is target
				// AND one of the subtrees (left or right) has target 
				// AND lca is not set --> set lca
				lca=node;
			}

			// node is target or one of the subtrees has target --> return true. 
			return node.val==pNode || node.val==qNode || l || r;
		}
	}
}