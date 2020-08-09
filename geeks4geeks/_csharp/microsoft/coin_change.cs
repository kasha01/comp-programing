using System;

// https://practice.geeksforgeeks.org/problems/coin-change/0
namespace GeeksForGeeks_csharp
{
	public class coin_change
	{
		public static void test ()
		{
			int[] arr = { 2,5,3,6 };
			Console.WriteLine(solve(arr, 4, 10));
		}

		static int solve(int[] arr, int n, int m){
			int[] memo = new int[m+1];
			memo [0] = 1;

			for (int i = 0; i < n; i++) {
				for (int j = 1; j <= m; ++j) {
					if (j - arr [i] >= 0) {
						memo [j] = memo [j] + memo [j - arr [i]];
					}
				}
			}
			return memo [m];
		}
	}
}

