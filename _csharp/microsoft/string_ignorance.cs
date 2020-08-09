using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/string-ignorance/0
namespace GeeksForGeeks_csharp
{
	public class string_ignorance
	{
		static void solve (string s){
			HashSet<string> map = new HashSet<string> ();
			for (int i = 0; i < s.Length; ++i) {
				string c = s [i].ToString();
				if (map.Contains (c) || map.Contains(c.ToLower())) {
					map.Remove(c.ToLower());
				} else {
					Console.Write (c);
					map.Add (c.ToLower());
				}
			}
		}
	}
}

