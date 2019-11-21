using System;

// https://practice.geeksforgeeks.org/problems/max-sum-without-adjacents/0
namespace GeeksForGeeks_csharp
{
	public class max_sum_without_adjacents
	{
		public static void solve ()
		{
			int n = 4;
			int[] arr = { 0,0,3,1 };
			int res = solve (arr, n);
			Console.WriteLine (res);
		}

		static int solve (int[] arr, int n)
		{
			if (n == 1)
				return arr [0];

			int mx = 0;
			int[] vec = new int[n];

			vec [n - 1] = arr [n - 1];
			vec [n - 2] = arr [n - 2];

			mx = Math.Max (mx, vec [n - 2]);
			mx = Math.Max (mx, vec [n - 1]);

			for (int i = n-3; i >=0; --i) {
				int x = 0;
				int y = 0;

				x = arr [i] + vec [i + 2];
				if(i+3<n)
					y = arr [i] + vec [i + 3];

				vec [i] = Math.Max (x, y);

				mx = Math.Max (mx, vec [i]);
			}

			return mx;
		}
	}
}

