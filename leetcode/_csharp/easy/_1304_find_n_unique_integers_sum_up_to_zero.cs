using System;

// https://leetcode.com/problems/find-n-unique-integers-sum-up-to-zero/
namespace _csharp
{
	public class _1304_find_n_unique_integers_sum_up_to_zero
	{
		public int[] SumZero(int n) {
			int[] ans = new int[n];

			int k=1;
			int i=0; int j=n-1;
			while(i<j){
				ans[i]=k; ans[j]=k*-1;
				++k;
				++i; --j;
			}

			return ans;
		}
	}
}