using System;

// https://leetcode.com/problems/rotate-list/
namespace _csharp
{
	public class _61_rotate_list
	{
		public ListNode RotateRight(ListNode head, int k) {
			int n = 0;

			if(k==0)
				return head;

			ListNode _head = head;
			ListNode tail = null;

			while(_head != null){
				++n;
				tail = _head;
				_head = _head.next;
			}

			// empty linked list
			if(n==0)
				return head;

			int kk = k%n;

			// if rotation count is a multiple of list size - return head as is.
			if(kk==0)
				return head;

			ListNode _newHead = head;
			ListNode prev = null;
			int m = n-kk;   // part of list to be shifted to the end of list.
			while(m>0){
				--m;
				prev = _newHead;
				_newHead = _newHead.next;
			}

			prev.next = null;
			tail.next = head;

			return _newHead;
		}
	}
}

