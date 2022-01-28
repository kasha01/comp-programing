using System;

// https://leetcode.com/problems/minimum-operations-to-make-a-uni-value-grid/
namespace _csharp
{
	public class _2033_minimum_operations_to_make_a_uni_value_grid
	{
		public int MinOperations(int[][] grid, int x) {
			int n = grid.Length; int m = grid[0].Length;
			int[] arr = new int[n*m];

			int k = 0;
			for(int i=0;i<n;++i){
				for(int j=0;j<m;++j){
					arr[k] = grid[i][j];
					++k;
				}
			}

			Array.Sort(arr);

			int median = arr[(arr.Length-1)/2];

			int count = 0;
			foreach(int a in arr){
				if(a != median){
					int diff = Math.Abs(a-median);

					if(diff%x != 0) return -1;

					count = count + diff/x;
				}
			}

			return count;
		}
	}
}