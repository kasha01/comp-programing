using System;

// https://practice.geeksforgeeks.org/problems/subset-sum-problem/0
namespace GeeksForGeeks_csharp
{
	public class subset_sum_problem
	{
		public static void test ()
		{
			int[] arr = { 2, 2, 3, 5 };
			bool result =  solve (arr, 4);
			Console.WriteLine (result ? "YES" : "NO");
		}

		static bool solve(int[] arr, int n){
			int sum = 0;
			for (int i = 0; i < n; ++i) {
				sum = sum + arr [i];
			}

			if (sum % 2 != 0) {
				// odd sum of array elements.
				return false;
			} else {
				return dp (arr, n, sum / 2);
			}
		}

		// this solves coin change with finite coins problem.
		static bool dp(int[] arr, int n, int m){
			bool[,] memo = new bool[n+1, m+1];

			memo [0, 0] = true; // empty set can get 0 sum
			for (int i = 1; i <= m; ++i) {
				memo [0, i] = false; // empty set
			}

			for (int i = 1; i <= n; i++) {
				for (int j = 0; j <= m; j++) {
					if (memo [i - 1, j] == true) {
						memo [i, j] = true;
					} else if (arr [i - 1] == j) {
						memo [i, j] = true;
					} else if (arr [i - 1] > j) {
						memo [i, j] = false;
					}
					else if (arr[i-1] < j) {
						memo [i, j] = memo [i-1, j - arr [i - 1]];
					}
				}
			}

			return memo[n,m];
		}
	}
}