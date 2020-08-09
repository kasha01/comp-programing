using System;

// https://practice.geeksforgeeks.org/problems/buildings-receiving-sunlight/0
namespace GeeksForGeeks_csharp
{
	public class buildings_receiving_sunlight
	{
		public static void test ()
		{
			int[] arr = { 6 ,2 ,8 ,4 ,11, 13};
			solve (arr, 6);
		}

		static void solve(int[] arr, int n){
			int s = 1;
			int m = arr[0];
			for(int i=1;i<n;++i){
				if(arr[i] >= m){
					// building taller than tallest building so far
					m = arr[i];
					s++;
				}
			}
			Console.WriteLine(s);
		}
	}
}

