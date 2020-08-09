using System;

// https://practice.geeksforgeeks.org/problems/palindromic-array/0
namespace GeeksForGeeks_csharp
{
	public class palindromic_array
	{
		static void test()
		{
			int n = 3;
			int[] arr = {3,1, 3};
			int res = solve (arr, n);
			Console.WriteLine (res);
		}

		static int solve(int[] arr, int n){
			if (n == 1)
				return 0;

			int i = 0; int j=n-1;
			int si = 0; int sj = 0;
			int k = 0; 
			while (i < j) {
				if (si + arr [i] < sj + arr [j]) {
					si = si + arr [i];
					i++;
					k++;
				} else if (si + arr [i] > sj + arr [j]) {
					sj = sj + arr [j];
					j--;
					k++;
				} else {
					si = 0;
					sj = 0;
					i++;
					j--;
				}
			}
			return k;
		}
	}
}