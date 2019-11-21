using System;

// https://practice.geeksforgeeks.org/problems/finding-position/0
namespace GeeksForGeeks_csharp
{
	public class finding_position
	{
		public static void test ()
		{
			Console.WriteLine (solve (9));
		}

		static int solve(int n){
			if (n == 1)
				return 1;

			int i = 0;
			while (n > 1) {
				i++;
				n = n / 2;
			}

			return (int) Math.Pow(2,i);
		}
	}
}

