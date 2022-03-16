using System;

// https://leetcode.com/discuss/interview-question/376980
namespace _csharp
{
	public class _amazon_oa_min_absolute_diff_between_two_numbers
	{
		/* THIS IS WRONG. IT FAILS FOR {14,15}
		 * Since I want the min diff, I want to minimize the numbers, so I always want to divide.
		 * if it's odd there is no need to multiply by 2 b/c that will get me a larger even, so leave as is.
		 * if it is even, then I need to keep dividing by 2 until I reach a (smaller) odd result. 
		 * example: [280,35] the min diff here is 0, as I can divide 280 by 2 (twice) to get 70, and multiply 35 by 2 to get 70. diff=70-70=0.
		 * Notice I can get the same result by just dividing 280 to the minimum odd number: 280 -> 140 -> 70 -> 35. now I have diff=35-35=0.
		*/
		public void solve(){
			int[] arr = new int[]{15,14};
			int n = arr.Length;

			int[] all_odds = new int[n];

			// convert all evens to odd.
			for(int i=0;i<n;++i){
				int x = arr[i];
				// it is even
				while (x > 0 && (x & 1) == 0) {
					x = x >> 1;
				}

				all_odds [i] = x;
			}

			Array.Sort (all_odds);

			int diff = int.MaxValue;
			for (int i = 0; i < n-1; ++i) {
				diff = Math.Min (diff, all_odds [i + 1] - all_odds [i]);
			}

			Console.WriteLine (diff);
		}
	}
}