
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
			var cc = new _fb_oa_matrix_diagonal ();
			cc.solve ();

			Console.WriteLine ("===========");
			Console.WriteLine (Math.Log (100));

			var v = new int[5][];
			v [0] = new int[]{ 1, 2, 0, 1 };
			v [1] = new int[]{ 2, 0 };
			v [2] = new int[]{ 2, 0 };
			v [3] = new int[]{ 1, 2 };
			v [4] = new int[]{ 0, 1, 0 };

			//Console.WriteLine (1 << 0);
			var map = new Dictionary<Tuple<int,int>, int> ();
			map.Add (Tuple.Create (1, 1),1);
			map.Add (Tuple.Create (2, 1),1);

			if (map.ContainsKey (Tuple.Create (1, 2)))
				Console.WriteLine (1);

			int[,] ar = new int[,]{ { 1, 2 } };

			int[][] arr = new int[5][];
			arr [0] = new int[]{ 0, 0, 0 };
			arr [1] = new int[]{ 1, 1, 0 };
			arr [2] = new int[]{ 0, 0, 0 };
			arr [3] = new int[]{ 0, 1, 1 };
			arr [4] = new int[]{ 0, 0, 0 };

			Array.Sort (arr [0], (x, y) => CompareMe (x, y));

			int[][] d = { new int[2]{ -1, 0 }, new int[2]{ 1, 0 }, new int[2]{ 0, -1 }, new int[2]{ 0, 1 } };
		}

		public static int CompareMe(int a, int b){
			return 1;
		}
	}
}