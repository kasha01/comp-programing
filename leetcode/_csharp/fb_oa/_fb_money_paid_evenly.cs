using System;

// https://leetcode.com/discuss/interview-question/1643907/Google-Interview-Question
// tags: money pay employee greedy
namespace _csharp
{
	public class _fb_money_paid_evenly
	{
		public void solve(){
			var arr = new int[] { 10, 20, 30, 40 };
			int n = arr.Length;
			int money = 90;

			var employees = new Node[n];
			for (int i = 0; i < n; ++i) {
				employees [i] = new Node (i, arr [i]);
			}

			Array.Sort (employees, (a, b) => SortByValue (a, b));

			int remainingEmployee = n;
			var ans = new int[n];
			for (int i = 0; i < n; ++i) {
				Node emp = employees [i];
				int maxPay = money / remainingEmployee;

				int howMuchToPay = Math.Min (maxPay, emp.val);

				ans [emp.index] = howMuchToPay;
				money = money - howMuchToPay;
				--remainingEmployee;
			}

			for (int i = 0; i < n; ++i) {
				Console.Write (ans [i] + " ");
			}
			Console.WriteLine ();
		}

		private static int SortByValue(Node a, Node b){
			if (a.val < b.val)
				return -1;

			if (a.val > b.val)
				return 1;

			return 0;
		}

		private class Node{
			public int index { get; set; } 
			public int val { get; set; }

			public Node(int i, int v){
				index = i;
				val = v;
			}
		}
	}
}