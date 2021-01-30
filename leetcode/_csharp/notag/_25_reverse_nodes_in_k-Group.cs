using System;
using System.Collections.Generic;

// https://leetcode.com/problems/reverse-nodes-in-k-group/
namespace _csharp
{
	public class _25_reverse_nodes_in_k_Group
	{
		ListNode revOldPrev = null;
		ListNode revNewNext = null;
		ListNode revStart = null;
		ListNode revEnd = null;
		ListNode revNewHead = null;
		public ListNode ReverseKGroup(ListNode head, int k) {
			if(k <= 1){
				return head;
			}

			while(head != null){
				revStart = head;
				revEnd = head;
				int kk = k;
				while(kk > 0 && head != null){
					--kk;
					revEnd = head;
					head = head.next;
				}
				revNewNext = head;

				if(kk==0){
					ListNode revNode = revStart;
					ListNode revNext = revStart.next;
					ListNode temp;
					for(int i=1;i<k;++i){
						temp = revNext.next;
						revNext.next = revNode;
						revNode = revNext;
						revNext = temp;
					}
					if(revNewHead == null){
						revNewHead = revEnd;    
					}

					revStart.next = revNewNext;
					if(revOldPrev != null){
						revOldPrev.next = revEnd;
					}
					revOldPrev = revStart;
				}
			}

			return revNewHead;
		}
	}
}

