using System;

// https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/
namespace _csharp
{
	public class _82_remove_duplicates_from_sorted_list_II
	{
		public ListNode DeleteDuplicates(ListNode head) {

			ListNode _head = null;
			ListNode prev = null;
			while(head!=null){
				if(head.next!=null && head.val==head.next.val){
					while(head.next!=null && head.val==head.next.val){
						head = head.next;
					}

					if(prev != null){
						prev.next = head?.next;   
					}
				}
				else{
					prev = head;
				}

				if(_head==null){
					_head = prev;
				}

				head = head?.next;
			}

			return _head;
		}
	}
}

