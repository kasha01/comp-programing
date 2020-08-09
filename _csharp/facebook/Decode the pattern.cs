using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/decode-the-pattern/0
namespace GeeksForGeeks_csharp
{
	public class Decode_the_pattern
	{
		public static void solve ()
		{
			precompute ();
			int n = 3;
			Console.WriteLine (list [n - 1]);
		}

		static List<string> list = new List<string>();
		static void precompute(){
			list.Add ("1");

			for (int i = 1; i < 20; i++) {
				string r = list[i-1];
				int c = 1;
				int x = int.Parse(r [0].ToString());
				string temp = "";

				int n = r.Length;
				for (int j = 1; j < n; ++j) {
					int jj = int.Parse(r [j].ToString());
					if (jj == x) {
						c++;
					} else {
						temp = temp + c + x;
						c = 1;
						x = jj;
					}
				}
				temp = temp + c + x;
				list.Add (temp);
			}
		}

	}
}

