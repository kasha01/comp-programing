using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/surpasser-count/0
namespace GeeksForGeeks_csharp
{
	public class Surpasser_Count
	{
		public static int sort_me(KeyValuePair<int,int> a, KeyValuePair<int,int> b){
			if (a.Key < b.Key)
				return -1;
			else
				return 1;
		}

		// this is O(n). GeeksForGeeks question states all numbers are UNIQUE, but the failing test case has duplicate values, when i remove the duplicate
		// value and run test via (Expected Outcome) I get same result as the GeeksforGeeks Judge.
		public static void solve()
		{
			List<int> list = new List<int> (){468,335,501,170,725,479,359,963,465,706,146,282,962,492,996,943,828,437,392,605,903,154,293,383,422,717,719,896,448,727,772,539,870,913,668,300,36,895,704,812,323};
			int n = list.Count;

			int[] result = new int[n];

			// number | index
			List<KeyValuePair<int,int>> map = new List<KeyValuePair<int,int>> ();
			for(int i=0;i<n;++i) {
				map.Add (new KeyValuePair<int, int>(list [i], i));
			}

			// sort by key (number)
			map.Sort (sort_me);

			int x = map[n - 1].Value;
			result[x] = 0;
			for(int i=n-2;i>=0;--i) {
				if(map[i].Value < map[i+1].Value){
					result[map[i].Value] = result[map[i+1].Value] + 1;
				}
			}

			for (int i = 0; i < n; ++i) {
				Console.Write (result [i] + " ");
			}
		}
	}
}

