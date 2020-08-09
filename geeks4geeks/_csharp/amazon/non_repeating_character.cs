using System;

// https://practice.geeksforgeeks.org/problems/non-repeating-character/0
namespace GeeksForGeeks_csharp
{
	public class non_repeating_character
	{
		public static void solve ()
		{
			int[] arr = new int[26];
			string s = "hellohh";

			int n = s.Length;
			for (int i = 0; i < n; ++i) {
				int x = s [i];
				int xx = x - 'a';

				if (arr [xx] == 0) {
					arr [xx] = i + 1;
				} else {
					arr [xx] = -1;
				}
			}

			bool flag = false;
			int k = int.MaxValue;
			for (int i = 0; i < 26; ++i) {
				if (arr [i] > 0) {
					flag = true;
					k = Math.Min (k, arr [i] - 1);
				}
			}

			if (flag)
				Console.WriteLine (s[k]);
			else
				Console.WriteLine (-1);
		}
	}
}

