using System;

namespace GeeksForGeeks_csharp
{
	public class excel_sheet
	{
		#region excel sheet part 1
		// https://practice.geeksforgeeks.org/problems/excel-sheet/0
		public static void solve_part_1_1 ()
		{
			string ans = "";
			int n = 1;
			char[] arr = {'Z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y'};
			while (n > 0) {
				int r = n%26;
				n = n/26;
				if (r == 0)
					n = n - 1;

				ans = arr[r] + ans;
			}
			Console.WriteLine (ans);
		}

		public static void solve_part_1_2()
		{
			string ans = "";
			int n = 26;
			while (n > 0) {
				n--;
				int r = n%26;
				n = n/26;
				string c = Char.ConvertFromUtf32(r+65);	// 65 is the ascii code of 'A'
				ans = c + ans;
			}
			Console.WriteLine (ans);
		}

		#endregion

		#region excel sheet part 2
		// https://practice.geeksforgeeks.org/problems/excel-sheet-part-2/0
		public static void solve_part_2 ()
		{
			double ans = 0;
			int d = 0;
			string s = "AA";
			for (int i = s.Length-1; i>=0; --i) {
				int c = s [i] - 64;
				ans = ans + (Math.Pow(26,d)*c);
				d++;
			}
			Console.WriteLine (ans);
		}
		#endregion
	}
}

