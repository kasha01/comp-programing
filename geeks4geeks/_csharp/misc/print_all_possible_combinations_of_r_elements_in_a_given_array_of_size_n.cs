using System;
using System.Collections.Generic;

// https://www.geeksforgeeks.org/print-all-possible-combinations-of-r-elements-in-a-given-array-of-size-n/
namespace GeeksForGeeks_csharp
{
	public class print_all_possible_combinations_of_r_elements_in_a_given_array_of_size_n
	{
		public static driver(){
			var l = new int[]{ 1, 2, 3, 4 };
			Array.Sort (l);
			backtrack (0, new List<int> (), 3, l.Length, l);
		}

		private static void backtrack (int start, List<int> temp, int r, int n, int[] nums){
			if (r==0) {
				foreach (var x in temp) {
					Console.Write (x + " ");
				}
				Console.WriteLine ();
				return;
			}

			for (int i = start; i < n; ++i) {
				if (i > start && nums [i] == nums [i - 1])
					continue;

				temp.Add (nums [i]);
				backtrack (i + 1, temp, r - 1, n, nums);
				temp.RemoveAt (temp.Count - 1);
			}
		}
	}
}

