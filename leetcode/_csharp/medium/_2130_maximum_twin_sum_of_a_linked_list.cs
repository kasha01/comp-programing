using System;

// https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list/
namespace _csharp
{
	public class _2130_maximum_twin_sum_of_a_linked_list
	{
		public int PairSum(ListNode head) {

			// slow fast haire turtle to find mid node
			ListNode slow = head;
			ListNode fast = head;
			ListNode prev = head;
			while(fast!=null){
				prev = slow;
				fast = fast.next.next;
				slow = slow.next;
			}

			prev.next = null;
			ListNode current = slow;
			ListNode next = slow.next;
			while(current!=null){
				next = current.next;
				current.next = prev;
				prev = current;
				current = next;
			}

			current = prev;
			int maxSum = 0;
			while(head!=null){
				int sum = head.val + current.val;
				maxSum = Math.Max(maxSum, sum);
				head = head.next; current = current.next;
			}

			return maxSum;
		}
	}
}