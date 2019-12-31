using System;
// https://practice.geeksforgeeks.org/problems/carry-counter/0

namespace GeeksForGeeks_csharp
{
	public class carry_counter
	{
		public static void test ()
		{
			solve ("101", "99");
		}

		static void solve(string s1, string s2){
			int c = 0;
			int carry_counter = 0;

			int k = Math.Max (s1.Length, s2.Length);

			for (int i = 0; i < k; i++) {
				int c1 = 0;
				if (s1.Length -1 - i >= 0) {
					c1 = (int)s1 [s1.Length -1 - i] - 48;
				}

				int c2 = 0;
				if (s2.Length -1 - i >= 0) {
					c2 = s2 [s2.Length -1 - i] - 48;
				}

				int x = c1 + c2 + c;
				if (x > 9) {
					carry_counter++;
					c = 1;
				} else {
					c = 0;
				}
			}

			Console.WriteLine (carry_counter);
		}
	}
}

