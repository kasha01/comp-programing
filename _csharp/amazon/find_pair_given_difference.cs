using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/find-pair-given-difference/0
namespace GeeksForGeeks_csharp
{
	public class find_pair_given_difference
	{
		public static void test ()
		{
			int[] arr = {  90 ,70 ,20 ,80 ,50};
			Console.WriteLine (solve(arr,5,45));
		}

		static int solve(int[] arr, int n, int k){
			ISet<int> set = new HashSet<int>();
			for(int i=0;i<n;++i){
				set.Add(arr[i]);
			}

			for(int i=0;i<n;++i){
				int x = Math.Abs(k-arr[i]);
				if(set.Contains(x))
					return 1;
			}

			return -1;
		}
	}
}

