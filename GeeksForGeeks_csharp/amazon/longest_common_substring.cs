using System;

// https://practice.geeksforgeeks.org/problems/longest-common-substring/0
namespace GeeksForGeeks_csharp
{
	public class longest_common_substring
	{
		static void solve(string s1, string s2){
			int[,] mem = new int[s1.Length+1, s2.Length+1];
			int lcs = 0;

			for (int i = 1; i <= s1.Length; ++i) {
				for (int j = 1; j <= s2.Length; ++j) {
					if (s1 [i-1] == s2 [j-1]) {
						mem [i, j] = mem [i - 1, j - 1] + 1;
						lcs = Math.Max (mem [i, j], lcs);
					}
				}
			}

			Console.WriteLine (lcs);
		}
	}
}