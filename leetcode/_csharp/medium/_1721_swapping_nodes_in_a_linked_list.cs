using System;

// https://leetcode.com/problems/swapping-nodes-in-a-linked-list/
namespace _csharp
{
	public class _1721_swapping_nodes_in_a_linked_list
	{
		ListNode k1_node = null;
		ListNode k2_node = null;

		public ListNode SwapNodes(ListNode head, int k) {
			swap(head,k,1);

			// swap values
			int temp = k1_node.val;
			k1_node.val = k2_node.val;
			k2_node.val = temp;

			return head;
		}

		private int swap(ListNode head, int k, int c1){
			if(head==null)
				return 0;

			if(k==c1){
				k1_node = head;
			}

			int c2 = 1 + swap(head.next, k, c1+1);

			if(k==c2){
				k2_node = head;    
			}

			return c2;
		}
	}
}