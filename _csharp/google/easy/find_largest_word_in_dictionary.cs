using System;

namespace GeeksForGeeks_csharp
{
	// https://practice.geeksforgeeks.org/problems/find-largest-word-in-dictionary/0
	public class find_largest_word_in_dictionary
	{
		public static void solve()
		{
			string[] dic = { "ale", "apple", "monkey", "plea" };
			string str = "abpcplea";

			int n = dic.Length;
			int m = str.Length;
			int mx = 0;
			string ans = "";
			for (int i = 0; i < n; ++i) {
				int c = 0;
				int k = 0;
				string word = dic [i];
				int w = word.Length;
				for (int j = 0; j < m && k < w; ++j) {
					if (word[k] == str[j]) {
						c++; k++;
					}
				}
				if (c > mx) {
					mx = c;
					ans = word;
				}
			}

			Console.WriteLine (ans);
		}
	}
}

