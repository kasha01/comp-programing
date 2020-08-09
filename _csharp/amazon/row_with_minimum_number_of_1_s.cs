using System;

// https://practice.geeksforgeeks.org/problems/row-with-minimum-number-of-1s/0
namespace GeeksForGeeks_csharp
{
	public class row_with_minimum_number_of_1_s
	{

		static void test()
		{
			int n = 4; int m = 4;
			int[,] arr = { { 0, 0, 0, 1 }, { 0, 1, 1, 1 }, { 0, 0, 1, 1 }, { 0, 0, 1, 1 } };

			int result =  solve (arr, n, m);

			Console.WriteLine (result);
		}

		static int solve(int[,] arr, int n, int m){
			int minx_row = -1;
			int minx = int.MaxValue;
			int s = 0;
			for (int i = 0; i < n; ++i) {
				s = 0;
				for (int j = 0; j < m; ++j) {
					s = s + arr [i, j];
					if (s > minx) {
						break;
					}
				}
				if (s < minx && s>0) {
					minx_row = i;
					minx = s;
				}
			}

			return minx_row;
		}
	}
}