using System;

// https://leetcode.com/problems/toeplitz-matrix/
namespace _csharp
{
	public class _766_toeplitz_matrix
	{
		public bool IsToeplitzMatrix(int[][] matrix) {
			for(int i=1;i<matrix.Length;++i){
				for(int j=1;j<matrix[0].Length;++j){
					if(matrix[i-1][j-1] != matrix[i][j]) return false;
				}
			}

			return true;        
		}
	}
}