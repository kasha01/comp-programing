using System;

// https://practice.geeksforgeeks.org/problems/nearest-multiple-of-10/0
namespace GeeksForGeeks_csharp
{
	public class nearest_multiple_of_10
	{
		public static void test ()
		{
			solve ("99");
		}

		static void solve(string s){
			int n = s.Length;
			int[] arr = new int[n+1];

			for (int i = n - 1; i >= 0; i--) {
				int d = s [i] - '0';
				arr [n-1-i] = d;
			}

			int first_digit = arr[0];
			if (first_digit <= 5) {
				arr [0] = 0;
			} else if (first_digit > 5) {
				arr [0] = 0;
				int carry = 1;
				for (int i = 1; i < n; i++) {
					int x = carry + arr[i];
					if (x > 9) {
						arr [i] = x % 10;
						carry = 1;
					} else {
						carry = 0;
						arr [i] = x;
						break;
					}
				}

				if (carry == 1) {
					arr [n] = 1;
				}
			}

			if (arr [n] != 0)
				Console.Write (arr [n]);

			for (int i = n-1; i >= 0; i--) {
				Console.Write (arr [i]);
			}
		}
	}
}

