using System;

// https://leetcode.com/problems/reverse-linked-list-ii/
namespace _csharp
{
	public class _92_reverse_linked_list_ii
	{
		public ListNode ReverseBetween(ListNode head, int left, int right) {
			ListNode prev = null;
			ListNode next = null;
			ListNode left_end = null;   // the node just before the node where reversion starts
			ListNode current = head;
			right = right - left;

			while(left>1 && current != null){
				left_end = current;
				current = current.next;
				--left;
			}

			ListNode orig_current = current;
			while(current!=null && right>=0){
				next = current.next;
				current.next = prev;
				prev = current;
				current = next;
				--right;
			}

			if(left_end == null){
				head = prev;
			}
			else{
				left_end.next = prev;
			}

			orig_current.next = current;

			return head;
		}
	}
}

