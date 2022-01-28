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
			int[][] arr = new int[5][];
			arr [0] = new int[]{ 0, 0, 0 };
			arr [1] = new int[]{ 1, 1, 0 };
			arr [2] = new int[]{ 0, 0, 0 };
			arr [3] = new int[]{ 0, 1, 1 };
			arr [4] = new int[]{ 0, 0, 0 };

			int[][] d = { new int[2]{ -1, 0 }, new int[2]{ 1, 0 }, new int[2]{ 0, -1 }, new int[2]{ 0, 1 } };
		}
	}
}