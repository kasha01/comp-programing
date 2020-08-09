using System;

// https://www.geeksforgeeks.org/powet-set-lexicographic-order/
namespace misc
{
	public class power_set_in_lexicographic_order
	{
		static string s = "abc";
		public static void driver ()
		{
			rc ("", 0);
		}

		static void rc(string prefix, int ii){
			for (int i = ii; i < s.Length; ++i) {
				string p = prefix + s [i];
				Console.Write (p + " ");
				rc (p, i + 1);
			}
		}
	}
}

