using System;
using System.Collections.Generic;

// https://leetcode.com/problems/decode-ways/
namespace _csharp
{
	public class _1_decode_ways
	{
		int[] memo;
		public int NumDecodings(string s) {
			int n = s.Length;
			memo = new int[n];
			for (int i = 0; i < n; ++i)
				memo [i] = -1;
			
			return rc(0,n,s,memo);
		}

		private int rc(int i, int n, string s, int[] memo){
			if(i>= n)
				return 1;

			if(memo[i]!=-1) return memo[i];

			int c1 = s[i] - 48;
			if(c1==0)
				return 0;

			int sum1 = rc(i+1,n,s,memo);
			int sum2 = 0;

			if(i+1<n){
				int c2 = s[i+1] - 48;
				if(c1*10 + c2 <= 26){
					sum2 = rc(i+2,n,s,memo);
				}
			}

			memo[i] = sum1+sum2;
			return memo[i];
		}
	}
}