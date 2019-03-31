using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/kth-smallest-element/0
namespace GeeksForGeeks_csharp
{
	public class kth_smallest_element
	{
		public static void solve ()
		{
			int x = 100000;
			bool[] list = new bool[x];
			int[] arr = { 7 ,10 ,4 ,3 ,20 ,15 };
			int n = 6;
			int k = 3;

			for (int i = 0; i < n; ++i) {
				int num = arr [i];
				list [num] = true;
			}

			int ans = -1;
			int kk = 1;
			for (int i = 0; i < x; ++i) {
				if (list[i]) {
					if (k == kk) {
						ans = i; 
						break;
					}
					else{
						kk++;
					}
				}
			}
			Console.WriteLine (ans);
		}
	}
}

