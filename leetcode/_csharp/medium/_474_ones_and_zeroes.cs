using System;

// https://leetcode.com/problems/ones-and-zeroes/
namespace _csharp
{
	public class _474_ones_and_zeroes
	{
		public int FindMaxForm(string[] strs, int m, int n) {
			int sz = strs.Length;
			int[,,] memo = new int[sz, m+1, n+1];

			for(int i=0;i<sz;++i){
				for(int j=0;j<=m;++j){
					for(int k=0;k<=n;++k){
						memo[i,j,k] = -1;
					}
				}
			}

			int[] zeros = new int[sz];
			int[] ones = new int[sz];

			for(int i=0;i<sz;++i){
				string x = strs [i];
				foreach(char c in x){
					if(c=='1'){
						ones [i]++;
					}
					else{
						zeros [i]++;
					}
				}
			}

			return rc(0,strs,zeros,ones,m,n,memo);
		}

		private int rc(int i, string[] strs, int[] zeros, int[] ones, int countOfZeros, int countOfOnes, int[,,] memo){
			if(i >= strs.Length)
				return 0;

			// not a valid case, return -1 so not to be considered a valid answer
			if(countOfZeros < 0 && countOfOnes < 0)
				return -1;

			if(memo[i,countOfZeros,countOfOnes]>=0)
				return memo[i,countOfZeros,countOfOnes];

			int strs_zeros = zeros[i];
			int strs_ones = ones[i];

			int picked_ans = 0;
			int not_picked_ans = 0;
			if(countOfZeros >= strs_zeros && countOfOnes >= strs_ones){
				// this string can be picked;
				picked_ans = 1 + rc(i+1, strs, zeros, ones, countOfZeros-strs_zeros, countOfOnes-strs_ones,memo);   
			}
			not_picked_ans = rc(i+1, strs, zeros, ones, countOfZeros, countOfOnes,memo);

			memo[i,countOfZeros,countOfOnes] = Math.Max(picked_ans, not_picked_ans);
			return memo[i,countOfZeros,countOfOnes];
		}
	}
}