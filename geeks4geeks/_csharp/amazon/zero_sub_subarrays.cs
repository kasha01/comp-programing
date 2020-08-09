using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/zero-sum-subarrays/0
namespace GeeksForGeeks_csharp
{
	public class zero_sub_subarrays
	{
		static void test(){
			int n = 10;
			int[] arr = { 6  ,-1 ,-3 ,4 ,-2, 2 ,4 ,6 ,-12, -7 };
			int c = solve (arr, n);
			Console.WriteLine(c);
		}

		static int solve (int[] arr, int n)
		{
			Dictionary<int,int> map = new Dictionary<int,int> ();
			int c = 0;
			int s = 0;

			for (int i = 0; i < n; ++i) {
				s = s + arr [i];
				if(s==0)
					c++;

				if (map.ContainsKey (s)) {
					c = c + map [s];
					map [s]++;
				} else {
					map.Add (s, 1);
				}
			}
			return c;
		}
	}
}

