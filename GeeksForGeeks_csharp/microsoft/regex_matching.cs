using System;

// https://practice.geeksforgeeks.org/problems/-regex-matching/0
namespace GeeksForGeeks_csharp
{
	public class regex_matching
	{
		public static void test ()
		{
			Console.WriteLine(solve("oaltarr", "coaltarre") ? 1 : 0);
		}

		static bool solve(string p, string s){
			if (p [0] == '^') {
				// match start
				int j = 0;	// string index
				for (int i = 1; i < p.Length; i++) {
					// j == s.length string has ended without finishing pattern
					if (j == s.Length || p [i] != s [j]) {
						return false;
					}
					j++;
				}
				return true;
			} else if (p [p.Length - 1] == '$') {
				// match end
				int j = s.Length - 1; // string index from end

				// p.length-2 so to skip $ at end of pattern and start from first last letter on pattern.
				for (int i = p.Length - 2; i >= 0; i--) {
					if (j < 0 || p [i] != s [j]) {
						// j<0 => string ended without finishing pattern
						return false;
					}
					j--;
				}
				return true;
			} else {
				int pi = 0;
				int i = 0;
				int si = 0; // where i started matching string
				while (pi < p.Length && i < s.Length) {
					if (p [pi] != s [i]) {
						++si;	// increment my start point on matching string
						i = si;
						pi = 0;
						continue;
					}
					pi++; i++;
				}

				// pattern has ended which means all letters matched with a substring of string
				return pi == p.Length;
			}
		}
	}
}

