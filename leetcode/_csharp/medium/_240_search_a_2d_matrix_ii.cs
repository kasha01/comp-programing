using System;
using System.Collections.Generic;

// https://leetcode.com/problems/search-a-2d-matrix-ii/
namespace _csharp
{
	public class _240_search_a_2d_matrix_ii
	{
		public bool SearchMatrix(int[][] matrix, int target) {
			int n = matrix.Length; int m = matrix[0].Length;

			// binary search finding the maximum column after which target cannot exist.
			int lo_index = get_lo_index(0, m-1, matrix[0], target);
			if(lo_index < 0)
				return false;

			if(matrix[0][lo_index] == target)
				return true;

			for(int column=lo_index;column>=0;--column){
				bool isFound = bs(0, n-1, matrix, target, column);
				if(isFound)
					return true;
			}

			return false;
		}

		private bool bs(int lo, int hi, int[][] arr, int target, int lo_index){
			while(lo<=hi){
				int mid = (hi-lo)/2 + lo;

				if(arr[mid][lo_index] > target)
					hi = mid-1;
				else if(arr[mid][lo_index] < target)
					lo = mid+1;
				else
					return true;
			}

			return false;
		}

		private int get_lo_index(int lo, int hi, int[] arr, int target){
			int ans = -1;
			while(lo<=hi){
				int mid = (hi-lo)/2 + lo;

				if(arr[mid] <= target){
					ans = mid;
					lo = mid+1;
				}
				else{
					hi = mid-1;
				}            
			}

			return ans;
		}
	}
}