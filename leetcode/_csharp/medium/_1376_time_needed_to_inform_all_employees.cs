using System;
using System.Collections.Generic;

// https://leetcode.com/problems/time-needed-to-inform-all-employees/
namespace _csharp
{
	public class _1376_time_needed_to_inform_all_employees
	{
		public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
			Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

			for(int employee=0;employee<n;++employee){
				int _manager = manager[employee];
				if(!map.ContainsKey(_manager)){
					map.Add(_manager,new List<int>());
				}
				map[_manager].Add(employee);
			}

			return dfs(headID, manager, informTime, map);
		}

		private int dfs(int head, int[] manager, int[] informTime, Dictionary<int, List<int>> map){
			if(!map.ContainsKey(head)){
				return 0;
			}

			int time = 0;
			List<int> subordinates = map[head];
			foreach(int sub in subordinates){
				time = Math.Max(time,dfs(sub, manager, informTime, map));
			}

			return time + informTime[head];
		}
	}
}

