using System;

// https://practice.geeksforgeeks.org/problems/print-pattern/0
namespace GeeksForGeeks_csharp
{
	public class print_pattern
	{
		static bool flag = false;
		static int nn = 16;

		static public void test () {
			nn = 16;
			flag = false;
			solve(nn);
			Console.WriteLine();
		}

		static void solve(int n){
			if (flag && n == nn) {
				Console.Write(n + " ");
				return;
			}

			if (n > 0 && !flag) {
				// if n > 0 and flag has not flipped yet. keep reducing n
				solve (n - 5);
			} else if (n <= 0 && !flag) {
				// if n <= 0 and flag has not flipped yet. flip flag and start increasing
				flag = true;
				solve (n + 5);
			} else if (flag) {
				solve (n + 5);
			}

			Console.Write(n + " ");
		}
	}
}

