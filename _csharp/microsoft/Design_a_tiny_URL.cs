using System;
using System.Collections.Generic;

//https://practice.geeksforgeeks.org/problems/design-a-tiny-url-or-url-shortener/0
namespace GeeksForGeeks_csharp
{
	public class Design_a_tiny_URL
	{
		public static void solve ()
		{
			int n = 56;
			string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			List<int> rem = new List<int> ();

			while (n >=1) {
				int r = n % 62;
				n = n / 62;
				rem.Add (r);
			}

			string ans = "";
			for (int i = rem.Count-1; i>=0; --i) {
				ans = ans + str [rem [i]];
			}
			Console.WriteLine (ans);
		}
	}
}

