using System;

// https://practice.geeksforgeeks.org/problems/floor-in-a-sorted-array/0
namespace GeeksForGeeks_csharp
{
	public class floor_in_sorted_array
	{
		static void test ()
		{
			long[] arr = { 1 ,8 ,10 ,11,2 ,3 ,19};
			long res = solve (arr, 7, 5);
			Console.WriteLine (res);
		}

		static long solve(long[] arr, long n, long x){
			long k = -1;
			long d = -1;
			for (long i = 0; i < n; ++i) {
				long a = arr [i];
				if (a <= x) {
					k = Math.Max (k, a);
					d = i;
				}
			}

			return d;
		}
	}
}

