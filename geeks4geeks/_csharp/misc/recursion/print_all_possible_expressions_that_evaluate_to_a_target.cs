using System;

// https://www.geeksforgeeks.org/print-all-possible-expressions-that-evaluate-to-a-target/
namespace misc
{
	public class print_all_possible_expressions_that_evaluate_to_a_target
	{
		static string s = "";
		static int n;
		static int t;
		static void driver(){
			s = "123";
			n = 3;
			t = 6;

			rc (0, 0, "");

			Console.WriteLine (c);
		}
		static int c = 0;
		static void rc(int r, int ii, string exp){
			c++;
			if (ii == n) {
				if (r == t) {
					// print result
					Console.WriteLine(exp);
				}
				return;			
			}

			int a = 0;
			for (int i = ii; i < n; ++i) {
				a = a * 10 + (s [i] - 48);

				if (ii == 0) {
					rc (a, i + 1, a + "");
					rc (-1 * a, i + 1, -1 * a + "");
				} else {
					rc (r + a, i + 1, exp + "+" + a);
					rc (r - a, i + 1, exp + "-" + a);
					rc (r * a, i + 1, exp + "*" + a);
				}
			}
		}
	}
}

