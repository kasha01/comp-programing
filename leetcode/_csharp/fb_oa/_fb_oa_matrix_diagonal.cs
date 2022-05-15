using System;

// https://leetcode.com/discuss/interview-question/1985371/FacebookMeta-E4-SWE-or-Phone-Screening-or-2-Coding-Questions
/*
 * Given a matrix of integers print out its values along the diagonals that move in the top right to bottom left direction. 
 * Each diagonal goes down and to the left as shown in the example. 
*/
namespace _csharp
{
	public class _fb_oa_matrix_diagonal
	{
		public void solve(){
			int[][] arr = new int[3][];
			arr [0] = new int[]{ 1, 2, 3, 4 };
			arr [1] = new int[]{ 5, 6, 7, 8 };
			arr [2] = new int[]{ 9, 10, 11, 12 };

			int r = arr.Length; int c = arr [0].Length;
			int t = r + c - 1;
			for (int s = 0; s < t; ++s) {
				int i = 0; int j = s;
				for (int k = 0; k < r; ++k) {
					if (i < r && j >= 0 && j<c) {
						Console.Write (arr [i] [j] + " ");
					}
					++i; --j;
				}

				Console.WriteLine ();
			}
		}
	}
}