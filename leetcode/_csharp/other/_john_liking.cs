using System;

// https://leetcode.com/discuss/interview-question/813816/Amazon-Interview
/* *
 * Digits in increasing order like 149, 468, 789, etc. He does not like numbers that don't follow this rule like 543, 664, 299, etc.
 * Given a number N as input, find the largest number less than or equal to N which will appeal to John's liking.
*/
namespace _csharp
{
	public class _john_liking
	{
		public static void test()
		{
			MonotoneIncreasingDigits (1000000000002);
			MonotoneIncreasingDigits (543);
			MonotoneIncreasingDigits (664);
			MonotoneIncreasingDigits (299);
			MonotoneIncreasingDigits (229);
			MonotoneIncreasingDigits (987);
			MonotoneIncreasingDigits (7987);
			MonotoneIncreasingDigits (1987);
		}

		static void MonotoneIncreasingDigits(long n) {
			var arr = n.ToString().ToCharArray();
			int m = arr.Length;

			// fill in number_array
			var number_arr = new long[m];
			for(int i=0;i<m;++i){
				number_arr [i] = arr [i] - '0';
			}

			int start = 0;					// number_array start index
			int mark = number_arr.Length;	// mark at which the number is not in increasing order
			for(int i=m-1;i>0;--i){
				if (number_arr [i - 1] >= number_arr [i]) {
					mark = i-1;
					if (m - mark == 10) {
						// the mark can no longer fit an increasing order of integers 1-9. truncate the number by marking the start index and exit
						start = i;
						break;
					}

					// decrease number_arr value to the minimum of (its value - 1) or (how munch I can fit in a space of i -> to -> m)
					// this to resolve an edge case if number_arr [i - 1] is the last digit and its greater than the following digit (e.g. 987)
					number_arr [i - 1] = Math.Min (number_arr [i - 1] - 1, 9 - (m - 1 - (i - 1)));
				}
			}

			int k = 9;	// replace all digits from first digit till mark digit with an increasing order of integers(e.g. ...789)
			for (int i = m-1; i > mark; --i) {
				number_arr [i] = k; --k;	// decrease k so I can have an increasing order
			}

			// concatinate to integer numbers to string starting from start index, if start index is not 0, that means I have left side zeros to ignore.
			string ans = "";
			for (int i = start; i < m; ++i) {
				ans = ans + number_arr [i];
			}

			Console.WriteLine ("John liking for " + n + " is: " + ans);
		}
	}
}