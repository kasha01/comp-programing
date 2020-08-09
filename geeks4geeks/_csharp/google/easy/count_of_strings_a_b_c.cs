using System;

namespace GeeksForGeeks_csharp
{
	// https://practice.geeksforgeeks.org/problems/count-of-strings-that-can-be-formed-using-a-b-and-c-under-given-constraints/0
	public class count_of_strings_a_b_c
	{
		public void solve()
		{
			// int put r
			int r=3;

			if (r == 1) {
				Console.WriteLine ("Answer: " + 3);
				return;
			}

			// 0b,0c
			int s1=1;

			// 0b,1c
			double s2= r;

			// 0b,2c
			double s3=(r*(r-1))/2; 

			// 1b,1c
			double s4=r*(r-1);

			// 1b,2c
			double s5 = (r*(r-1)*(r-2))/2;

			// 1b,0c
			double s6 = r;

			double ss = s1 + s2 + s3 + s4 + s5 + s6;
			Console.WriteLine ("Answer: " + ss);
		}
	}
}