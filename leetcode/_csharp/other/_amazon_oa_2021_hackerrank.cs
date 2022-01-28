using System;

// https://leetcode.com/discuss/interview-question/1317796/amazon-oa-2021-hackerrank
namespace _csharp
{
	public class _amazon_oa_2021_hackerrank
	{
		private static void findTheMinimumLengthOfTheRoofThatCovers_K_Cars(){
			int k = 3;
			int[] arr = { 12, 6, 5, 2 };
			Array.Sort (arr); int n = arr.Length;

			if (n <= k) {
				Console.WriteLine (n);
				return;
			}


			int i = 0; int j = k - 1; int d = int.MaxValue;
			while (j < n) {
				d = Math.Min (d, arr [j] - arr [i] + 1);
				++j; ++i;
			}

			Console.WriteLine (d);
		}

		public static void decode_the_input_string_into_original_string(){
			string s = "mnesi___ya__k____mime";
			int n = s.Length;
			int k = 3;
			string res = "";

			int r = k; int c = n / k;

			for (int j = 0; j <= c - r; ++j) {
				for (int a = 0; a < k; ++a) {
					int x = (a * c) + (j + a);
					char ch = s [x];
					if (ch == '_') {
						res = res + " ";
					} else {
						res = res + ch;
					}
				}
			}

			Console.WriteLine (res);
		}
	}
}