using System;

// https://www.geeksforgeeks.org/print-all-combinations-of-given-length/
namespace misc
{
	public class print_all_possible_strings_of_length_k_that_can_be_formed_from_a_set_of_n_characters
	{
		static char[] arr;
		static int n;
		static void driver(){
			arr = new char[] { 'a', 'b' };
			n = arr.Length;
			rc (3, "");
		}

		static void rc(int k, string prefix){
			if (k == 0) {
				Console.WriteLine (prefix);
				return;
			}

			for (int i = 0; i < n; ++i) {
				string p = prefix + arr [i];
				rc (k - 1, p);
			}
		}
	}
}