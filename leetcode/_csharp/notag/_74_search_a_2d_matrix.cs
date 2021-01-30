using System;

// https://leetcode.com/problems/search-a-2d-matrix/
namespace _csharp
{
	public class _74_search_a_2d_matrix
	{
		public bool SearchMatrix(int[][] matrix, int target) {
			int r = matrix.Length;
			if(r==0)
				return false;

			int c = matrix[0].Length;

			if(c==0 || matrix[0][0] > target || matrix[r-1][c-1] < target)
				return false;

			int s=0; int e=(r*c)-1;

			while(s<=e){
				int mid = ((e-s)/2)+s;
				int xr = mid/c;
				int xc = mid%c;

				int x = matrix[xr][xc];
				if(x == target)
					return true;

				if(target > x)
				{
					s = mid+1;
				}
				else if(target < x){
					e = mid-1;
				}
			}

			return false;
		}
	}
}

