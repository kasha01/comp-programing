using System;

// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/
namespace _csharp
{
	public class _123_best_time_to_buy_and_sell_stock_iii
	{
		public int MaxProfit(int[] prices) {
			int n = prices.Length;
			if(n<=1) return 0;

			int kk = 2;
			int[,] profit = new int[n+1,kk+1];

			// profit[sell,k] = Max(price[sell] - price[buy] + profit[buy-1,k-1]) for buy=0 to sell-1
			//                = Max(price[sell] + Max(profit[buy-1,k-1] - price[buy]) for buy= 0 to sell-1 )
			// since (profit[buy-1,k-1] - price[buy]) has no dependency on sell, I can take this out of the 
			// sell loop and caclulate it as I proceeds through the buy which is the previous sell value.

			for(int k=1;k<=kk;++k){
				int max_prev = profit[0,k-1] - prices[0];
				for(int sell=2;sell<=n;++sell){
					profit[sell,k] = Math.Max(
						profit[sell-1,k], 
						prices[sell-1] + max_prev);

					max_prev = Math.Max(max_prev, profit[sell-1,k-1] - prices[sell-1]);
				}
			}

			return profit[n,kk];
		}
	}
}