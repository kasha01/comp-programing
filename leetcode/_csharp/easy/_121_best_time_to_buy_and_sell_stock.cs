using System;

// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
namespace _csharp
{
	public class _121_best_time_to_buy_and_sell_stock
	{
		public int MaxProfit(int[] prices) {
			int n = prices.Length;
			int mn = prices[0];
			int profit = 0;

			for(int i=1;i<n;++i){
				if(prices[i]> mn){
					profit = Math.Max(profit, prices[i]- mn);
				}
				else{
					mn = Math.Min(prices[i], mn);
				}
			}

			return profit;
		}
	}
}

