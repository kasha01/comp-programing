using System;

// https://practice.geeksforgeeks.org/problems/search-in-a-rotated-array/0
namespace GeeksForGeeks_csharp
{
	public class search_in_a_rotated_array
	{
		static int[] arr = { 5 ,6 ,7 ,8 ,9 ,10 ,1 ,2 ,3};
		public static void test ()
		{
			int n = 9;
			int res = bs (0, n - 1, 10);
			Console.WriteLine (res);
		}

		static int bs(int i, int j, int k){
			int m = ((j - i) / 2) + i;

			int x = arr [m];
			if (arr [m] == k)
				return m;

			if(j-i==1){
				if(arr[i] == k)
					return i;
				if(arr[j] == k)
					return j;

				return -1;
			}

			if (arr [i] <= arr [m]) {
				// left section not rotated -> check if k is in the range i->m
				if (k < arr [m] && k >= arr[i]) {
					return bs (i, m, k);
				}
			} else {
				// left section is rotated -> k can either be less than m OR greater than i (since it is rotated)
				if(k >= arr[i] || k < arr[m]){
					return bs (i, m, k);
				}
			}

			if (arr [m] <= arr [j]) {
				// right section not rotated -> check if k is in the range m->j
				if (k > arr [m] && k <= arr[j]) {
					return bs (m, j, k);
				}
			} else {
				// right section is rotated -> k can either be less than j OR greater than m (since it is rotated)
				if (k > arr [m] || k <= arr [j]) {
					return bs (m, j, k);
				}
			}

			return -1;
		}
	}
}

