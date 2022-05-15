using System;

// https://leetcode.com/discuss/interview-question/1516876/Amazon-SDE-Online-Assestment
namespace _csharp
{
	public class _amazon_sde_online_assestment
	{
		/*
		 * Imagine a list of messages stored in a single linked list, one user read the first message and last first each day,
			being those the first node and last node and remove them from the list, the sum of the values of those nodes mean the
			total number of effort to complete the task in those emails.
		*/
		static ListNode head; static int sum = 0;
		public static void qn1(ListNode node){
			if (node == null)
				return;

			qn1 (node.next);
			if (node == head)
				sum = Math.Max (sum, node.val);
			else
				sum = Math.Max (sum, head.val + node.val);

			head = head.next;
		}

		/*
 		* Given an array with only 0's and 1's, write a function which calculate the minum numbers of swap to sort the array with all 
 		* the zeros at the left and numbers one to the right and.
		*/
		public static void qn2(int[] arr){
			int n = arr.Length;
			int j = n - 1; int i = n - 1;
			int swaps = 0;
			while (j >= 0) {
				if (arr [j] == 1) {
					swaps = swaps + (i - j);
					--i;
				}

				--j;
			}

			Console.WriteLine (swaps);
		}

		/*
 		* Given an array with only 0's and 1's, write a function which calculate the minum numbers of swap to group all 1s and 0s together.
 		* They can be on either side
		*/
		public static void qn3(int[] arr){
			int n = arr.Length;
			int j = n - 1; int one_ptr = n - 1; int zero_ptr = n - 1;
			int swaps_one_right = 0; int swaps_zero_right = 0;
			while (j >= 0) {
				if (arr [j] == 1) {
					swaps_one_right = swaps_one_right + (one_ptr - j);
					--one_ptr;
				} else {
					swaps_zero_right = swaps_zero_right + (zero_ptr - j);
					--zero_ptr;
				}

				--j;
			}

			Console.WriteLine (Math.Min (swaps_zero_right, swaps_one_right));
		}
	}
}