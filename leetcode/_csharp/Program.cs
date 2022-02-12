using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace _csharp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int[,] ar = new int[,]{ { 1, 2 } };

			int[][] arr = new int[5][];
			arr [0] = new int[]{ 0, 0, 0 };
			arr [1] = new int[]{ 1, 1, 0 };
			arr [2] = new int[]{ 0, 0, 0 };
			arr [3] = new int[]{ 0, 1, 1 };
			arr [4] = new int[]{ 0, 0, 0 };

			var ax = new char[]{ '1', '2' };
			var axx = new char[2];
			Array.Copy (ax, axx, 2);
			axx [1] = 'a';

			int k = 1 + '0';
			char v = Convert.ToChar (k);
			Console.WriteLine (v);

			Console.WriteLine (new String (ax));
			Console.WriteLine (new String (axx));

			string ss = new string (ax);

			HashSet<int> set = new HashSet<int> ();
			set.Add (1);
			set.Add (3);
			set.Add (2);


			List<int> list = new List<int> ();
			list.Add (0);
			list.Add (1);
			list.Sort ((a, b) => CompareMe (a, b, arr));
			int[][] d = { new int[2]{ -1, 0 }, new int[2]{ 1, 0 }, new int[2]{ 0, -1 }, new int[2]{ 0, 1 } };
		}

		public static int CompareMe(int a, int b, int[][] arr){
			Console.WriteLine (arr [a] [a]);
			Console.WriteLine (arr [b] [b]);
			return 1;
		}
	}
}