using System;

// https://leetcode.com/problems/climbing-stairs/
namespace _csharp
{
	public class _70_climbing_stairs
	{
		int[] memo;
		public int ClimbStairs(int n) {
			memo = new int[n+1];
			for(int i=0;i<=n;++i){
				memo[i] = -1;
			}

			return rc(0,n);
		}

		private int rc(int i, int n){
			if(i==n){
				return 1;
			}

			if(i>n)
				return 0;

			if(memo[i] != -1)
				return memo[i];

			memo[i] = rc(i+1,n) + rc(i+2,n);
			return memo[i];
		}
	}
}