using System;
using System.Collections.Generic;

// https://leetcode.com/problems/coin-change/
namespace _csharp
{
	public class _322_coin_change
	{
		public int CoinChange(int[] coins, int amount) {
			if(amount==0)
				return 0;

			Array.Sort(coins, new RevComparer());

			int n = coins.Length;
			int[] memo = new int[amount+1];

			for(int i=1;i<=amount;++i){
				memo[i] = int.MaxValue;
				foreach(int c in coins){
					if(i-c >= 0 && memo[i-c] != int.MaxValue){
						memo[i] = Math.Min(memo[i], 1+memo[i-c]);                    
					}
				}
			}

			return memo[amount] == int.MaxValue ? -1 : memo[amount];
		}

		public class RevComparer : IComparer<int>{
			public int Compare(int a, int b){
				if(a<b) return 1;
				if(a>b) return -1;
				return 0;
			}
		}
	}
}