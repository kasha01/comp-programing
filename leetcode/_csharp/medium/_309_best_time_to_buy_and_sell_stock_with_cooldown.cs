using System;

// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/
namespace _csharp
{
	public class _309_best_time_to_buy_and_sell_stock_with_cooldown
	{
		public int MaxProfit(int[] prices) {
			int n = prices.Length;
			var memo = new int[n];
			return rc(0,prices,memo);
		}

		private int rc(int buyIndex, int[] prices, int[] memo){
			if(buyIndex >= prices.Length-1){
				return 0;
			}

			if(memo[buyIndex] > 0)
				return memo[buyIndex];

			int maxProfit=0;

			// skip this buy
			maxProfit = rc(buyIndex+1, prices, memo);

			for(int sellIndex=buyIndex+1;sellIndex<prices.Length;++sellIndex){
				int profit = prices[sellIndex] - prices[buyIndex];
				if(profit <= 0)
					continue;

				maxProfit = Math.Max(maxProfit, profit + rc(sellIndex+2,prices,memo));
			}

			memo[buyIndex] = maxProfit;
			return maxProfit;
		}
	}
}

