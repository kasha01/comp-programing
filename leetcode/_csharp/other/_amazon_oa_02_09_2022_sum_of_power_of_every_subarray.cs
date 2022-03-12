using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question/1754686/Amazon-or-OA
namespace _csharp
{
	public class _amazon_oa_02_09_2022_sum_of_power_of_every_subarray
	{
		public void solve(){
			var arr = new int[]{ 2, 3, 2, 1 };
			int n = arr.Length;

			var stack = new Stack<int>();
			int[] presum = new int[n+1];

			presum [0] = 0;
			for(int k=1;k<=n;++k){
				presum [k] = presum [k - 1] + arr [k - 1];
			}

			int t=0; int sum = 0;
			while(t<n){
				if (stack.Count == 0 || arr [stack.Peek ()] <= arr [t]) {
					stack.Push (t);
					++t;
				} else {
					int x = stack.Pop ();
					int i = t-1;
					int j = stack.Count > 0 ? stack.Peek () : -1;

					int s = presum [i+1] - presum [j+1];
					sum = sum + (s * arr [x]);
				}
			}

			while (stack.Count > 0) {
				int x = stack.Pop ();
				int i = n-1;
				int j = stack.Count > 0 ? stack.Peek () : -1;

				int s = presum [i+1] - presum [j+1];
				sum = sum + (s * arr [x]);
			}

			Console.WriteLine (sum);
		}
	}
}