using System;

// https://practice.geeksforgeeks.org/problems/minimum-energy/0
namespace GeeksForGeeks_csharp
{
	public class minimum_energy
	{
		public static void solve ()
		{
			int[] arr = { 0, 0, 0, 0, 0 };
			int n = 5;
			int res = solve (arr, n);
			Console.WriteLine (res);
		}

		static int solve(int[] arr, int n){
			int me = 0;
			int e = 0;
			for (int i = 0; i < n; ++i) {
				e = e + arr [i] + me;
				if (e <= 0) {
					me = me + Math.Abs (e) + 1;
				}
			}
			me = me == 0 ? 1 : me;

			return me;
		}
	}
}

