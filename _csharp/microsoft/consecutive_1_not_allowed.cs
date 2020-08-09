using System;

// https://practice.geeksforgeeks.org/problems/consecutive-1s-not-allowed/0
namespace GeeksForGeeks_csharp
{
	public class consecutive_1_not_allowed
	{

		static int[,] memo;

		private static int solve(int n, int d){
			int res = 0;

			if (n == 0) {
				memo [d,n] = 1;
				return 1;
			}

			if (memo [d, n] != 0)
				return memo [d, n];

			if (d == 1) {
				res = solve (n - 1, 0);
			} else {
				res = solve (n - 1, 0);
				res = res + solve (n - 1, 1);
			}
			memo [d,n] = res;
			return res % (1000000007);
		}

		public static void solve()
		{
			int n = 43;
			memo = new int[2, n];
			int ans = solve (n-1,0) + solve (n-1,1);
			Console.WriteLine (ans% (1000000007));
		}
	}
}

