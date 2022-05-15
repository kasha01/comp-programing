using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question/373202
// tags: two sum 
namespace _csharp
{
	public class _amazon_oa_optimal_utlization_two_sum
	{
		private List<int[]> getPairs(List<int[]> a, List<int[]> b, int target) {
			a.Sort ((x, y) => SortMe (x, y));
			b.Sort ((x, y) => SortMe (x, y));

			List<int[]> result = new List<int[]>();
			int max = int.MinValue;
			int m = a.Count;
			int n = b.Count;
			int i =0;
			int j =n-1;
			while(i<m && j >= 0) {
				int sum = a[i][1] + b[j][1];
				if(sum > target) {
					--j;
				} else {
					if(max <= sum) {
						if(max < sum) {
							max = sum;
							result.Clear();
						}
						result.Add(new int[]{a[i][0], b[j][0]});
						int index = j-1;
						while(index >=0 && b[index][1] == b[index+1][1]) {
							result.Add(new int[]{a[i][0], b[index--][0]});
						}
					}
					++i;
				}
			}
			return result;
		}

		private static int SortMe(int[] x, int[] y){
			if (x [1] < y [1]) return -1;			
			if (x [1] > y [1]) return 1;

			return 0;
		}
	}
}