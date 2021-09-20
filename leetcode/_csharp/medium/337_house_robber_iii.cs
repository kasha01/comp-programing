using System;
using System.Collections.Generic;

// https://leetcode.com/problems/house-robber-iii/
namespace _csharp
{
	public class _37_house_robber_iii
	{
		Dictionary<TreeNode,int> rootWasRobbed;
		Dictionary<TreeNode,int> rootWasNotRobbed;
		public int Rob(TreeNode root) {
			rootWasRobbed = new Dictionary<TreeNode,int>();
			rootWasNotRobbed = new Dictionary<TreeNode,int>();

			int sum1 = root.val + bfs(root.left,true) + bfs(root.right,true);
			int sum2 = bfs(root.left,false) + bfs(root.right,false);
			return Math.Max(sum1,sum2);
		}

		private int bfs(TreeNode root, bool prevWasIncluded){
			if(root==null)
				return 0;

			if(prevWasIncluded && rootWasRobbed.ContainsKey(root)){
				return rootWasRobbed[root];
			}
			else if(!prevWasIncluded && rootWasNotRobbed.ContainsKey(root)){
				return rootWasNotRobbed[root];
			}

			int sum1=0; int sum2=0;
			if(!prevWasIncluded){
				// I can steal these houses.
				sum1 = root.val + bfs(root.left,true) + bfs(root.right,true);
			}

			sum2 = bfs(root.left,false) + bfs(root.right,false);

			int s = Math.Max(sum1,sum2);
			if(prevWasIncluded)
				rootWasRobbed.Add(root,s);
			else
				rootWasNotRobbed.Add(root,s);

			return s;
		}
	}
}