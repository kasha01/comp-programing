using System;

// https://practice.geeksforgeeks.org/problems/two-numbers-with-sum-closest-to-zero/0
namespace GeeksForGeeks_csharp
{
	public class two_numbers_with_sum_closest_to_zero
	{

		public static void test ()
		{
			int[] arr = { -8 ,-66 ,-60  };
			solve (arr, 3);
		}

		static void solve(int[] arr, int n){
			if (n == 2) {
				Console.WriteLine (arr [0] + arr [1]);
				return;
			}				

			Array.Sort (arr);

			int sum = int.MaxValue;
			int i = 0; int j = n - 1;

			while (j-i > 1) {
				if (arr[i] + arr[j] == 0){
					Console.WriteLine (0);
					return;
				}

				int s1 = arr[i] + arr [j - 1];
				int s2 = arr[j] + arr [i + 1];

				if (Math.Abs (s1) < Math.Abs (s2)) {
					if (Math.Abs (s1) < Math.Abs(sum)) {
						sum = s1;
					}
					j--;
				} else if (Math.Abs (s1) > Math.Abs (s2)) {
					if (Math.Abs (s2) < Math.Abs(sum)) {
						sum = s2;
					}
					i++;
				} else {
					// s1 == s2
					if (Math.Abs (s2) < Math.Abs(sum)) {
						sum = s2;
					}
					i++;
					j--;
				}
			}

			Console.WriteLine(sum);
		}
	}
}

