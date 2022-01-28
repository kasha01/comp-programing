using System;
using System.Collections.Generic;
using System.Collections;

// https://leetcode.com/discuss/interview-question/1475135/Amazon-OA
namespace _csharp
{
	public class _find_sum_of_difference_of_all_maximum_and_minimum_of_every_subarry
	{
		public void solve(){
			int[] arr = {1,2,3,4};
			int maxSum = getMaxSum(arr);
			int minSum = getMinSum(arr);

			Console.WriteLine((maxSum - minSum)%1000000007);
		}

		private int getMaxSum(int[] arr) {
			var stack = new Stack<int>();
			int n = arr.Length; int i=0; int sum=0;

			while (i < n) {
				if (stack.Count > 0 && arr [i] > arr [stack.Peek()]) {
					int idx = stack.Pop ();
					int num = arr [idx];
					int a = i - idx;
					int b = stack.Count > 0 ? idx - stack.Peek () : idx + 1;
					sum = sum + (num * a * b);
				} else {
					stack.Push (i);
					++i;
				}
			}

			while (stack.Count > 0) {
				int idx = stack.Pop ();
				int num = arr [idx];

				int a = n - idx;
				int b = stack.Count > 0 ? idx - stack.Peek () : idx + 1;
				sum = sum + (num * a * b);
			}

			return sum;
		}

		private int getMinSum(int[] arr) {
			var stack = new Stack<int>();
			int n = arr.Length; int i=0; int sum=0;

			while (i < n) {
				if (stack.Count > 0 && arr [i] < arr [stack.Peek()]) {
					int idx = stack.Pop ();
					int num = arr [idx];
					int a = i - idx;
					int b = stack.Count > 0 ? idx - stack.Peek () : idx + 1;
					sum = sum + (num * a * b);
				} else {
					stack.Push (i);
					++i;
				}
			}

			while (stack.Count > 0) {
				int idx = stack.Pop ();
				int num = arr [idx];

				int a = n - idx;
				int b = stack.Count > 0 ? idx - stack.Peek () : idx + 1;
				sum = sum + (num * a * b);
			}

			return sum;
		}
	}
}