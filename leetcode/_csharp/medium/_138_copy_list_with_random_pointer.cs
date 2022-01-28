using System;
using System.Collections.Generic;

// https://leetcode.com/problems/copy-list-with-random-pointer/
namespace _csharp
{
	public class _138_copy_list_with_random_pointer
	{
		public class Node {
			public int val;
			public Node next;
			public Node random;

			public Node(int _val) {
				val = _val;
				next = null;
				random = null;
			}
		}

		public Node CopyRandomList(Node head) {
			if(head == null) return null;

			Dictionary<Node,Node> map = new Dictionary<Node,Node>();

			var _head = head;
			while(head!=null){
				var node = new Node(head.val);
				map.Add(head,node);
				head = head.next;
			}

			foreach(var kvp in map){
				var orig_head = kvp.Key;
				var copy_node = kvp.Value;

				if(orig_head.next != null)
					copy_node.next = map[orig_head.next];

				if(orig_head.random != null)
					copy_node.random = map[orig_head.random];
			}

			return map[_head];
		}
	}
}