using System;

// https://leetcode.com/problems/rotate-image/
namespace _csharp
{
	public class _48_rotate_image
	{
		public void Rotate(int[][] matrix) {
			int n = matrix.Length;

			int ur=0; int lc=0; int lr=n-1; int rc=n-1; 
			while(n>0){
				int a=lc; int b=ur; int c=rc; int d=lr;
				for(int i=0;i<n-1;++i){
					int ai = matrix[ur][a];
					int bi = matrix[b][rc];
					int ci = matrix[lr][c];
					int di = matrix[d][lc];

					matrix[ur][a] = di;
					matrix[b][rc] = ai;
					matrix[lr][c] = bi;
					matrix[d][lc] = ci;

					a++; b++; c--; d--;
				}

				ur++; lr--; lc++; rc--;            
				n = n-2;
			}
		}
	}
}