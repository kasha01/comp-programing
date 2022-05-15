using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question/1705154/SubSet-Array

/*
 * Hello, i encounter a problem about Subsetting an array
"Given an array of Integers in which you have to subset it into 2 sub, subA and SubB where sum of SubA > sum of SubB and count of SubA < count of SubB.
return the SubB"

input  : [6,5,3,2,4,1,2]
output : [4, 5, 6]
explanation :
subA =  4 + 5 + 6  =  15
the count is 3
and 
subB = [3,2,2,1] = 8
count is 4
*/
namespace _csharp
{
	public class _fb_oa_subarray_a_b
	{
		public void solve(){
			var arr = new int[]{ 6, 5, 3, 2, 4, 1, 2 };
			int n = arr.Length;

			if (n <= 1)
				Console.WriteLine ("empty array");

			Array.Sort (arr);
			int sum = 0;
			foreach (int x in arr) {
				sum = sum + x;
			}

			int i = n - 1; int sub_a_sum = 0; int[] sub_array_a = new int[0]; int[] sub_array_b = new int[0];
			while (i > n/2) {
				sub_a_sum = sub_a_sum + arr [i];
				sum = sum - arr [i];
				if (sub_a_sum > sum) {
					sub_array_a = new int[n - i];
					sub_array_b = new int[i];

					Array.Copy (arr, i, sub_array_a, 0, n - i);
					Array.Copy (arr, 0, sub_array_b, 0, i);
					break;
				}

				--i;
			}

			Console.Write ("sub array A: ");
			foreach (var x in sub_array_a)
				Console.Write (x + " ");

			Console.WriteLine ("");

			Console.Write("sub array B: ");
			foreach (var x in sub_array_b)
				Console.Write (x + " ");
		}
	}
}

