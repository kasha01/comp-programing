using System;
using System.Collections.Generic;

// https://leetcode.com/problems/sum-of-subarray-minimums/
namespace _csharp
{
	public class _907_sum_of_subarray_minimums
	{
		public int SumSubarrayMins(int[] arr) {
			int m = 1000000007;
			Stack<int> stack = new Stack<int>();
			int n = arr.Length;
			int i=0;
			long sum = 0;

			while(i<n){
				int x = arr[i];

				if(stack.Count == 0 || arr[stack.Peek()] < x){
					stack.Push(i);
					++i;
				}
				else{
					int min_index = stack.Pop();
					int l = stack.Count == 0 ? min_index+1 : min_index - stack.Peek();
					int r = i - min_index;
					sum = (sum + (long)arr[min_index] * l * r)%m;
				}
			}

			while(stack.Count>0){
				int min_index = stack.Pop();
				int l = stack.Count == 0 ? min_index+1 : min_index - stack.Peek();
				int r = n - min_index;
				sum = (sum + (long)arr[min_index] * l * r)%m;
			}

			return (int)(sum%m);
		}
	}
}