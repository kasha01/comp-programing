using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/column-name-from-a-given-column-number/0
namespace GeeksForGeeks_csharp
{
	public class column_name_from_a_given_column_number
	{
		public static void solve ()
		{
			int n = 104;
			solve (n);
		}

		static void solve(int n){
			List<char> result = new List<char> ();
			while (n > 0) {
				int x = n % 26;
				char c;
				if (x == 0) {
					c = 'Z';
					n = (n / 26) - 1;
				} else {
					c = Convert.ToChar(65 - 1 + x);
					n = n / 26;
				}
				result.Add (c);
			}

			for (int i=result.Count-1; i>=0;i--) {
				Console.Write (result[i]);
			}
		}
	}
}

