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
			int r = solve ("T^F|F");
			Console.WriteLine (r);
		}

		static int solve(string s){
			int n = s.Length;

			int[,] result = new int[n, n]; 
			bool[,] memo = new bool[n,n];

			for (int i = 0; i < n; i = i + 2) {
				memo [i, i] = s [i] == 'T' ? true : false;
			}

			for(int size = 2; size<n; size=size+2){
				for (int start = 0; start < size - 2; start = start + 2) {
					for (int op = start + 1; op < size - 1; op = op + 2) {
						int i = start; int j = op - 1;
						int x = op + 1; int y = size;
						char oper = s [op];

						if (oper == '^') {
							memo[i,size] = memo[i,size] || (memo[i,j] ^ memo[x,y]);
							if (memo [i, size])
								result [i, size]++;
						}
						else if (oper == '|') {
							memo[i,size] = memo[i,size] || (memo[i,j] || memo[x,y]);
							if (memo [i, size])
								result [i, size]++;
						}
						else if (oper == '&') {
							memo[i,size] = memo[i,size] || (memo[i,j] && memo[x,y]);
							if (memo [i, size])
								result [i, size]++;
						}
					}
				}
			}

			return (result[0, n-1]%1003)*2;
		}
	}
}