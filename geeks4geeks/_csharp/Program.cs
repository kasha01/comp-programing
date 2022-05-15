using System;
using System.Collections.Generic;

namespace GeeksForGeeks_csharp
{
	class MainClass
	{
		class Node{
			public int val;
			public Node left;
			public Node right;
			public Node(int v){
				this.val = v;
			}
		}

		public static void Main (string[] args)
		{
			var node1 = new Node (10);
			var node2 = new Node (12);
			var node3 = new Node (15);
			var node4 = new Node (25);
			var node5 = new Node (30);
			var node6 = new Node (36);

			node1.left = node2;
			node1.right = node3;
			node2.left = node4;
			node2.right = node5;
			node3.left = node6;

			dfs (node1);

			Console.WriteLine (head.val);
		}

		static Node head;
		private static Node dfs(Node node){
			if (node == null)
				return null;

			if (node.left == null && node.right == null)
				return node;

			Node prev = null;
			if (node.left != null) {
				prev = dfs (node.left);
				if (head == null) {
					head = prev;
				}

				node.left = prev;
				prev.right = node;
			}

			if (node.right != null) {
				prev = dfs (node.right);
				if (head == null) {
					head = node;
				}
				node.right = prev;
				prev.left = node;
			}

			return prev;
		}
	}
}