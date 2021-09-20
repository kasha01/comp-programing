using System;
using System.Collections.Generic;

// https://leetcode.com/problems/course-schedule/
namespace _csharp
{
	public class _207_course_schedule
	{
		/* We simply try to detect a cycle in the prerequisites graph. if a cycle is detected, that means I cannot finish the courses */
		// We attempt to detect a cycle using Recursive DFS. if a node is already in being processed in the recursive hashset, that means a cycle exists.

		HashSet<int> recSet;
		bool[] visited;
		Dictionary<int,List<int>> children;
	
		public bool CanFinish(int numCourses, int[][] prerequisites) {
			children = new Dictionary<int,List<int>>();
			HashSet<int> sources = new HashSet<int>();

			for(int i=0;i<prerequisites.Length;++i){
				int src = prerequisites[i][1];
				int dest = prerequisites[i][0];
				sources.Add(src);

				if(!children.ContainsKey(src))
					children.Add(src, new List<int>());

				children[src].Add(dest);
			}

			recSet = new HashSet<int>();
			visited = new bool[numCourses];

			foreach(int i in sources){
				if(hasCycle(i)) return false;
			}

			return true;
		}

		private bool hasCycle(int node){
			if(recSet.Contains(node))
				return true;

			if(visited[node])
				return false;

			if(!children.ContainsKey(node))
				return false;

			// node is being recursivelly processed.
			recSet.Add(node);

			visited[node] = true;
			var adj = children[node]; 

			foreach(int child in adj){
				if(hasCycle(child))
					return true;            
			}

			// done with the recursive processing of the node
			recSet.Remove(node);

			return false;
		}
	}
}