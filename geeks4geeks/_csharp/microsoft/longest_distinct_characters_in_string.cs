using System;

// https://practice.geeksforgeeks.org/problems/longest-distinct-characters-in-string/0
namespace GeeksForGeeks_csharp
{
	public class longest_distinct_characters_in_string
	{
		public static void test ()
		{
			solve ("aaabadde");
		}

		static void solve(string s){
			int l = s.Length;
			int[] memo = new int[26];
			int answer = -1;

			for (int i = 0; i < 26; i++) {
				memo [i] = -1;
			}

			int last_duplicate_index = 0;

			for (int i = 0; i < l; i++) {
				int char_index = Convert.ToChar(s [i].ToString().ToLower()) - 'a';
				if (memo [char_index] >= last_duplicate_index) {
					answer = Math.Max (answer, i - last_duplicate_index);
					last_duplicate_index = memo [char_index] + 1;
				}
				memo [char_index] = i;
			}

			answer = Math.Max (answer, s.Length - last_duplicate_index);
			Console.WriteLine (answer);
		}
	}
}

