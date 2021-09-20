using System;
using System.Collections.Generic;

// https://leetcode.com/problems/sort-the-matrix-diagonally/
namespace _csharp
{
	public class _1329_sort_the_matrix_diagonally
	{
		public int[][] DiagonalSort(int[][] mat) {
			int n = mat.Length;
			int m = mat[0].Length;

			List<int>[] upperDiagonals = new List<int>[m];
			List<int>[] lowerDiagonals = new List<int>[n];

			for(int i=0;i<m;++i){
				upperDiagonals[i] = new List<int>();
			}
			for(int i=0;i<n;++i){
				lowerDiagonals[i] = new List<int>();
			}

			for(int i=0;i<n;++i){
				for(int j=0;j<m;++j){
					if(i==j){
						upperDiagonals[0].Add(mat[i][j]);
					}
					else if(j>i){
						upperDiagonals[j-i].Add(mat[i][j]);
					}
					else{
						lowerDiagonals[i-j].Add(mat[i][j]);
					}
				}
			}

			for(int i=0;i<m;++i){
				upperDiagonals[i].Sort(new SortDesc());
			}
			for(int i=0;i<n;++i){
				lowerDiagonals[i].Sort(new SortDesc());
			}

			int[][] result = new int[n][];
			for(int i=0;i<n;++i){
				result[i] = new int[m];
			}

			for(int i=0;i<n;++i){
				for(int j=0;j<m;++j){
					if(i==j){
						int k = upperDiagonals[0].Count;
						result[i][j] = upperDiagonals[0][k-1];
						upperDiagonals[0].RemoveAt(k-1);
					}
					else if(j>i){
						int k = upperDiagonals[j-i].Count;
						result[i][j] = upperDiagonals[j-i][k-1];
						upperDiagonals[j-i].RemoveAt(k-1);
					}
					else{
						int k = lowerDiagonals[i-j].Count;
						result[i][j] = lowerDiagonals[i-j][k-1];
						lowerDiagonals[i-j].RemoveAt(k-1);
					}
				}
			}

			return result;
		}

		private class SortDesc:IComparer<int>{
			public int Compare(int a, int b){
				if(a>b) return -1;
				if(a<b) return 1;
				return 0;                    
			}
		}
	}
}

