using System;

// https://practice.geeksforgeeks.org/problems/sum-of-numbers-or-number/0
namespace GeeksForGeeks_csharp
{
	public class sum_of_two_large_numbers
	{
		public static void test(){
			solve("23","25");
		}

		static void solve(string x, string y){
			int c = 0;
			int[] arr = new int[101];
			for (int i = 0; i < 100; ++i) {
				int a = 0; int b = 0;
				if (x.Length-i-1 >=0) {
					a = int.Parse (x [x.Length-i-1].ToString());
				}

				if (y.Length-i-1 >=0) {
					b = int.Parse (y [y.Length-i-1].ToString());
				}

				int s = a + b + c;
				if (s >= 10) {
					arr [i] = s % 10;
					c = s / 10;
				} else {
					arr [i] = s;
					c = 0;
				}
			}
			if (c > 0) {
				arr [100] = c;
			}

			int sum_length=0;
			for (int i = 100; i >=0; i--) {
				if (arr [i] == 0) {
					continue;
				} else {
					sum_length = i + 1;
					break;
				}
			}

			if (sum_length != x.Length) {
				Console.WriteLine (x);
			} else {
				string result = "";
				for(int i=0;i<sum_length;++i){
					result = arr [i].ToString() + result;					
				}
				Console.WriteLine (result);
			}
		}
	}
}

