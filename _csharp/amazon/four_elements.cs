using System;

// https://practice.geeksforgeeks.org/problems/four-elements/0
namespace GeeksForGeeks_csharp
{
	public class four_elements
	{
		public static void test ()
		{
			int[] arr = { 1, 2, 1, 0, 8, 0 };
			bool result = solve (arr, 6, 7);
			Console.WriteLine (result);
		}

		static bool solve(int[] arr, int n, int x){
			Array.Sort (arr);

			for(int i=0;i<n-3;++i){
				for(int j=n-1; j>i+2; j--){
					for(int a=i+1; a<j-1; a++){
						for(int b=j-1;b>a;b--){
							int s = arr [a] + arr [b] + arr [i] + arr [j];
							if (s == x) {
								return true;
							}
						}
					}
				}
			}
			return false;
		}
	}
}

