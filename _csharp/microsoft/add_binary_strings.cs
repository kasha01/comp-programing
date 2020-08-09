using System;

// https://practice.geeksforgeeks.org/problems/add-binary-strings/0
namespace GeeksForGeeks_csharp
{
	public class add_binary_strings
	{
		public static void test ()
		{
			solve ("1101", "111");
		}

		static void solve(string s1, string s2){
			int n = Math.Max(s1.Length, s2.Length);
			int c=0;
			string result = "";
			for(int i=0;i<n;++i){
				int c1=0;
				int c2=0;
				if(s1.Length - i - 1 >=0){
					c1 = Convert.ToInt32(s1[s1.Length - i - 1].ToString());
				}
				if(s2.Length - i - 1 >=0){
					c2 = Convert.ToInt32(s2[s2.Length - i - 1].ToString());
				}

				int d = c1+c2+c;
				if (d >= 2) {
					c = 1;
					d = d % 2;
				} else {
					c = 0;
				}
				result = result + d;
			}

			if(c>0){
				result = result + 1;
			}

			for (int i = result.Length - 1; i >= 0; --i) {
				Console.Write (result [i]);
			}
		}
	}
}

