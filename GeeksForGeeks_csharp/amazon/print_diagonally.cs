using System;

// https://practice.geeksforgeeks.org/problems/print-diagonally/0 
namespace GeeksForGeeks_csharp
{
	public class print_diagonally
	{
		public static void test(){
			int[,] arr = {{1,2,3,4},{5,6,7,8},{9,10,11,12},{13,14,15,16}};
			int N = 4;
			solve (N, arr);
		}

		public static void solve(int N, int[,] arr){
			int yg = 0;
			int xg = 0;
			Console.WriteLine (arr [xg, yg]);
			while (yg < N) {
				yg++;int x=0;
				int y=yg;
				while (x < N && x >= 0 && y < N && y >= 0) {
					Console.Write(arr[x,y] + " ");
					x++;y--;
				}
				if(yg<N)
					Console.WriteLine();
			}

			xg = 0; yg = N - 1;
			while (xg < N) {
				xg++;
				int y=yg;
				int x=xg;
				while (x < N && x >= 0 && y < N && y >= 0) {
					Console.Write(arr[x,y] + " ");
					x++;y--;
				}
				if(xg<N)
					Console.WriteLine();
			}
		}
	}
}