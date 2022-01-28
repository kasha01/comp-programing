using System;

// https://leetcode.com/problems/convert-1d-array-into-2d-array/
namespace _csharp
{
	public class _2022_convert_1d_array_into_2d_array
	{
		public int[][] Construct2DArray(int[] original, int m, int n) {
			if(n*m != original.Length) return new int[0][];

			int[][] ans = new int[m][];

			int k = 0;
			for(int i=0;i<m;++i){
				ans[i] = new int[n];
				for(int j=0;j<n;++j){
					ans[i][j] = original[k];
					++k;
				}
			}    

			return ans;
		}
	}
}