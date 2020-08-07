using System;
using System.Collections.Generic;

// https://www.geeksforgeeks.org/partition-given-string-manner-ith-substring-sum-1th-2th-substring/

// this is very similar to additive sequence except here I am print the partitions
namespace misc
{
	public class partition_given_string_in_such_manner_that_i_th_substring_is_sum_of__i_1_th_and__i_2_th_substring
	{
		static string s = "11121114";
		static int n = s.Length;
		static Stack<int> stack;
		public static void driver ()
		{
			stack = new Stack<int> ();
			rc (0);

			while (stack.Count > 0) {
				int x = stack.Pop ();
				Console.Write (x + " ");
			}
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
							if (m + 1 == n) {
								stack.Push (c);
								stack.Push (b);
							}
							stack.Push (a);

							return true;
						}
					}
				}
			}

			return false;
		}
	}
}

