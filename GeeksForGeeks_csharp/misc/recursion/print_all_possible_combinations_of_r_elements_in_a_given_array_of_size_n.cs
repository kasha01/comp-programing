using System;

// https://www.geeksforgeeks.org/print-all-possible-combinations-of-r-elements-in-a-given-array-of-size-n/
namespace misc
{
	public class print_all_possible_combinations_of_r_elements_in_a_given_array_of_size_n
	{
		static int[] arr;
		private static int[] temp;
		public static void driver ()
		{
			int n = 4;
			int r = 2;
			arr = new int[]{1,2,3,4};
			temp = new int[r];
			rc (0, 0, r, n);

			temp = new int[r];
			Console.WriteLine ();
			rc_2(0, 0, r, n);
		}

		static void rc(int startIndex, int tempIndex, int r, int n){
			if (r <= 0) {
				// print temp
				foreach(int t in temp){
					Console.Write (t + " ");
				}
				Console.WriteLine ();
				return;
			}

			for (int j = startIndex; j < n; ++j) {
				temp [tempIndex] = arr [j];	
				rc (j + 1, tempIndex + 1, r - 1, n);
			}
		}

		static void rc_2(int i, int tempIndex, int r, int n){
			if (tempIndex == r) {
				// print temp
				foreach(int t in temp){
					Console.Write (t + " ");
				}
				Console.WriteLine ();
				return;
			}

			// i can exceed on excluded condition, since i am only incrementing i, so the above tempIndex==r return won't apply.
			if (i >= n)
				return;

			// included
			temp [tempIndex] = arr [i];
			rc_2 (i + 1, tempIndex + 1, r, n);

			// excluded
			rc_2 (i + 1, tempIndex, r, n);
		}
	}
}

