using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question/1935030/Maximize-minimum-array
/*
 * We have an array of N positive elements. We can perform M operations on this array. In each operation we have to select a subarray(contiguous) 
 * of length W and increase each element by 1. Each element of the array can be increased at most K times. We have to perform these operations such 
 * that the minimum element in the array is maximized.
*/
namespace _csharp
{
	public class _fb_oa_maximize_minimum_array
	{
		public void solve(){
			int[] arr = { 3, 4, 2, 9, 7 };
			int n = arr.Length;
			int m = 2;
			int w = 4;
			int k = 7;

			int maxOps = Math.Min (k, m);		// max operations
			int mn = int.MaxValue;
			for (int i = 0; i < n; ++i) {
				mn = Math.Min (mn, arr [i]);
			}

			int lo = mn; int hi = mn + maxOps; int ans = -1;
			while (lo <= hi) {
				int mid = lo + (hi - lo) / 2;

				if (isValid (mid, maxOps, w, n, arr)) {
					ans = mid;
					lo = mid + 1;
				} else {
					hi = mid - 1;
				}
			}

			Console.WriteLine ("answer:" + ans);
		}

		private bool isValid(int desiredValue, int maxOps, int w, int n, int[] arr){
			int addedInWindow=0;
			var qu = new Queue<Tuple<int,int>> ();
			for (int i = 0; i < n; ++i) {
				if (qu.Count > 0 && qu.Peek ().Item1 < i - w + 1) {
					var tup = qu.Dequeue ();
					addedInWindow = addedInWindow - tup.Item2;
				}

				// i do +added because I want to add once to the window. where addedInWindow represents the previously added values in the current window.
				int toAddInWindow = Math.Max(0, desiredValue - (arr [i] + addedInWindow));

				// only consider if window size is w => i-w+1>=0
				if (toAddInWindow > maxOps && (i-w+1 >= 0))
					return false;

				qu.Enqueue (Tuple.Create (i, toAddInWindow));
				addedInWindow = addedInWindow + toAddInWindow;
				maxOps = maxOps - toAddInWindow;
			}

			return true;
		}
	}
}

