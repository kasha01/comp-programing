using System;

// https://leetcode.com/problems/merge-in-between-linked-lists/
namespace _csharp
{
	public class _1669_merge_in_between_linked_lists
	{
		public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2) {
			ListNode prev=list1; ListNode nodeA=null; ListNode nodeB=null; ListNode list2End=null;
			ListNode list1_head=list1;
			ListNode list2_head=list2;

			int c = 0;
			while(list1 != null){
				if (c==a)
				{
					nodeA=prev;
				}
				if(c==b){
					nodeB=list1.next;
					break;
				}
				prev=list1;
				list1 = list1.next;
				++c;
			}

			while(list2!=null){
				list2End=list2;
				list2=list2.next;
			}

			nodeA.next = list2_head;
			list2End.next = nodeB;

			return list1_head;
		}			
	}
}

