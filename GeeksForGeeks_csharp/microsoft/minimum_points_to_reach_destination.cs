using System;

// https://practice.geeksforgeeks.org/problems/minimum-points-to-reach-destination/0
namespace GeeksForGeeks_csharp
{
	public class minimum_points_to_reach_destination
	{
		public static void test ()
		{
			int[,] arr = { { -2, -3, 3, }, { -5, -10, 1 }, { 10, 30, -5 } };
			solve (arr, 3, 3);
		}

		static void solve(int[,] arr, int n, int m){
			int[,] memo = new int[n, m];	// minimum input to each cell
			for (int i = n - 1; i >= 0; --i) {
				for (int j = m - 1; j >= 0; --j) {
					if (i == n - 1 && j == m - 1) {
						// destination cell
						memo[i,j] = arr[n-1,m-1] > 0 ? 1 : 1 - arr[n-1,m-1];
						continue;
					}

					// minimum input for current cell, if next cell is on right of current cell.
					int in_c_right = int.MaxValue;
					if(j+1 < m){
						in_c_right = memo [i, j + 1] - arr [i, j];
						in_c_right = in_c_right <= 0 ? 1 : in_c_right;
					}

					// minimum input for current cell, if next cell is below current cell.
					int in_c_below = int.MaxValue;
					if(i+1<n){
						in_c_below = memo [i + 1, j] - arr [i, j];
						in_c_below = in_c_below <= 0 ? 1 : in_c_below;
					}

					memo [i, j] = Math.Min (in_c_right, in_c_below);
				}
			}

			Console.WriteLine (memo [0, 0]);
		}
	}
}

