using System;

// https://practice.geeksforgeeks.org/problems/minimum-element-in-a-sorted-and-rotated-array/0
namespace GeeksForGeeks_csharp
{
	public class minimum_element_in_a_sorted_rotated_array
	{
		public static void test ()
		{
			int[] arr = { 10, 20, 30, 1,2 };
			int r = solve (arr, 5);
			Console.WriteLine (r);
		}

		static int solve(int[] arr, int n){
			return bs (arr, 0, n - 1);
		}

		static int bs(int[] arr, int i, int j){
			int m = ((j - i) / 2) + i;

			if (j-1 == i) {
				// 2 elements array
				return Math.Min(arr[i],arr[j]);
			}

			if (j == i) {
				// 1 element array
				return arr[i];
			}

			if (arr [i] < arr [j]) {
				// increasing array
				return arr [i];
			}

			if (arr [m] > arr [i]) {
				// flipped array, rotation point is between m+1 & j
				// because i->m is all trending up (increasing)
				return bs (arr, m + 1, j);
			}

			if (arr [m] < arr [i]) {
				// flipped array, rotation point is between i & m
				// because i->m is all trending down
				return bs (arr, i, m);
			}

			return -1;
		}

	}
}

