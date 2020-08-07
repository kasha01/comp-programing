using System;

// https://practice.geeksforgeeks.org/problems/additive-sequence/1
namespace misc
{
	public class additive_sequence
	{
		static string s = "1711";
		static int n = s.Length;

		public static void driver ()
		{
			Console.WriteLine(rc (0));
		}

		static bool rc(int k){
			int a = 0;
			for(int i=k;i<n-2;++i){
				a = (a*10) + (s[i] - '0');

				int b=0;
				for(int j=i+1;j<n-1;++j){
					b = (b*10) + (s[j]-'0');

					int c=0;
					for(int m=j+1;m<n;++m){
						c = (c*10) + (s[m]-'0');

						if(c > a+b){
							break;
						}

						if(c == a+b && (rc(i+1) || m+1==n)){
							return true;
						}
					}
				}
			}

			return false;
		}
	}
}

