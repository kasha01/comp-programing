using System;

// https://leetcode.com/problems/my-calendar-i/
namespace _csharp
{
	public class _729_my_calendar_i
	{
		class Node{
			public int start {get;set;}
			public int end {get;set;}
			public Node next;

			public Node(int s, int e){
				this.start=s; this.end=e;
			}
		}

		Node head;
		public _729_my_calendar_i() {
		}

		public bool Book(int start, int end) {
			// initial case
			if(head==null){
				head = new Node(start,end);
				return true;
			}

			// find node that comes after the new node [start,end]
			Node prev = null;
			var current = head;
			while(current != null && current.end <= start){
				prev = current;
				current = current.next;
			}

			// edge case if new interval is before head.
			if(current == head){
				if(current.start < end) return false;

				var new_head_node = new Node(start,end);
				new_head_node.next = current;
				head = new_head_node;
				return true;
			}

			// new interval end overlaps with current node.
			if(current != null && current.start < end)
				return false;

			// add interval
			var new_node = new Node(start,end);
			prev.next = new_node;
			new_node.next = current;

			return true;
		}
	}
}