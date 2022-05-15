using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question/1795813/Facebook-or-Practice-Test-or-Contiguous-Subarrays

/*
 * You are given an array arr of N integers. For each index i, you are required to determine the number of contiguous subarrays that fulfill the following conditions:
The value at index i must be the maximum element in the contiguous subarrays, and
These contiguous subarrays must either start from or end on index i.
Signature

Array arr is a non-empty list of unique integers that range between 1 to 1,000,000,000
Size N is between 1 and 1,000,000
Output
An array where each index i contains an integer denoting the maximum number of contiguous subarrays of arr[i]
Example:
arr = [3, 4, 1, 6, 2]
output = [1, 3, 1, 5, 1]
Explanation:
For index 0 - [3] is the only contiguous subarray that starts (or ends) with 3, and the maximum value in this subarray is 3.
For index 1 - [4], [3, 4], [4, 1]
For index 2 - [1]
For index 3 - [6], [6, 2], [1, 6], [4, 1, 6], [3, 4, 1, 6]
For index 4 - [2]
So, the answer for the above input is [1, 3, 1, 5, 1]
*/
namespace _csharp
{
	public class _fb_oa_puzzle_contiguous_array
	{
		public void solve(){
			var arr = new int[]{ 3, 4, 6, 3, 34, 11, 8, 1, 6, 2 };
			int n = arr.Length;
			var ans = new int[n];

			var st = new Stack<int> ();

			int i = 0;
			while (i < n) {
				if (st.Count > 0 && arr [i] > arr [st.Peek ()]) {
					int x = st.Pop ();
					int l = st.Count == 0 ? x+1 : x - st.Peek();
					int r = i - 1 - x;
					ans [x] = r + l;
				} else {
					st.Push (i); ++i;
				}
			}

			while (st.Count > 0) {
				int x = st.Pop ();
				int l = st.Count == 0 ? x + 1 : x - st.Peek ();
				int r = n - 1 - x;
				ans [x] = r + l;
			}

			foreach (int a in ans)
				Console.Write (a + " ");
		}
	}
}

