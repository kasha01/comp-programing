using System;

// https://leetcode.com/problems/max-consecutive-ones-iii/
namespace _csharp
{
	public class _1004_max_consecutive_ones_III
	{
		public int LongestOnes(int[] A, int K) {
			int n = A.Length;
			int l=0; int r=0; int count=0; int maxLength=0;

			while(r<n){
				if(A[r] == 0)
					count++;

				while(count > K){
					if(A[l] == 0)
						--count;
					++l;
				}

				maxLength = Math.Max(maxLength, r-l+1);
				++r;            
			}

			return maxLength;
		}
	}
}