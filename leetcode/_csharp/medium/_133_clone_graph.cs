using System;
using System.Collections.Generic;

namespace _csharp
{
	public class _133_clone_graph
	{
		public class Node {
			public int val;
			public IList<Node> neighbors;

			public Node() {
				val = 0;
				neighbors = new List<Node>();
			}

			public Node(int _val) {
				val = _val;
				neighbors = new List<Node>();
			}

			public Node(int _val, List<Node> _neighbors) {
				val = _val;
				neighbors = _neighbors;
			}
		}

		public Node CloneGraph(Node node) {
			if(node == null)
				return null;

			HashSet<int> visited = new HashSet<int>();
			Queue<Node> originalQ = new Queue<Node>();
			var map = new Dictionary<int,Node>();

			Node copyStartNode = new Node(node.val);
			map.Add(node.val, copyStartNode);

			originalQ.Enqueue(node);
			visited.Add(node.val);

			while(originalQ.Count > 0){
				for(int k=0;k<originalQ.Count;++k){
					var sourceNode = originalQ.Dequeue();    

					foreach(Node adj in sourceNode.neighbors){
						if(visited.Contains(adj.val))
							continue;

						var copy_source_node = map[sourceNode.val];
						Node copy_adj_node;
						if(!map.ContainsKey(adj.val))
							map.Add(adj.val, new Node(adj.val));

						copy_adj_node = map[adj.val];

						copy_source_node.neighbors.Add(copy_adj_node);
						copy_adj_node.neighbors.Add(copy_source_node);

						originalQ.Enqueue(adj);
					}

					// I am done with this sourceNode. mark it as visited (modified bfs).
					visited.Add(sourceNode.val);
				}
			}

			return copyStartNode;   
		}
	}
}