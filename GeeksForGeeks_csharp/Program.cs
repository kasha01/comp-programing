using System;
using System.Collections.Generic;

// check let's play for 2 dim input array

namespace GeeksForGeeks_csharp
{
	class MainClass
	{
		public void init ()
		{
			int t = Int16.Parse (Console.ReadLine ());
			while (t > 0) {
				t--;
				int n = Int32.Parse (Console.ReadLine ());
				string _items = Console.ReadLine ();
				string[] items = _items.Split (' ');
			}
		}

		public static void init_arr ()
		{
			int t = Int16.Parse (Console.ReadLine ());
			while (t > 0) {
				t--;
				int n = Int32.Parse (Console.ReadLine ());
				string _items = Console.ReadLine ();
				string[] items = _items.Split (' ');

				int[] arr = new int[n];
				for (int i = 0; i < n; ++i) {
					arr [i] = Int32.Parse (items [i]);
				}
			}
		}

		public static void Main (string[] args)
		{
			
		}
	}
}