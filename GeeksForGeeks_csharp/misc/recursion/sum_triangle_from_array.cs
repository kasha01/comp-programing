using System;
using System.Collections.Generic;

// https://www.geeksforgeeks.org/sum-triangle-from-array/
namespace misc
{
	public class sum_triangle_from_array
	{
		public static void driver ()
		{
			List<int> a = new List<int>{ 1, 2, 3, 4, 5 };
			rc (a);
		}

		static void rc(List<int> arr){
			int n = arr.Count;
			if (n <= 0)
				return;

			var temp = new List<int> ();
			for (int i = 0; i < n-1; ++i) {
				temp.Add (arr [i] + arr [i+1]);
			}

			rc (temp);

			// print
			foreach(int t in arr){
				Console.Write (t + " ");
			}
			Console.WriteLine ();
		}
	}
}