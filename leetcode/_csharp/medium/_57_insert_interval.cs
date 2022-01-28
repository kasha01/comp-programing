using System;
using System.Collections.Generic;

// https://leetcode.com/problems/insert-interval/
namespace _csharp
{
	public class _57_insert_interval
	{
		public int[][] Insert(int[][] intervals, int[] newInterval) {
			var merge = new List<int[]>();
			int i=0; int n = intervals.Length;

			int start = newInterval[0];
			int end = newInterval[1];

			while(i<n && intervals[i][1] < newInterval[0]){
				merge.Add(intervals[i]); ++i;
			}

			while(i<n && end >= intervals[i][0]){
				start = Math.Min(intervals[i][0], start);
				end = Math.Max(intervals[i][1], end);
				++i;
			}            

			merge.Add(new int[]{start,end});

			while(i<n){
				merge.Add(intervals[i]); ++i;
			}

			return merge.ToArray();
		}
	}
}