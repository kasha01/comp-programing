using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

// https://leetcode.com/discuss/interview-question/844979/Amazon-or-OA-2020-or-Largest-Item-Association
namespace _csharp
{
	public class _largest_item_association
	{
		// key: item | value: parent
		Dictionary<string, string> map = new Dictionary<string, string> ();
		public void solve(){
			string[][] items = new string[4][];
			items [0] = new string[]{ "Item9", "Item2" };
			items [1] = new string[] { "Item1", "Item4" };
			items [2] = new string[] { "Item4", "Item5" };
			items [3] = new string[] { "Item6", "Item2" };

			int n = items.Length;

			// set each item to be its own parent.
			for(int i=0;i<n;++i){
				for (int j = 0; j < items[i].Length; ++j) {
					if (!map.ContainsKey (items [i] [j]))
						map.Add (items [i] [j], items [i] [j]);
				}
			}

			// link related items in map.
			for(int i=0;i<n;++i){
				var key = items [i] [0];
				var parent_key = findParent (key);
				for (int j = 1; j < items[i].Length; ++j) {
					var parent_B = findParent(items[i][j]);
					if (parent_key != parent_B)
						map [parent_B] = parent_key;
				}
			}

			// calculate largest union set. key: common parent item | value: list of others items connected to parent item. 
			Dictionary<string,List<string>> unions = new Dictionary<string, List<string>>();
			var ll = map.ToList ();
			foreach (var kvp in ll) {
				var key = kvp.Key;		// item
				var val = kvp.Value;	// item's parent
				var parent = findParent (val);

				if (!unions.ContainsKey (parent))
					unions.Add (parent, new List<string> ());

				unions[parent].Add (key);
			}

			var result = new List<string> ();
			foreach (var kvp in unions) {
				if (kvp.Value.Count > result.Count) {
					kvp.Value.Sort ();
					result = kvp.Value;	// pick largest linked items list.
				}
				else if (kvp.Value.Count == result.Count) {
					kvp.Value.Sort ();
					var list2 = kvp.Value;
					var item_a = result [0];
					var item_b = list2[0];

					// if two groups have same length, select the group which contains the item that appears first in lexicographic order.
					if (item_b.CompareTo(item_a) < 0) {
						result = list2;		// item_b appears first/before item_a when sorted in lexicographic order.
					}
				}
			}

			// print result
			foreach (string s in result) {
				Console.Write (s + " ");
			}
		}

		private string findParent(string node){
			if (map [node] == node)
				return node;

			return map [node] = findParent (map [node]);
		}

	}
}