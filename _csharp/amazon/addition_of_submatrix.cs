using System;

// https://practice.geeksforgeeks.org/problems/addition-of-submatrix/0
namespace GeeksForGeeks_csharp
{
	public class addition_of_submatrix
	{
		static int[,] arr; 
		public static void test ()
		{
			int t = Int16.Parse(Console.ReadLine());
			while(t>0){
				t--;
				string _items1 = Console.ReadLine();
				string[] items1 = _items1.Split(' ');
				int n = Int32.Parse(items1[0]);
				int m = Int32.Parse(items1[1]);

				string _items = Console.ReadLine();
				string[] items = _items.Split(' ');

				int k = 0;
				arr = new int[n,m];
				for(int i=0;i<n;++i){
					for(int j=0; j<m;++j){
						arr[i,j] = Int32.Parse(items[j+k]);
					}
					k = k + m;
				}

				string _items2 = Console.ReadLine();
				string[] items2 = _items2.Split(' ');
				int r1 = Int32.Parse(items2[0]);
				int c1 = Int32.Parse(items2[1]);
				int r2 = Int32.Parse(items2[2]);
				int c2 = Int32.Parse(items2[3]);

				long s = solve (arr, r1-1, r2-1, c1-1, c2-1);
				Console.WriteLine (s);
			}
		}

		static long solve(int[,] arr, int r1, int r2, int c1, int c2){
			long s = 0;
			for (int i = r1; i <= r2; i++) {
				for (int j = c1; j <= c2; j++) {
					s = s + arr [i, j];
				}
			}
			return s;
		}
	}
}

