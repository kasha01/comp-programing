using System;

// https://practice.geeksforgeeks.org/problems/reverse-bits/0
namespace GeeksForGeeks_csharp
{
	public class reverse_bits
	{
		static void test ()
		{
			ulong n = 1;
			solve (n);
		}

		static void solve(ulong n){
			for (int i = 0; i < 16; i++) {
				ulong a = (ulong) Math.Pow (2, i);
				ulong b = (ulong)Math.Pow (2, 32 - i - 1);

				ulong aa = n & a;
				ulong bb = n & b;

				if (aa == 0) {
					ulong c = ~b;
					n = n & c;
				} else {
					n = n | b;
				}

				if (bb == 0) {
					ulong c = ~a;
					n = n & c;
				} else {
					n = n | a;
				}
			}

			Console.WriteLine (n);
		}
	}
}

