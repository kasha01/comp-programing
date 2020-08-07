using System;

// https://www.geeksforgeeks.org/generate-binary-strings-without-consecutive-1s/
namespace misc
{
	public class generate_all_binary_strings_without_consecutive_1s
	{
		public static void driver ()
		{
			rc (4, 0, "");
		}

		static void rc(int n, int d, string num){
			if (n == 0) {
				Console.WriteLine (num);
				return;
			}

			rc (n - 1, 0, num + "0");

			if (d != 1)
				rc (n - 1, 1, num + "1");
		}
	}
}

