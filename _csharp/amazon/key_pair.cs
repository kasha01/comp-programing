using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/key-pair/0
namespace GeeksForGeeks_csharp
{
	public class key_pair
	{
		static Dictionary<int,int> map = new Dictionary<int,int> ();

		public static void test ()
		{
			int[] arr = { 1 ,5 ,45 ,6 ,11 ,8};
			map.Clear ();
			bool result = solve(arr,6,16);
			Console.WriteLine(result == true ? "Yes" : "No");
		} 

		static bool solve(int[] arr, int n, int k){
			for (int i = 0; i < n; ++i) {
				int x = arr [i];
				if (map.ContainsKey (x)) {
					map [x]++;
				} else {
					map.Add (x, 1);
				}
			}

			for (int i = 0; i < n; ++i) {
				int x = k - arr [i];
				if (x > 0) {
					if (x == arr [i] && map [x] > 1) {
						return true;		
					}

					if (x != arr [i] && map.ContainsKey (x)) {
						return true;
					}
				}
			}

			return false;
		}
	}
}

