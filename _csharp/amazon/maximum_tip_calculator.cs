using System;

// https://practice.geeksforgeeks.org/problems/maximum-tip-calculator/0
namespace GeeksForGeeks_csharp
{
	public class maximum_tip_calculator
	{	
		static int[] arr_r = {1,4,3,2,7,5,9,6};
		static int[] arr_a = {1,2,3,6,5,4,9,8};
		static int N = 8;
		static int X = 4;
		static int Y = 4;
		static int[,,] memo = new int[N, X+1, Y+1];

		static int solve(int n, int x, int y){
			if (n == 0)
				return 0;

			if (memo [N - n, X - x, Y - y] != 0) {
				return memo [N - n, X - x, Y - y];
			}

			int r = 0;
			int a = 0;

			if (x > 0) {
				r = solve (n - 1, x - 1, y) + arr_r [N - n];
			}

			if (y > 0) {
				a = solve (n - 1, x, y-1) + arr_a [N - n];
			}

			memo [N - n, X - x, Y - y] = Math.Max (a, r);
			return memo [N - n, X - x, Y - y];
		}

		public static void test(){
			int res = solve (N, X, Y);
			Console.WriteLine (res);
		}
	}
}

