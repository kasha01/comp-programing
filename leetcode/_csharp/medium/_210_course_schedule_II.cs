using System;
using System.Collections.Generic;

// https://leetcode.com/problems/course-schedule-ii/
namespace _csharp
{
	public class _210_course_schedule_II
	{
		public int[] FindOrder(int numCourses, int[][] prerequisites) {
			int[] indegree = new int[numCourses];
			Dictionary<int, List<int>> map = new Dictionary<int,List<int>>();

			for(int i=0; i<prerequisites.Length; ++i){
				int dependencyCourse = prerequisites[i][1];
				int course = prerequisites[i][0];

				if(!map.ContainsKey(course)){
					map.Add(course, new List<int>());
				}

				map[course].Add(dependencyCourse);
				indegree[dependencyCourse]++;
			}

			Queue<int> qu = new Queue<int>();
			for(int i=0; i<numCourses; ++i){
				// add all courses that have 0 indegree (leaf courses) with no dependency on them
				if(indegree[i]==0)
					qu.Enqueue(i);
			}

			int n = numCourses;
			int[] result = new int[numCourses];
			while(qu.Count > 0){
				int node = qu.Dequeue();
				result[n-1] = node;
				--n;

				// there are no courses that depend on course (node). so skip it.
				if(!map.ContainsKey(node))
					continue;

				var dependencyCourses = map[node];
				foreach(int x in dependencyCourses){
					indegree[x]--;
					if(indegree[x] == 0){
						// course now has no other courses depending on it
						qu.Enqueue(x);
					}
				}
			}

			// n=0 => all courses were added which means I had no cycle and solution exists.
			return n==0 ? result : new int[0];
		}
	}
}