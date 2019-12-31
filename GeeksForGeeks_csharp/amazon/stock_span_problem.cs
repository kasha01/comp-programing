using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/stock-span-problem/0
namespace GeeksForGeeks_csharp
{
	public class stock_span_problem
	{
		public static void test ()
		{
			int[] arr = { 10, 4, 5, 90, 120, 80 };
			solve (arr, 6);
		}

		static void solve(int[] arr, int n){
			Stack<int> stack = new Stack<int> ();
			int[] result = new int[n];

			for (int i = 0; i < n; ++i) {
				if (stack.Count == 0) {
					stack.Push (i);
					result [i] = 1;
				} else {
					int s = 1;
					while (stack.Count > 0 && arr [i] >= arr [stack.Peek ()]) {
						s = s + result [stack.Peek ()];
						stack.Pop ();
					}
					result [i] = s;
					stack.Push (i);
				}
			}

			for (int i = 0; i < n; ++i) {
				Console.Write (result [i] + " ");
			}
		}
	}
}

