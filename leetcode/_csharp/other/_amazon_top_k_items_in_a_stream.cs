using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question/1590162/Amazon-Final-Interview-Questions-or-All-Combined-2021-or-SDE-and-New-Grad
namespace _csharp
{
	public class _amazon_top_k_items_in_a_stream
	{
		static int find(int[] arr, int ele)
		{
			for (int i = 0; i < arr.Length; i++)
				if (arr[i] == ele)
					return i;
			return -1;
		}

		// Driver Code
		public static void Run()
		{
			int k = 4;
			int[] arr = { 5, 2, 1, 3, 2 };
			int n = arr.Length;
			kTop(arr, n, k);
		}

		// Function to print top k numbers
		static void kTop(int[] a, int n, int k)
		{
			int[] top = new int[k + 1];
			Dictionary<int,int> freq = new Dictionary<int,int> ();

			freq.Add (0, -1);

			foreach (int x in a) {
				if (!freq.ContainsKey (x))
					freq.Add (x, 0);

				freq [x]++;

				int i = find (top, x);
				if (i == -1) {
					top [k] = x;
					i = k;
				}

				while (i > 0) {
					if (freq [top [i]] > freq [top [i - 1]]) {
						int temp = top [i];
						top [i] = top [i - 1];
						top [i - 1] = temp;
					} else if (freq [top [i]] == freq [top [i - 1]] && top [i] > top [i - 1]) {
						int temp = top [i];
						top [i] = top [i - 1];
						top [i - 1] = temp;
					} else {
						break;
					}
					--i;
				}

				for (int j = 0; j < k && top [j] != 0; ++j) {
					Console.Write (top [j] + " "); 
				}
				Console.WriteLine ();
			}
		}
	}
}

