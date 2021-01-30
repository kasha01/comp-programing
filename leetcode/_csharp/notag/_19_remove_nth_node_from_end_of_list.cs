using System;
using System.Collections.Generic;

// https://leetcode.com/problems/remove-nth-node-from-end-of-list/solution/
namespace _csharp
{
	public class _19_remove_nth_node_from_end_of_list
	{
		// my solution
		int target;
		private ListNode RemoveNthFromEnd(ListNode head, int n) {
			target = n;
			int c = 0;
			return remove(null, head, ref c);
		}
		private ListNode remove(ListNode prev, ListNode node, ref int c){
			if(node==null){
				++c;
				return null;
			}

			remove(node, node.next, ref c);

			if(c==target){
				if(prev != null){
					prev.next = node.next;                
				}
				else{
					// i am removing the head
					var newHead = node.next;
					node = null;
					return newHead;
				}
				node = null;
			}
			++c;

			return node;
		}


		// leetcode solution - much cleaner
		/*
		 * The idea is to maintain a gap of n+1 between the first and second pointer
		 * when first pointer is at end of list (null), the second pointer would be one node behind
		 * the designated target.
		 * because if first pointer at null/tail is on n=0; then n=1 would be the last node, 
		 * second pointer would be at n+1 distance from the last node which is exactly the node
		 * before the target n.
		*/
		private ListNode removeNthFromEnd(ListNode head, int n) {
			ListNode dummy = new ListNode(0);
			dummy.next = head;
			int length  = 0;
			ListNode first = head;
			while (first != null) {
				length++;
				first = first.next;
			}
			length -= n;
			first = dummy;
			while (length > 0) {
				length--;
				first = first.next;
			}
			first.next = first.next.next;
			return dummy.next;
		}
	}
}

