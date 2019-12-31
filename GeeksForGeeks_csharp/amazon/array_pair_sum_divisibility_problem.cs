using System;

// https://practice.geeksforgeeks.org/problems/array-pair-sum-divisibility-problem/0
namespace GeeksForGeeks_csharp
{
	public class array_pair_sum_divisibility_problem
	{
		static void test ()
		{
			int[] arr = { 91, 74, 66, 48 };
			int n = 4;
			int k = 10;
			Console.WriteLine (solve (arr, n, k));
		}

		static bool solve(int[] arr, int n, int k){
			if (n % 2 != 0) {
				// if count is odd - we can never form pairs
				return false;
			}

			int[] memo = new int[k];
			for (int i = 0; i < n; ++i) {
				// get the count of the remainders for each number
				int x = arr [i] % k;
				memo [x] = memo [x] + 1;
			}

			if (memo [0] > 0 && memo [0] % 2 != 0) {
				// must have even number of integers with remainder 0, so they can pair with each other
				return false;
			}

			int a=1; int b = k - 1;
			while(a<=b) {
				if (a == b) {
					// if k is an even number, since i excluded remainder 0, a&b will meet at remainder=k/2
					// i need to have even count of this remainder so they form a pair with each others
					// if k=4 => remainders=>[0,1,2,3] => 1,2,3 . a&b will meet a remainder 2
					if (memo [a] % 2 != 0) {
						return false;
					}
					a++; b--;
				} else {
					// the count of remainder x must equal to count of remainder y (x-k), so they can pair
					if (memo [a] != memo [b]) {
						return false;
					}
					a++; b--;
				}
			}

			return true;
		}
	}
}

