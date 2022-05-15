using System;
using System.Collections.Generic;

// https://leetcode.com/problems/interval-list-intersections/
namespace _csharp
{
	public class _986_interval_list_intersections
	{
		public int[][] IntervalIntersection(int[][] firstList, int[][] secondList) {
			int n = firstList.Length;
			int m = secondList.Length;

			List<int[]> ans = new List<int[]>();
			int i=0; int j=0;

			while(i<n && j<m){
				int first_start = firstList[i][0];
				int first_end = firstList[i][1];

				int second_start = secondList[j][0];
				int second_end = secondList[j][1];

				int ans_start = Math.Max(first_start, second_start);
				int ans_end = Math.Min(first_end, second_end);

				if(ans_start <= ans_end)
					ans.Add(new int[2]{ans_start,ans_end});

				// move the one with minimum end as it can no longer intersect with others
				if(first_end < second_end)
					++i;
				else
					++j;
			}

			return ans.ToArray();
		}
	}
}