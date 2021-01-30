using System;
using System.Collections.Generic;

// https://leetcode.com/problems/recover-a-tree-from-preorder-traversal/
namespace _csharp
{
	public class _1028_recover_a_tree_from_preorder_traversal
	{
		public TreeNode RecoverFromPreorder(string S) {
			TreeNode newNode = null;
			TreeNode root = null;

			Stack<TreeNode> stack = new Stack<TreeNode>();
			int depth = 0;
			int n = S.Length;
			int i = 0;
			while(i<n){
				int newDepth = 0;

				// read dashes
				while(S[i]=='-'){
					char c = S[i];
					++newDepth;
					++i;
				}

				// read number
				int num = 0;
				while(i<n&& S[i]!='-'){
					int c = S[i] - '0';
					num = (num*10) + c;
					++i;
				}

				if(newDepth > depth){
					depth = newDepth;
					stack.Push(newNode);
				}
				else if(newDepth < depth){
					while(newDepth < depth){
						stack.Pop();
						--depth;
					}
				}

				newNode = new TreeNode(num);

				if(stack.Count != 0){
					TreeNode parent = stack.Peek();
					if(parent.left == null){
						parent.left = newNode;
					}
					else{
						parent.right = newNode;
					}
				}
				else{
					// stack is only empty when i am reading the root node.
					root = newNode;
				}
			}

			return root;
		}
	}
}