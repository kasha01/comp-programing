using System;

// https://practice.geeksforgeeks.org/problems/distinct-transformations/0
namespace GeeksForGeeks_csharp
{
	public class distinct_transformation
	{
		int solve (string source, string target)
		{
			int sl = source.Length;
			int tl = target.Length;

			if (tl > sl) {
				return 0;
			}

			if (tl == 0) {
				return 1;
			}

			int[,] memo = new int[tl + 1, sl + 1];

			for (int i = 0; i <= sl; ++i) {
				memo [0, i] = 1;
			}

			for (int i = 1; i <= tl; ++i) {
				for (int j = i; j <= sl; ++j) {
					if (source [j - 1] == target [i - 1]) {
						memo [i, j] = memo [i - 1, j - 1] + memo [i, j - 1];
					} else {
						memo [i, j] = memo [i, j - 1];
					}
				}
			}
			return memo [tl, sl];
		}
	}
}

