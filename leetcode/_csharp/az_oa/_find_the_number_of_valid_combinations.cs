using System;

// https://leetcode.com/discuss/interview-question/1140678/Amazon-OA
namespace _csharp
{
	public class _find_the_number_of_valid_combinations
	{
		public static void solve(){
			int target = 11;
			int[] a = { 2, 3, 5 };
			int[] b = { 5 };
			int[] c = { 2, 3, 10 };
			int[] d = { 1, 2 };

			int na = a.Length; int nb = b.Length; int nc = c.Length; int nd = d.Length;
			int[] ab = new int[na*nb]; int[] cd = new int[nc*nd];

			int k = 0;
			for (int i = 0; i < na; ++i) {
				for (int j = 0; j < nb; ++j) {
					ab [k] = a [i] + b [j]; ++k;
				}
			}

			k = 0;
			for (int i = 0; i < nc; ++i) {
				for (int j = 0; j < nd; ++j) {
					cd [k] = c [i] + d [j]; ++k;
				}
			}

			Array.Sort (ab); Array.Sort (cd);

			int sum = 0;
			int ab_pointer = 0; int cd_pointer = cd.Length - 1;
			while (ab_pointer < ab.Length && cd_pointer >= 0) {
				int s = ab [ab_pointer] + cd [cd_pointer];
				if (s > target) {
					cd_pointer--;
				} else {
					sum = sum + (cd_pointer + 1);
					ab_pointer++;
				}
			}

			Console.WriteLine (sum);
		}
	}
}

