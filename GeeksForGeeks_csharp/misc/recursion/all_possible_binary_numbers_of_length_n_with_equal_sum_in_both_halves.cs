using System;

// https://www.geeksforgeeks.org/all-possible-binary-numbers-of-length-n-with-equal-sum-in-both-halves/
namespace misc
{
	public class all_possible_binary_numbers_of_length_n_with_equal_sum_in_both_halves
	{
		public static void driver ()
		{
			rc (4, 0, 0, "");
		}

		static void rc(int n, int a, int b, string s){

			// we do s[0] != '0' to exclude 0s on the left as they don't count.
			if (n == 0 && a==b && s[0] != '0') {
				Console.WriteLine (s);
				return;
			} else if (n == 1 && a==b && s[0] != '0') {
				int m = s.Length/2;
				string s1 = s.Substring (0, m);
				string s2 = s.Substring (m , m);

				Console.WriteLine (s1 + "0" + s2);
				Console.WriteLine (s1 + "1" + s2);

				return;
			}

			if (n <= 1)
				return;

			rc (n - 2, a + 1, b, "1" + s + "0");
			rc (n - 2, a, b + 1, "0" + s + "1");
			rc (n - 2, a, b, "0" + s + "0");
			rc (n - 2, a + 1, b + 1, "1" + s + "1");
		}
	}
}

