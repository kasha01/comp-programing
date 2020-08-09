using System;

// https://practice.geeksforgeeks.org/problems/unsorted-array/0
namespace GeeksForGeeks_csharp
{
	public class element_with_left_side_smaller_and_right_side_greater
	{
		public static void test ()
		{
			int[] arr = { 4 ,3 ,2 ,7 ,8 ,9,1,5,20,100,20 };
			Console.WriteLine (solve (arr, 11));
		}

		static int solve(int[] arr, int n){
			int max_so_far = arr [0];
			int k = -1; int ki = -1;
			for (int i = 1; i < n; ++i) {
				int x = arr [i];

				max_so_far = Math.Max (max_so_far, x);

				if (k == -1) {
					// k not set
					if (x >= max_so_far) {
						k = x;
						ki = i;
					}
				} else {
					// k is set, we need to check there is number following k, that is less than k, otherwise, reset k
					if (k > x) {
						k = -1;ki = -1;
					}
				}
			}

			if (ki == n - 1)
				k = -1;

			return k;
		}
	}
}

