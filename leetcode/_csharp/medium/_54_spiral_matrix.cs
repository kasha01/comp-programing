using System;
using System.Collections.Generic;

// https://leetcode.com/problems/spiral-matrix/
// Kinda my solution. needed little debugging help from solution.
namespace _csharp
{
	public class _54_spiral_matrix
	{
		public IList<int> SpiralOrder(int[][] matrix) {
			int r = matrix.Length;
			int c = matrix[0].Length;
			List<int> ans = new List<int>();
			int rs=0; int cs=0; int re=r-1; int ce=c-1;

			while(rs<=re && cs<=ce){

				for(int i=cs; i<=ce; ++i){
					ans.Add(matrix[rs][i]);
				}

				for(int i=rs+1; i<=re; ++i){
					ans.Add(matrix[i][ce]);
				}

				if (rs < re && cs < ce) {
					for(int i=ce-1; i>=cs; --i){
						ans.Add(matrix[re][i]);
					}

					for(int i=re-1; i>=rs+1; --i){
						ans.Add(matrix[i][cs]);
					}    
				}

				rs++; re--; cs++; ce--;
			}

			return ans;
		}
	}
}