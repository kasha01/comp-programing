using System;
using System.Collections.Generic;

// https://leetcode.com/problems/numbers-with-same-consecutive-differences/
namespace _csharp
{
	public class _967_numbers_with_same_consecutive_differences
	{
		List<int> result;
		public int[] NumsSameConsecDiff(int n, int k) {
			result = new List<int>();
			for(int i=1;i<=9;++i){
				rc(i,i,n-1,k);
			}
			return result.ToArray();
		}

		private void rc(int num, int d, int n, int k) {
			if(n==0){
				result.Add(num);
				return;
			}

			int diff = -1;
			if(d-k >=0){
				diff = d-k;
				int x = (num*10) + (d-k);
				rc(x,d-k,n-1,k);    
			}

			if(d+k < 10 && d+k!=diff){
				int x = (num*10) + (d+k);
				rc(x,d+k,n-1,k);
			}
		}
	}
}