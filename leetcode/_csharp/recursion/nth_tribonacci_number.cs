using System;

// https://leetcode.com/problems/n-th-tribonacci-number/submissions/
namespace _csharp
{
	public class nth_tribonacci_number
	{
		static int fibo(int n){
			if (n == 0)
				return 0;
			if (n == 1 || n == 2)
				return 1;


			int a = 0;
			int b = 1;
			int c = 1;
			int r = 0;

			for (int i = 3; i <= n; i++) {
				r = a + b + c;

				a = b;
				b = c;
				c = r;
			}

			return r;
		}
	}
}

