using System;

// https://leetcode.com/problems/add-two-numbers/
namespace _csharp
{
	public class _2_add_two_numbers
	{
		public class ListNode {
			public int val;
			public ListNode next;
			public ListNode(int val=0, ListNode next=null) {
				this.val = val;
				this.next = next;
			}
		}

		public void driver() {
			ListNode n1 = new ListNode (2);
			ListNode n2 = new ListNode (4);
			ListNode n3 = new ListNode (3);
			n1.next = n2;
			n2.next = n3;

			ListNode n11 = new ListNode (5);
			ListNode n22 = new ListNode (6);
			ListNode n33 = new ListNode (4);
			n11.next = n22;
			n22.next = n33;

			AddTwoNumbers (n1, n11);
		}

		public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
			int c = 0;
			ListNode head = null;
			ListNode l3 = null;

			while (l1 != null || l2 != null) {
				int a = 0; int b = 0; int r = 0;

				if (l1 != null) {
					a = l1.val;
					l1 = l1.next;
				}

				if (l2 != null) {
					b = l2.val;
					l2 = l2.next;
				}

				r = a + b + c;
				if (r > 9) {
					c = r / 10;
					r = r % 10;
				} else {
					c = 0;
				}

				if (head == null) {
					head = new ListNode (r);
					l3 = head;
				} else {
					l3.next = new ListNode (r);
					l3 = l3.next;
				}
			}

			if (c > 0) {
				l3.next = new ListNode (c);
			}

			return head;
		}
	}
}