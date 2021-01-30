using System;
using System.Collections.Generic;

// https://leetcode.com/problems/swap-nodes-in-pairs/
namespace _csharp
{
	public class _24_swap_nodes_in_pairs
	{
		public ListNode SwapPairs(ListNode head) {
			ListNode node = head;
			ListNode newHead = null;
			ListNode prev = null;

			while(node!=null && node.next != null){
				ListNode next = node.next;

				node.next = next.next;
				next.next = node;

				if(newHead == null){
					newHead = next;
				}
				else{
					prev.next = next;
				}

				prev = node;
				node = node.next;

			}

			return newHead != null ? newHead : head;
		}
	}
}

