using System;
using System.Collections.Generic;
using System.Collections;

// https://leetcode.com/problems/course-schedule-ii/
namespace _csharp
{
	public class _210_course_schedule_II
	{
		public int[] FindOrder(int numCourses, int[][] prerequisites) {
			int[] indegree = new int[numCourses];
			Dictionary<int, List<int>> map = new Dictionary<int,List<int>>();

			for(int i=0; i<prerequisites.Length; ++i){
				int src = prerequisites[i][1];
				int dest = prerequisites[i][0];

				if(!map.ContainsKey(src))
					map.Add(src,new List<int>());                

				map[src].Add(dest);
				indegree[dest]++;
			}       

			Queue<int> qu = new Queue<int>();
			for(int i=0;i<numCourses;++i){
				if(indegree[i]==0)
					qu.Enqueue(i);                
			}

			int k = 0; int[] result = new int[numCourses];
			while(qu.Count > 0){
				var node = qu.Dequeue();
				result[k] = node; ++k;

				if(!map.ContainsKey(node))
					continue;

				var list = map[node];
				foreach(var course in list){
					indegree[course]--;
					if(indegree[course]==0)
						qu.Enqueue(course);
				}
			}

			if(k==numCourses)
				return result;

			return new int[0];
		}
	}
}