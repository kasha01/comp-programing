using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question/1678850/Amazon-or-QA
namespace _csharp
{
	public class _amazon_oa_score_01_10_10_01_2022
	{
		public void solve(){
			int coin_01 = 3;
			int coin_10 = 2;
			string s = "10100101";
			int n = s.Length;

			int ans = 0;
			if (coin_01 >= coin_10) {
				ans = solveForO1 (coin_01, coin_10, s, n);
			} else {
				ans = solveFor10 (coin_01, coin_10, s, n);
			}

			Console.WriteLine (ans);
		}

		private int solveForO1(int c01, int c10, string s, int n){
			// c01 has more profit. I should solve to get as much c01 (01 combination) as I can

			int sum = 0;
			var stack = new Stack<int> ();
			int i = 0;
			while (i < n) {
				int x = s [i] - '0';
				if (stack.Count > 0 && stack.Peek () == 0 && x == 1) {
					stack.Pop ();
					sum = sum + c01;
				} else {
					stack.Push (x);
				}

				++i;
			}

			// the leftovers are combinations that couldn't form (01), so they must be (10)
			int one_count = 0; int zero_count=0;
			while (stack.Count > 0) {
				int x = stack.Pop ();
				one_count = one_count + (x == 1 ? 1 : 0);
				zero_count = zero_count + (x == 0 ? 1 : 0);
			}

			sum = sum + (Math.Min (one_count, zero_count) * c10);

			return sum;
		}

		private int solveFor10(int c01, int c10, string s, int n){
			// c10 has more profit. I should solve to get as much c10 (10 combination) as I can

			int sum = 0;
			var stack = new Stack<int> ();
			int i = 0;
			while (i < n) {
				int x = s [i] - '0';
				if (stack.Count > 0 && stack.Peek () == 1 && x == 0) {
					stack.Pop ();
					sum = sum + c10;
				} else {
					stack.Push (x);
				}

				++i;
			}

			// the leftovers are combinations that couldn't form (10), so they must be (01)
			int one_count = 0; int zero_count=0;
			while (stack.Count > 0) {
				int x = stack.Pop ();
				one_count = one_count + (x == 1 ? 1 : 0);
				zero_count = zero_count + (x == 0 ? 1 : 0);
			}

			sum = sum + (Math.Min (one_count, zero_count) * c01);

			return sum;
		}
	}
}