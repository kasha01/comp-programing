using System;

// https://leetcode.com/problems/palindrome-linked-list/
namespace _csharp
{
	public class _234_palindrome_linked_list
	{
		public bool IsPalindrome(ListNode head) {
			origHead = head;
			return IsPali(head);
		}

		ListNode origHead;
		private bool IsPali(ListNode node){
			if(node == null)
				return true;

			bool b =  IsPali(node.next);
			if(!b || node.val != origHead.val)
				return false;            

			origHead = origHead.next;
			return true;
		}
	}
}

