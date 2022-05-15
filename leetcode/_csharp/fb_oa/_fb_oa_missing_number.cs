using System;

// https://leetcode.com/discuss/interview-question/1681459/Facebook-Meta-or-Phone-or-Missing-Number-Word-Break

/*
 * Given an array of integers, return true or false if the numbers in the array go from 0... (N - 1) where N is the length of the array

Linear time, constant space is a requirement

example:
[0,1,2,3,4] = true;
[4,2,1,0,3] = true;
[0,1,5,2,4] = false;
*/
namespace _csharp
{
	public class _fb_oa_missing_number
	{
		public void solve_sum(){
			int[] arr = new int[2];
			int n = arr.Length;

			int expected_sum = ((n) * (n - 1)) / 2;

			int sum = 0; bool hasZero = false;
			foreach (int x in arr) {
				sum = sum + x;
				if (x == 0)
					hasZero = true;
			}
				
			Console.WriteLine (sum == expected_sum && hasZero);
		}

		public void solve_index_mark(){
			int[] arr = new int[]{ 0, 1, 2, 3, 4, 5 };
			int n = arr.Length;
			int mx = n + 1;

			for (int i = 0; i < n; ++i) {
				int val = arr [i] >= 0 ? arr [i] : arr [i] + mx;

				if (val < n)
					arr [val] = arr [val] - mx;		// mark value-index as negative.
			}

			bool ans = true;
			for (int i = 0; i < n; ++i) {
				if (arr [i] > 0) {
					ans = false; break;
				}
			}

			Console.WriteLine (ans);
		}

		public void solve_index_mark_2(){
			int[] arr = new int[]{ 4,2,1,0,3 };
			int n = arr.Length;

			for (int i = 0; i < n; ++i) {
				int val = arr [i] >= 0 ? arr [i] : arr [i] + n;

				if (val < n)
					arr [val] = arr [val] - n;		// mark value-index as negative.
			}

			bool ans = true;
			for (int i = 0; i < n; ++i) {
				if (arr [i] >= 0) {
					ans = false; break;
				}
			}

			Console.WriteLine (ans);
		}
	}
}

