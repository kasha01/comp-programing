using System;
using System.Collections.Generic;

// https://leetcode.com/problems/binary-search-tree-iterator/
namespace _csharp
{
	public class _173_binary_search_tree_iterator
	{
		public class BSTIterator {
			bool hasNext;
			Stack<TreeNode> st;

			public BSTIterator(TreeNode root) {
				st = new Stack<TreeNode>();
				hasNext = root != null;

				TreeNode current = root;
				while(current != null){
					st.Push(current);
					current = current.left;
				}
			}

			public int Next() {
				int nxt = st.Peek().val;

				var current = st.Pop();
				hasNext = current.right != null || st.Count > 0;

				current = current.right;
				while(current != null){
					st.Push(current);
					current = current.left;
				}

				return nxt;
			}

			public bool HasNext() {
				return hasNext;
			}
		}
	}
}

