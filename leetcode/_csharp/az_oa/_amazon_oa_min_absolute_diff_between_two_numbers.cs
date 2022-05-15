using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question/376980
namespace _csharp
{
	public class _amazon_oa_min_absolute_diff_between_two_numbers
	{
		public void solve(){
			int[] arr = new int[]{15,14};
			int n = arr.Length;
			SortedSet<int> set = new SortedSet<int> ();

			for(int i=0;i<n;++i){
				int x = arr[i];
				set.Add (x);

				if ((x & 1) == 0) {
					// event
					while (x > 0 && (x & 1) == 0) {
						set.Add(x/2);
						x = x / 2; //x >> 1;
					}
				} else {
					// odd. just multiply by two.
					set.Add (x * 2);
				}
			}

			int prev = -1;
			int diff = int.MaxValue;
			foreach (var k in set){
				if (prev == -1) {
					prev = k;
					continue;
				}
			
				diff = Math.Min (diff, k - prev);
				prev = k;
			}

			Console.WriteLine (diff);
		}
	}
}