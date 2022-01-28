using System;

// https://leetcode.com/problems/maximal-square/
namespace _csharp
{
	public class _221_maximal_square
	{
		public int MaximalSquare(char[][] matrix) {
			int n = matrix.Length; int m = matrix[0].Length;
			int[,] memo = new int[n+1,m+1];

			int maxSideLength = 0;
			for(int i=1;i<=n;++i){
				for(int j=1;j<=m;++j){
					if(matrix[i-1][j-1] == '1'){
						memo[i,j] = Math.Min(memo[i-1,j-1], Math.Min(memo[i-1,j],memo[i,j-1])) + 1;
						maxSideLength = Math.Max(maxSideLength, memo[i,j]);
					}
				}
			}

			return maxSideLength*maxSideLength;
		}
	}
}