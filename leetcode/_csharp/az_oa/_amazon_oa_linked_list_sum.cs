using System;

// https://leetcode.com/discuss/interview-question/1546673/Amazon-or-OA-or-LinkedListSum
namespace _csharp
{
	public class _amazon_oa_linked_list_sum
	{
		public void run(){

			ListNode node1 = new ListNode (1);
			ListNode node2 = new ListNode (2);
			ListNode node3 = new ListNode (3);
			ListNode node4 = new ListNode (4);
			ListNode node5 = new ListNode (5);
			ListNode node6 = new ListNode (6);
			ListNode node7 = new ListNode (7);
			ListNode node8 = new ListNode (8);

			node1.next = node2;
			node2.next = node3;
			node3.next = node4;
			node4.next = node5;
			node5.next = node6;
			node6.next = node7;
			node7.next = node8;

			reverseBetween (node1);
		}

		private void reverseBetween(ListNode head) {
			if (head?.next == null) {
				Console.WriteLine (0);
				return;
			}

			// find mid node
			int n = 0;
			ListNode temp_head = head;
			while (temp_head != null) {
				++n;
				temp_head = temp_head.next;
			}

			int m = n/2;

			temp_head = head;
			while(m>0){
				temp_head = temp_head.next;
				--m;
			}

			if (n % 2 != 0) {
				temp_head = temp_head.next;
			}

			// reverse second half of the linked list, after middle point.
			var head_2 = reverseIterative (temp_head);

			// calculate sums
			while (head != null && head_2 != null) {
				int sum = head.val + head_2.val;
				Console.WriteLine (sum);
				head = head.next; head_2 = head_2.next;
			}
		}

		private ListNode reverseIterative(ListNode head){
			if (head.next == null)
				return head;

			ListNode cur = head;
			ListNode prev = null;
			ListNode third = head.next;

			while (cur != null) {
				third = cur.next;
				cur.next = prev;
				prev = cur;
				cur = third;
			}

			return prev;
		}
	}
}