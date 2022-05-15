using System;
using System.Collections.Generic;

// https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree/
namespace _csharp
{
	public class _987_vertical_order_traversal_of_a_binary_tree
	{
		public IList<IList<int>> VerticalTraversal(TreeNode root) {
			var map = new SortedDictionary<int,List<int>>();
			var qu = new Queue<Tuple<TreeNode,int>>();
			qu.Enqueue(Tuple.Create(root, 0));

			while(qu.Count > 0){
				int n = qu.Count;
				var temp_map = new Dictionary<int,List<int>>();
				for(int i=0;i<n;++i){
					var tup = qu.Dequeue();
					var node = tup.Item1;
					var column = tup.Item2;

					if(!temp_map.ContainsKey(column)){
						temp_map.Add(column, new List<int>());
					}
					temp_map[column].Add(node.val);

					if(node.right != null) qu.Enqueue(Tuple.Create(node.right,column+1));
					if(node.left != null) qu.Enqueue(Tuple.Create(node.left,column-1));
				}

				// sort temp_map and add to map
				foreach(var kvp in temp_map){
					var key = kvp.Key;
					var list = kvp.Value;
					list.Sort();

					if(!map.ContainsKey(key))
						map.Add(key, list);
					else
						map[key].AddRange(list);
				}
			}

			var ans = new List<List<int>>();
			foreach(var kvp in map){
				ans.Add(kvp.Value);
			}

			return ans.ToArray();
		}
	}
}

