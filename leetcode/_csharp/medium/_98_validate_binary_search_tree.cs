using System;
using System.Collections.Generic;

// https://leetcode.com/problems/validate-binary-search-tree/
namespace _csharp
{
	public class _98_validate_binary_search_tree
	{
		public bool IsValidBST(TreeNode root) {

			int? prev=null; int cur=0;
			Stack<TreeNode> st = new Stack<TreeNode>(); 

			while(root != null || st.Count!=0){
				while(root!=null){
					st.Push(root);
					root = root.left;
				}

				root = st.Pop();
				cur = root.val;
				if(prev == null){
					prev = cur;
				}
				else{
					// compare
					if(prev >= cur) return false;
					prev = cur;
				}

				root = root.right;
			}

			return true;
		}
	}
}

