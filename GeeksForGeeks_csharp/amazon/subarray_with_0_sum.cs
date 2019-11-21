using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/subarray-with-0-sum/0
namespace GeeksForGeeks_csharp
{
	public class subarray_with_0_sum
	{
		public static void test ()
		{
			int[] arr = { -1, 1 };
			bool res =  solve (arr, 2);
			Console.WriteLine (res == true ? "Yes" : "No");
		}

		static bool solve(int[] arr, int n){
			HashSet<int> set = new HashSet<int> ();

			int s = 0;
			for (int i = 0; i < n; ++i) {
				s = s + arr [i];
				if (set.Contains (s) || s == 0) {
					return true;
				} else {
					set.Add (s);
				}
			}
			return false;
		}
	}
}

