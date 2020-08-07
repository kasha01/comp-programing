using System;

// https://www.geeksforgeeks.org/combinations-string-digits/
namespace misc
{
	public class combinations_in_a_string_of_digits
	{
		static string num = "1234";
		public static void driver ()
		{
			rc ("", 0);
		}

		static void rc(string prefix, int ii){
			if (ii == num.Length) {
				Console.WriteLine(prefix.Trim());
				return;
			}

			string p = "";
			for (int i = ii; i < num.Length; ++i) {
				p = p + num [i];
				string p1 = prefix + " " + p;
				rc (p1, i + 1);
			}
		}
	}
}

