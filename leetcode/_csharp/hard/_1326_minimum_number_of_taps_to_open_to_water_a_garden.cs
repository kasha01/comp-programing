using System;

// https://leetcode.com/problems/minimum-number-of-taps-to-open-to-water-a-garden/
namespace _csharp
{
	// Second Pass
	public class _1326_minimum_number_of_taps_to_open_to_water_a_garden
	{
		public int MinTaps(int n, int[] ranges) {
			int m = ranges.Length;
			int[][] hoses = new int[m][];

			for(int j=0;j<m;++j){
				int start = Math.Max(0, j-ranges[j]);
				int end = j+ranges[j];
				hoses[j] = new int[2]{start,end};
			}

			// sort by start range
			Array.Sort(hoses, (a,b) => SortAsc(a,b));

			int i=0; int furthest=0; int cnt=0;
			while(i<m && furthest<n){
				cnt++;
				int temp = furthest;

				while(i<m && hoses[i][0] <= furthest){
					temp = Math.Max(temp, hoses[i][1]);
					++i;
				}

				if(temp == furthest)
					return -1;

				furthest = temp;
			}

			if(furthest < n) return -1;

			return cnt;
		}

		private static int SortAsc(int[] a, int[] b){
			int sa = a[0]; int ea = a[1];
			int sb = b[0]; int eb = b[1];

			if(sa<sb) return -1;
			if(sa>sb) return 1;

			if(ea>eb) return -1;
			if(ea<eb) return 1;

			return 0;
		}
	}
}