using System;
using System.Text;

// https://leetcode.com/problems/custom-sort-string/
namespace _csharp
{
	public class _791_custom_sort_string
	{
		public string CustomSortString(string S, string T) {
			var order = new int[26];

			int ord=1;
			foreach(char c in S){
				order[c-'a'] = ord;
				++ord;
			}

			StringBuilder sb_with_order = new StringBuilder();
			StringBuilder sb_with_no_order = new StringBuilder();

			foreach(char c in T){
				if(order[c-'a'] > 0){
					// it is ordered char
					sb_with_order.Append(c);
				}
				else{
					sb_with_no_order.Append(c);
				}
			}

			var with_order_arr = sb_with_order.ToString().ToCharArray();
			var with_no_order_string = sb_with_no_order.ToString();

			Array.Sort(with_order_arr, (a,b) => sortByOrder(a,b,order));

			return new string(with_order_arr) + with_no_order_string;
		}

		private static int sortByOrder(char a, char b, int[] order){
			int order_a = order[a-'a'];
			int order_b = order[b-'a'];

			if(order_a < order_b)
				return -1;

			if(order_a > order_b)
				return 1;

			return 0;            
		}
	}
}

