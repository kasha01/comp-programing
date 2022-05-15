using System;

// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
namespace _csharp
{
	public class __19_remove_nth_node_from_end_of_list
	{
		public ListNode RemoveNthFromEnd(ListNode head, int n) {
			var temp = head;

			int c = 0;
			while(temp != null){
				temp = temp.next;
				c++;
			}

			int i=0; int target = c-n;
			ListNode prev = null; temp = head;

			while(i<=target){
				if(target == i){
					if(prev == null){
						// I am removing head
						head = head.next;
					}
					else{
						prev.next = temp.next;
					}
					break;
				}

				prev = temp;
				temp = temp.next;
				++i;
			}

			return head;
		}


		// recursive
		int target;
		ListNode newHead;
		public ListNode RemoveNthFromEnd_RC(ListNode head, int n) {
			target = n;
			newHead = head;
			remove(null, head);
			return newHead;
		}


		private int remove(ListNode prev, ListNode node){
			if(node==null){
				return 1;
			}

			int endNodeNum = remove(node, node.next);

			if(endNodeNum==target){
				if(prev != null){
					prev.next = node.next;                
				}
				else{
					// i am removing the head
					newHead = node.next;
				}
			}

			return endNodeNum+1;
		}
	}
}

