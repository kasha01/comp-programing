using System;

// https://leetcode.com/problems/maximum-length-of-repeated-subarray/
namespace _csharp
{
	public class _718_maximum_length_of_repeated_subarray
	{
		public int FindLength(int[] A, int[] B) {
			int mx = 0;
			int[,] memo = new int[A.Length+1,B.Length+1];

			for(int i=1;i<=A.Length;++i){
				for(int j=1;j<=B.Length;++j){
					if(A[i-1] == B[j-1]){
						memo[i,j] = memo[i-1,j-1] + 1;
						mx = Math.Max(mx, memo[i,j]);
					}
				}
			}

			return mx;
		}
	}
}