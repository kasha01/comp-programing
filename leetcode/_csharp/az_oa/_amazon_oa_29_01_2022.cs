using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question/1728763/AMAZON-oror-NEW-GRAD-oror-2022
namespace _csharp
{
	// find how many retailers can reach the request query. each retailer covers a square area of (0,x) and (0,y)
	public class _amazon_oa_29_01_2022
	{
		class Node{
			public int point { get; set;}
			public int cnt { get; set;}

			public Node(int p, int c){
				this.point = p;
				this.cnt = c;
			}
		}

		public void solve(){
			int[][] retailers = new int[3][];
			retailers [0] = new int[]{ 1, 2 };
			retailers [1] = new int[]{ 2, 3 };
			retailers [2] = new int[]{ 1, 5 };

			int[][] queries = new int[2][];
			queries [0] = new int[]{ 1, 1 };
			queries [1] = new int[]{ 1, 4 };

			// key: coordinate | value: count
			var map_x = new Dictionary<int,int> ();
			var map_y = new Dictionary<int,int> ();

			int n = retailers.Length;
			for (int i = 0; i < n; ++i) {
				int x = retailers [i] [0];
				int y = retailers [i] [1];

				if (!map_x.ContainsKey (x))
					map_x.Add (x, 0);

				if (!map_x.ContainsKey (y))
					map_y.Add (y, 0);

				map_x [x]++;
				map_y [y]++;
			}

			// convert map to list
			var list_x = new List<Node> ();
			var list_y = new List<Node> ();
			foreach (var kvp in map_x) {
				list_x.Add (new Node (kvp.Key, kvp.Value));
			}

			foreach (var kvp in map_y) {
				list_y.Add (new Node (kvp.Key, kvp.Value));
			}

			// sort lists by coordinates
			list_x.Sort((a,b) => SortAsc(a,b));
			list_y.Sort((a,b) => SortAsc(a,b));

			int sum_retailers_x = 0;
			for (int i = list_x.Count-1; i >= 0; --i) {
				sum_retailers_x = sum_retailers_x + list_x [i].cnt;
				list_x [i].cnt = sum_retailers_x;
			}

			int sum_retailers_y = 0;
			for (int i = list_y.Count-1; i >= 0; --i) {
				sum_retailers_y = sum_retailers_y + list_y [i].cnt;
				list_y [i].cnt = sum_retailers_y;
			}

			for (int i = 0; i < queries.Length; ++i) {
				int query_x = queries [i] [0];
				int query_y = queries [i] [1];

				int x_retailer = getLowerBound (0, n - 1, list_x, query_x);
				int y_retailer = getLowerBound (0, n - 1, list_y, query_y);

				if (x_retailer == -1 || y_retailer == -1) {
					Console.WriteLine ($"Count of retailers for query {i} is: 0");
				} else {
					int retailers_x_cnt = list_x [x_retailer].cnt; 		
					int retailers_y_cnt = list_y [y_retailer].cnt;
					int c = Math.Min (retailers_x_cnt, retailers_y_cnt);
					Console.WriteLine ($"Count of retailers for query {i} is: {c}");
				}			
			}

			Console.WriteLine ("end");
		}

		private int getLowerBound(int lo, int hi, List<Node> list, int target){
			int ans = -1;
			while (lo <= hi) {
				int mid = lo + ((hi - lo) / 2);

				if (list [mid].point > target) {
					ans = mid;
					hi = mid - 1;
				} else if (list [mid].point < target) {
					lo = mid + 1;
				} else {
					return mid;
				}
			}

			return ans;
		}

		private static int SortAsc(Node a, Node b){
			int ka = a.point;
			int kb = b.point;

			if (ka < kb)
				return -1;

			if (ka > kb)
				return 1;

			return 0;
		}
	}
}