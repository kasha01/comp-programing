using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/sort-an-array-of-0s-1s-and-2s/0
namespace GeeksForGeeks_csharp
{
	public class sort_an_array_of_0s_1s_2s
	{
		static Dictionary<int,int> map = new Dictionary<int,int> ();
		public static void test ()
		{
			map.Clear ();
			map.Add (0, 0);
			map.Add (1, 0);
			map.Add (2, 0);

			int[] arr = { 0, 2, 1, 2, 0 };
			int n = 5;
			solve (arr, n);
		}

		static void solve(int[] arr, int n){
			for (int i = 0; i < n; ++i) {
				int x = arr [i];
				map [x]++;
			}

			int a = map [0];
			int b = map [1];
			int c = map [2];
			for (int i = 0; i < a; ++i) {
				Console.Write (0 + " ");
			}
			for (int i = 0; i < b; ++i) {
				Console.Write (1 + " ");
			}
			for (int i = 0; i < c; ++i) {
				Console.Write (2 + " ");
			}
		}
	}
}