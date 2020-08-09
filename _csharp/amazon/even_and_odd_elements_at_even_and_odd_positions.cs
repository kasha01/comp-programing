using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/even-and-odd-elements-at-even-and-odd-positions/0
namespace GeeksForGeeks_csharp
{
	public class even_and_odd_elements_at_even_and_odd_positions
	{

		public static void test ()
		{
			int[] arr = { 1 };
			solve (arr, 1);
		}

		static void solve(int[] arr, int n){
			Queue<int> even = new Queue<int> ();
			Queue<int> odd = new Queue<int> ();

			for (int i = 0; i < n; ++i) {
				if (arr [i] % 2 == 0) {
					even.Enqueue (arr [i]);
				} else {
					odd.Enqueue (arr [i]);
				}
			}

			bool evenFlag = true;
			int x = 0;
			for(int i=0;i<n;++i){
				if (evenFlag) {
					if (even.Count > 0) {
						x = even.Dequeue ();
						evenFlag = !evenFlag;
					} else {
						x = odd.Dequeue ();
					}						
				} else if(!evenFlag) {
					if (odd.Count > 0) {
						x = odd.Dequeue ();
						evenFlag = !evenFlag;
					} else {
						x = even.Dequeue ();
					}						
				}
				Console.Write (x + " ");
			}
		}
	}
}

