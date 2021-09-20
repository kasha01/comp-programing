using System;
using System.Collections.Generic;

// https://leetcode.com/problems/split-a-string-into-the-max-number-of-unique-substrings/
namespace _csharp
{
	public class _1593_split_a_string_into_the_max_number_of_unique_substrings
	{
		public int MaxUniqueSplit(string s) {
			int n = s.Length;

			HashSet<string> set = new HashSet<string>();
			return rc (0, s, n, set);
		}

		public int rc(int x, string s, int n, HashSet<string> set){
			if (x >= n)
				return 0;

			int k = 0;
			string s1 = "";
			for (int i = x; i < n; ++i) {
				s1 = s1 + s[i];
				if(!set.Contains(s1)){
					set.Add (s1);
					k = Math.Max (k, 1 + rc (i + 1, s, n, set));
					set.Remove (s1);
				}
			}

			return k;
		}
	}
}

