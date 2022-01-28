using System;
using System.Collections.Generic;

// https://leetcode.com/problems/sum-of-subarray-ranges/
namespace _csharp
{
	public class _2104_sum_of_subarray_ranges
	{
		public long SubArrayRanges(int[] nums) {
			int n = nums.Length;

			long maxSum = getMaxSum(nums);
			long minSum = getMinSum(nums);
			return maxSum - minSum;
		}

		private long getMaxSum(int[] arr) {
			var stack = new Stack<int>();
			int n = arr.Length; int i=0; long sum=0;

			while (i < n) {
				if (stack.Count > 0 && arr [i] > arr [stack.Peek()]) {
					int idx = stack.Pop ();
					int num = arr [idx];
					long a = i - idx;
					long b = stack.Count > 0 ? idx - stack.Peek () : idx + 1;
					sum = sum + (num * a * b);
				} else {
					stack.Push (i);
					++i;
				}
			}

			while (stack.Count > 0) {
				int idx = stack.Pop ();
				int num = arr [idx];

				long a = n - idx;
				long b = stack.Count > 0 ? idx - stack.Peek () : idx + 1;
				sum = sum + (num * a * b);
			}

			return sum;
		}

		private long getMinSum(int[] arr) {
			var stack = new Stack<int>();
			int n = arr.Length; int i=0; long sum=0;

			while (i < n) {
				if (stack.Count > 0 && arr [i] < arr [stack.Peek()]) {
					int idx = stack.Pop ();
					int num = arr [idx];
					long a = i - idx;
					long b = stack.Count > 0 ? idx - stack.Peek () : idx + 1;
					sum = sum + (num * a * b);
				} else {
					stack.Push (i);
					++i;
				}
			}

			while (stack.Count > 0) {
				int idx = stack.Pop ();
				int num = arr [idx];

				long a = n - idx;
				long b = stack.Count > 0 ? idx - stack.Peek () : idx + 1;
				sum = sum + (num * a * b);
			}

			return sum;
		}
	}
}