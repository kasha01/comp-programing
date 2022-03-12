using System;

// https://leetcode.com/discuss/interview-experience/906535/amazon-sde-i-bangalore-october-2020-offer
namespace _csharp
{
	/*
	 * Given a set of N numbers (both positive and negative) sorted in increasing order with A[i] < A[j] for all i<j, 
	 * find whether there exists an index i (i = 1 .. N) such that A[i] = i. If multiple answers are present return any one of them.
	 * (desired complexity O(log n))
	*/
	public class _get_index_equals_value
	{
		private static void getIndexValue(){
			int[] arr = new int[]{-2,-1,1,3,6,9,10,12,14,31};
			int ans = -1;
			int lo = 0; int hi = arr.Length - 1;
			while (lo <= hi) {
				int mid = lo + (hi - lo) / 2;
				int x = arr [mid];
				if (x < 0) {
					lo = mid + 1;
				} else if (x > mid) {
					hi = mid - 1;
				} else if (x < mid) {
					lo = mid + 1;
				} else {
					ans = mid;
					break;
				}
			}

			Console.WriteLine (ans);
		}
	}
}