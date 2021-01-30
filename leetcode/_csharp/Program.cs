using System;
using System.Collections.Generic;
using System.Collections;

namespace _csharp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			driver ();
		}

		static void driver() {
			int[][] trips = new int[2][];
			trips [0] = new int[]{ 2, 1, 5 };
			trips [1] = new int[]{ 3, 5, 7 };
		}
	}
}