using System;

// https://practice.geeksforgeeks.org/problems/lucky-numbers/0
namespace GeeksForGeeks_csharp
{
	public class lucky_number
	{
		public static void test ()
		{
			bool res = solve (65401);
			Console.WriteLine (res ? 1 : 0);
		}

		static bool solve(int n){
			int i = 2;
			while (n >= i) {
				if (n % i == 0)
					return false;

				n = n - (n / i);
				i++;
			}
			return true;
		}
	}
}

