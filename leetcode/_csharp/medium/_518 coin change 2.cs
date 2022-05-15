using System;

// https://leetcode.com/problems/coin-change-2/
namespace _csharp
{
	public class _518_coin_change_2
	{
		// using dp - Knapsack
		public int Change(int amount, int[] coins) {
			int n = coins.Length;
			var dp = new int[amount+1];
			dp[0] = 1;

			for(int i=0;i<n;++i){
				for(int w=coins[i];w<=amount;++w){
					// if i picked coins[i] then number of ways equals the number of ways to have [w-coins[i]]
					// if coins[i] = 10, and w=15 then I need the number of ways to make 5
					dp[w] = dp[w] + dp[w-coins[i]];
				}
			}

			return dp[amount];
		}


		// recurssion
		public int Change_rc(int amount, int[] coins) {
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