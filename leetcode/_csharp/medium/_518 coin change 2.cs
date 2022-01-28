using System;

// https://leetcode.com/problems/coin-change-2/
namespace _csharp
{
	public class _518_coin_change_2
	{
		public int Change(int amount, int[] coins) {
			int n = coins.Length;
			var memo = new int[n,amount+1];
			for(int i=0;i<n;++i){
				for(int j=0;j<=amount;++j){
					memo[i,j] = -1;
				}
			}

			return rc(0,0,amount,coins,n,memo);
		}

		private int rc(int start, int sum, int amount, int[] coins, int n, int[,] memo){
			if(start >= n || sum > amount) return 0;

			if(sum == amount) return 1;

			if(memo[start,sum]!=-1) return memo[start,sum];

			memo[start,sum] = 
				rc(start, sum + coins[start], amount, coins, n, memo) +
				rc(start+1, sum, amount, coins, n, memo);

			return memo[start,sum];
		}
	}
}