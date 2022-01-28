using System;

// https://leetcode.com/problems/reverse-linked-list/
namespace _csharp
{
	public class _206_reverse_linked_list
	{
		ListNode newHead = null;
		public ListNode ReverseList(ListNode head) {
			rc(head, null);
			return newHead;
		}

		private void rc(ListNode head, ListNode prev){
			if(head == null){
				return;
			}

			if(head.next == null){
				newHead = head;
			}

			rc(head.next, head);

			head.next = prev;        
		}
	}
}