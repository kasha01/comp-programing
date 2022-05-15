using System;

// https://leetcode.com/discuss/interview-question/1478090/Amazon-OA
namespace _csharp
{
	public class _max_number_of_overlaps
	{
		public void max_number_of_overlaps(){
			int[][] arr = new int[3][];
			arr [0] = new int[]{ 0, 10 };
			arr [1] = new int[]{ 2, 8 };
			arr [2] = new int[]{ 3, 4 };

			int[] v = new int[12];
			foreach (var ar in arr) {
				v [ar [0]] = 1;
				v [ar [1] + 1] = -1;
			}

			int cur = 0; int max_overlaps = 0;
			for (int i = 0; i <= 11; ++i) {
				cur = cur + v [i];
				v [i] = cur;
				max_overlaps = Math.Max (max_overlaps, cur);
			}

			int start = -1; int end = 0;
			for (int i = 0; i <= 11; ++i) {
				if (start == -1 && v [i] == max_overlaps) {
					start = i;
				}

				if (v [i] == max_overlaps) {
					end = i;
				}
			}

			Console.WriteLine ("Max Overlap Range:" + start + "-" + end);
		}
	}
}

