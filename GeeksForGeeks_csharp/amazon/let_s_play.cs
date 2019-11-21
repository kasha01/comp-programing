using System;

// https://practice.geeksforgeeks.org/problems/lets-play/0
namespace GeeksForGeeks_csharp
{
	public class let_s_play
	{
		public static void test ()
		{
			// n*m array
			int[,] arr = {
				{ 1, 2, 1, 2 },
				{ 2, 1, 2, 1 }
			};
			Console.WriteLine (solve (arr, 2, 4, 2));
		}

		static public void console_input ()
		{
			int t = Int16.Parse (Console.ReadLine ());
			while (t > 0) {
				t--;
				string _it = Console.ReadLine ();
				string[] it = _it.Split (' ');
				int n = Int32.Parse (it [0]);
				int m = Int32.Parse (it [1]);

				string _items = Console.ReadLine ();
				string[] items = _items.Split (' ');

				int[,] arr = new int[n, m];
				for (int x = 0; x < n * m; ++x) {
					int r = x / m;
					int c = x % m;
					arr [r, c] = Int32.Parse (items [x]);
				}
				int rot = Int32.Parse (Console.ReadLine ());

				bool result = solve (arr, n, m, rot);
				Console.WriteLine (result ? 1 : 0);
			}
		}

		static bool solve (int[,] arr, int n, int m, int r)
		{
			r = r % m;
			bool isEven;
			for (int i = 0; i < n; i++) {
				int e = i % 2;
				if (e == 0)
					isEven = true;
				else
					isEven = false;					

				for (int j = 0; j < m; ++j) {
					if (isEven) {
						// even rotate left
						int x = (j + r) % m;
						if (arr [i, j] != arr [i, x])
							return false;
					} else {
						// odd row -> test rotate right
						int x = Math.Abs ((j - r) % m);
						if (arr [i, j] != arr [i, x])
							return false;
					}
				}
			}
			return true;
		}
	}
}

