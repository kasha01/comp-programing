using System;

// https://leetcode.com/problems/find-valid-matrix-given-row-and-column-sums/
namespace _csharp
{
	public class _1605_find_valid_matrix_given_row_and_column_sums
	{
		public int[][] RestoreMatrix(int[] rowSum, int[] colSum) {
			int r = rowSum.Length;
			int c = colSum.Length;

			int[][] matrix = new int[r][];
			for(int i=0;i<r;++i){
				matrix[i] = new int[c];
			}

			for(int i=0;i<r;++i){
				for(int j=0;j<c;++j){
					// greedily consume the rowSum if applicable (>0)
					if(rowSum[i]>0){
						if(rowSum[i]<=colSum[j]){
							// put the smaller number (rowSum) in the matrix
							matrix[i][j] = rowSum[i];
							colSum[j] = colSum[j] - rowSum[i];
							rowSum[i] = 0;
						}
						else{
							// rowSum > colSum --> put the colSum in the matrix
							matrix[i][j] = colSum[j];
							rowSum[i] = rowSum[i] - colSum[j];
							colSum[j] = 0;
						}       
					}             
				}
			}

			return matrix;
		}
	}
}

