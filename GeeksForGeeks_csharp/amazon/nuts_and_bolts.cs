using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/nuts-and-bolts-problem/0
namespace GeeksForGeeks_csharp
{
	public class nuts_and_bolts
	{
		public static void solve(){
			int t = Int16.Parse(Console.ReadLine());
			HashSet<string> map = new HashSet<string> ();

			while(t>0){
				map.Clear();
				t--;
				int n = Int32.Parse(Console.ReadLine());
				string _bolts = Console.ReadLine();
				string[] bolts = _bolts.Split(' ');

				string _nuts = Console.ReadLine();
				string[] nuts = _nuts.Split(' ');

				// ! # $ % & * @ ^ ~ 
				bool[] result = new bool[9];

				for (int i = 0; i < n; ++i) {
					map.Add (bolts [i]);
				}

				for (int i = 0; i < n; ++i) {
					if (map.Contains (nuts [i])) {
						map.Remove (nuts [i]);
						switch (nuts [i]) {
						case "!":
							result [0] = true;
							break;
						case "#":
							result [1] = true;
							break;
						case "$":
							result [2] = true;
							break;
						case "%":
							result [3] = true;
							break;
						case "&":
							result [4] = true;
							break;
						case "*":
							result [5] = true;
							break;
						case "@":
							result [6] = true;
							break;
						case "^":
							result [7] = true;
							break;
						case "~":
							result [8] = true;
							break;
						}
					}
				}

				string[] c = {"!" ,"#" ,"$" ,"%" ,"&" ,"*" ,"@" ,"^" ,"~" };
				for (int i = 0; i < 9; ++i) {
					if (result [i]) {
						Console.Write (c [i] + " ");
					}
				}
				Console.WriteLine ();
				for (int i = 0; i < 9; ++i) {
					if (result [i]) {
						Console.Write (c [i] + " ");
					}
				}
				Console.WriteLine ();
			}
			// end
		}
	}
}

