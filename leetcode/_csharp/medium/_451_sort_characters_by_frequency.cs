using System;
using System.Collections.Generic;
using System.Text;

// https://leetcode.com/problems/sort-characters-by-frequency/
namespace _csharp
{
	public class _451_sort_characters_by_frequency
	{
		class Node{
			public int cnt {get;set;}
			public char key {get;set;}

			public Node(char k, int c){
				this.key = k; this.cnt = c;
			}
		}

		public string FrequencySort(string s) {
			var map = new Dictionary<char,int>();
			foreach(var c in s){
				if(!map.ContainsKey(c))
					map.Add(c,0);

				map[c]++;
			}

			List<Node> list = new List<Node>();
			foreach(var kvp in map){
				list.Add(new Node(kvp.Key, kvp.Value));
			}

			list.Sort((a,b) => SortDesc(a,b));

			StringBuilder sb = new StringBuilder();
			foreach(var node in list){
				string ss = new String(node.key, node.cnt);
				sb.Append(ss);
			}

			return sb.ToString();        
		}

		private int SortDesc(Node a, Node b){
			if(a.cnt > b.cnt) return -1;
			if(a.cnt < b.cnt) return 1;
			return 0;
		}
	}
}

