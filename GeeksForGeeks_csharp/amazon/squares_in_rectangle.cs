using System;

// https://practice.geeksforgeeks.org/problems/squares-in-reactangle/0
namespace GeeksForGeeks_csharp
{
	public class squares_in_rectangle
	{
		public static void test ()
		{
			Console.WriteLine (solve (5,4));
		}
		
		static long solve(long n, long m){
			long a = Math.Max (n, m);
			long b = Math.Min (n, m);

			if (a % b == 0) {
				return (a / b)%1000000007;
			}

			long s = 0;
			while (a != 1 && b != 1) {
				s = s + (a / b)%1000000007;

				if (a % b == 0) {
					break;
				} else {
					a = a % b;
					long aa = a;
					long bb = b;
					a = Math.Max(aa,bb);
					b = Math.Min(aa,bb);
				}
			}

			if (a == 1 || b == 1) {
				long x = Math.Max (a, b);
				s = s + x%1000000007;
			}

			return s;
		}
	}
}

