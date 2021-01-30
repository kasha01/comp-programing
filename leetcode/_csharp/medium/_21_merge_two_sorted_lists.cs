using System;

// https://leetcode.com/problems/merge-two-sorted-lists/
namespace _csharp
{
	public class _21_merge_two_sorted_lists
	{
		public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
			ListNode head = null;
			ListNode newListHead = null;

			if(l1==null && l2==null)
				return null;

			if(l1!=null && l2!=null){
				if(l1.val <= l2.val){
					newListHead = new ListNode(l1.val);
					l1 = l1.next;
				}
				else{
					newListHead = new ListNode(l2.val);
					l2=l2.next;
				}
			}
			else if(l1!=null){
				newListHead = new ListNode(l1.val);
				l1 = l1.next;
			}
			else if(l2!=null){
				newListHead = new ListNode(l2.val);
				l2=l2.next;
			}

			head = newListHead;
			while(l1!=null && l2!=null){
				if(l1.val <= l2.val){
					head.next = new ListNode(l1.val);
					l1 = l1.next;
				}
				else{
					head.next = new ListNode(l2.val);
					l2=l2.next;
				}
				head = head.next;
			}

			while(l1!=null){
				head.next = new ListNode(l1.val);
				l1 = l1.next;
				head = head.next;
			}

			while(l2!=null){
				head.next = new ListNode(l2.val);
				l2 = l2.next;
				head = head.next;
			}

			return newListHead;
		}
	}
}

