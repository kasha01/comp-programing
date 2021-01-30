using System;
using System.Collections.Generic;

// https://leetcode.com/problems/merge-intervals/
namespace _csharp
{
	public class _56_merge_intervals
	{
		private static int compareByEndInterval(int[] source1, int[] source2)
		{
			int a2 = source1[1];
			int b2 = source2[1];

			if(a2<b2)
				return -1;

			if(a2>b2)
				return 1;

			return 0;
		}

		public int[][] Merge(int[][] intervals) {

			Array.Sort(intervals,compareByEndInterval);

			List<int[]> result = new List<int[]>();
			int n = intervals.Length;

			int b1 = intervals[n-1][0];
			int b2 = intervals[n-1][1];

			for(int i=n-2;i>=0;--i){
				int a1=intervals[i][0];
				int a2=intervals[i][1];

				// within/inside
				if(b1<=a1 && b1<=a2){
					b1=b1; b2=b2;
				}
				else if(a1<=b1 && a2>=b1){
					b1=a1; b2=b2;   // overlap
				}
				else{
					result.Add(new int[2]{b1,b2});  // no overlapping
					b1=a1;b2=a2;                
				}
			}

			result.Add(new int[2]{b1,b2});

			return result.ToArray();
		}
	}
}