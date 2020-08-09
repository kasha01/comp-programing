using System;

// https://practice.geeksforgeeks.org/problems/next-sparse-binary-number/0
namespace GeeksForGeeks_csharp
{
	public class next_sparse_binary_number
	{
		public static void test ()
		{
			int n = 19169;
			//int n = 44;
			int result = solve (n);
			Console.WriteLine (result);
		}

		static int findZeroingBit(int n, int i){
			// i is this bit and it is not zero

			int thisBit = i;
			int b = 1 << thisBit;
			int x = n & b;
			while(x!=0) {
				thisBit++;
				b = 1 << thisBit;
				x = n & b;
			}

			return thisBit;
		}

		static int solve(int n){
			int i = 0;
			while (i < 18) {
				int b = 1 << i;
				int x = n & b;

				if (x != 0) {
					int nextBit = n & (1 << (i + 1));
					if (nextBit != 0) {
						int zb = findZeroingBit (n, i + 1);

						int c = (int)Math.Pow (2, zb);
						int z = ~(c - 1);
						n = n & z;
						n = n | c;

						i = zb;
					} else {
						++i;
					}
				} else {
					++i;
				}
			}
			return n;
		}
	}
}

