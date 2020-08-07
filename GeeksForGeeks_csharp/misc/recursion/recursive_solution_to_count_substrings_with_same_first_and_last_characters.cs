using System;

// https://www.geeksforgeeks.org/recursive-solution-count-substrings-first-last-characters/
namespace misc
{
	public class recursive_solution_to_count_substrings_with_same_first_and_last_characters
	{
		static int c = 0;
		public static void driver ()
		{
			solve ("abaa");
		}

		static void solve(string s){
			int n = s.Length;

			for (int i = 0; i < n; ++i) {
				for (int j = 1; j <= n-i; ++j) {
					string p = s.Substring (i, j);
					Console.WriteLine (p);

					int m = p.Length;
					int a = p [0] == p [m - 1] ? 1 : 0;
					c = c + a;
				}
			}

			Console.WriteLine (c);
		}
	}
}

