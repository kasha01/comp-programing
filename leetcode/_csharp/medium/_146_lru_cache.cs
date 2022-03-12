using System;
using System.Collections.Generic;

// https://leetcode.com/problems/lru-cache/
namespace _csharp
{
	// LRU Cache
	public class _146_lru_cache
	{
		class Node{
			public int key;
			public int val;
			public Node next;
			public Node prev;
		}

		int capacity;
		Node head;
		Node tail;
		Dictionary<int,Node> map;
		public _146_lru_cache(int capacity) {
			head = new Node();
			tail = new Node(); // this will always be an empty node. with tail.prev pointing to last node.
			tail.prev = head;
			head.next = tail;

			this.capacity = capacity;
			map = new Dictionary<int,Node>();
		}

		public int Get(int key) {
			if(!map.ContainsKey(key))
				return -1;

			var node = map[key];
			if(map.Count == 1){
				// this is the only node
				return node.val;
			}

			Remove(node);
			AddNodeToFront(node);

			return node.val;
		}

		public void Put(int key, int value) {
			if(map.Count == 0){
				// init
				head.val = value;
				head.key = key;
				map.Add(key,head);
				return;
			}

			if(!map.ContainsKey(key)){
				// new node 
				var new_node = new Node();
				new_node.key = key;
				new_node.val = value;
				map.Add(key,new_node);
				AddNodeToFront(new_node);

				if(map.Count > capacity){
					// remove tail
					map.Remove(tail.prev.key);
					Remove(tail.prev,true);
				}
			}
			else{
				var node = map[key];
				node.val = value;
				Remove(node);
				AddNodeToFront(node);
			}
		}

		// remove permanently. set node to null
		private void Remove(Node node, bool perm=false){
			if(node == head){
				var nx = node.next;
				node.next = null;
				node.prev = null;
				head = nx;

				if(perm) node = null;

				return;
			}

			node.prev.next = node.next;
			node.next.prev = node.prev;
			if(perm) node = null;
		}

		private void AddNodeToFront(Node node){
			node.next = head;
			head.prev = node;
			node.prev = null;
			head = node;
		}

	}
}