using System;

// https://practice.geeksforgeeks.org/problems/transform-the-array/0
namespace GeeksForGeeks_csharp
{
	public class transform_the_array
	{
		public static void test ()
		{
			int[] arr = { 2, 4, 5, 0, 0, 5, 4, 8, 6, 0, 6, 8 };
			solve (arr, 12);
		}

		static void solve(int[] arr, int n){
			int prev = 0;
			int i = 0;
			int c = 0;

			while (i < n) {
				if (arr [i] != 0) {
					prev = arr [i];
					i++;
					break;
				}
				i++;
			}

			while (i < n) {
				int x = arr [i];

				if (x == 0) {
					i++;
				} else if (x == prev) {
					prev = prev * 2;
					//Console.Write (prev * 2 + " ");
					i++;
				} else {
					Console.Write (prev + " ");
					prev = arr[i]; i++; c++;
				}
			}

			if (prev > 0) {
				Console.Write (prev + " ");
				c++;
			}

			while (c < n) {
				c++;
				Console.Write (0 + " ");
			}
		}
	}
}

