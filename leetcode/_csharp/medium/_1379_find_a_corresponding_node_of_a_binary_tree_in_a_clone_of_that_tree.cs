using System;
using System.Collections.Generic;

// https://leetcode.com/problems/find-a-corresponding-node-of-a-binary-tree-in-a-clone-of-that-tree/
namespace _csharp
{
	public class _1379_find_a_corresponding_node_of_a_binary_tree_in_a_clone_of_that_tree
	{
		public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) {
			Queue<TreeNode> qu_orig = new Queue<TreeNode>();
			Queue<TreeNode> qu_clone = new Queue<TreeNode>();

			qu_orig.Enqueue(original);
			qu_clone.Enqueue(cloned);

			while(qu_orig.Count != null){
				TreeNode origNode = qu_orig.Dequeue();
				TreeNode cloneNode = qu_clone.Dequeue();

				if(cloneNode.val == target.val){
					return cloneNode;
				}

				if(origNode.left != null){
					qu_orig.Enqueue(origNode.left);
					qu_clone.Enqueue(cloneNode.left);    
				}

				if(origNode.right != null){
					qu_orig.Enqueue(origNode.right);
					qu_clone.Enqueue(cloneNode.right);    
				}
			}

			return null;
		}    
	}
}