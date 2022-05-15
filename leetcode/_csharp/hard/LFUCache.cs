using System;
using System.Collections.Generic;

// NOT COMPLETE
// courtesy of: https://leetcode.com/problems/lfu-cache/discuss/94547/Java-O(1)-Solution-Using-Two-HashMap-and-One-DoubleLinkedList
// https://leetcode.com/problems/lfu-cache/
// tags: lfu cache lru
namespace _csharp
{
	public class LFUCache
	{
		private int capacity=0; static int currentSize=0; int minUseCounter=0;
		private Dictionary<int,Node> nodeMap = new Dictionary<int,Node>();
		private Dictionary<int,LruList> useCounterMap = new Dictionary<int,LruList>();

		class Node{
			public int key {get;set;}
			public int val {get;set;}
			public int useCounter {get;set;}
			public Node next {get;set;}
			public Node prev {get;set;}

			public Node(){}
			public Node(int k, int v){
				key = k;
				val = v;
				useCounter = 1;
			}
		}

		class LruList{
			public int size { get; set; }
			Node head {get;set;}
			Node tail {get;set;}

			public LruList(){
				head = new Node();
				tail = new Node();

				head.next = tail;
				tail.prev = head;
			}

			public void Add(Node node){
				head.next.prev = node;
				node.next = head.next;
				head.next = node;
				node.prev = head;
				++size;
			}

			public void Remove(Node node){
				node.prev.next = node.next;
				node.next.prev = node.prev;
				--size;
			}

			public Node RemoveLast(){
				var lastNode = tail.prev;
				Remove (lastNode);
				return lastNode;
			}
		}

		public LFUCache(int capacity) {
			this.capacity = capacity;
		}

		public int Get(int key) {
			if(!nodeMap.ContainsKey(key)) return -1;

			var node = nodeMap[key];
			Update(node);        
			return node.val;
		}

		public void Put(int key, int value) {
			if (capacity == 0)
				return;
			
			if(nodeMap.ContainsKey(key)){
				var node = nodeMap[key];
				node.val = value;
				Update(node);
				return;
			}    

			var newNode = new Node(key,value);
			nodeMap.Add(key,newNode);

			if(capacity == currentSize){
				// remove LFU
				var lruList = useCounterMap[minUseCounter];
				var removedNode = lruList.RemoveLast(); // remove the least used node
				nodeMap.Remove(removedNode.key);
				--currentSize;
			}

			++currentSize;
			minUseCounter = 1;
			int nodeUseCount = newNode.useCounter;
			if(!useCounterMap.ContainsKey(nodeUseCount))
				useCounterMap.Add(nodeUseCount, new LruList());

			var list = useCounterMap[nodeUseCount];
			list.Add(newNode);

			++currentSize;
		}

		private void Update(Node node){
			// remove from old list
			var oldLruList = useCounterMap[node.useCounter];
			oldLruList.Remove(node);

			if(minUseCounter == node.useCounter && oldLruList.size == 0){
				// if this node has the min use count, and it is the only node in the lru list, this means there is no other node that has a use count
				// equals to minUseCounter, so increment minUseCounter
				++minUseCounter;
			}

			// get new list if exists
			int newUseCounter = node.useCounter+1;
			node.useCounter = newUseCounter;
			if(!useCounterMap.ContainsKey(newUseCounter)){
				useCounterMap.Add(newUseCounter, new LruList());
			}

			// add to new list
			var newLruList = useCounterMap[newUseCounter];
			newLruList.Add(node);
		}
	}

}

