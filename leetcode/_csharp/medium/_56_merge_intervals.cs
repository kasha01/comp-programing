using System;
using System.Collections.Generic;

// https://leetcode.com/problems/merge-intervals/
namespace _csharp
{
	public class _56_merge_intervals
	{
		private static int compareByStartInterval(int[] source1, int[] source2)
		{
			int a1 = source1[0];
			int b1 = source2[0];

			int a2 = source1[1];
			int b2 = source2[1];

			if(a1<b1)
				return -1;

			if(a1>b1)
				return 1;

			if(a2<b2)
				return -1;

			if(a2>b2)
				return 1;

			return 0;
		}

		public int[][] Merge(int[][] intervals) {
			Array.Sort(intervals,compareByStartInterval);

			List<int[]> result = new List<int[]>();
			int n = intervals.Length;

			// initial
			int start = intervals[0][0];
			int end = intervals[0][1];

			int i = 1;
			while(i<n){
				int i_start = intervals[i][0];
				int i_end = intervals[i][1];

				if(end >= i_start){
					// overlapp
					end = Math.Max(end,i_end);
					++i;
				}
				else{
					// no overlap -> [i_start,i_end] is a new interval
					result.Add(new int[2]{start,end});

					start = intervals[i][0];
					end = intervals[i][1];
					++i;
				}
			}

			result.Add(new int[2]{start,end});
			return result.ToArray();
		}

	}
}