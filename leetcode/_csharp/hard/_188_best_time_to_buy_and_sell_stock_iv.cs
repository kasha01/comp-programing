using System;

// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/
namespace _csharp
{
	public class _188_best_time_to_buy_and_sell_stock_iv
	{
		// intuitive O(n^2 * k) solution. there is a better O(nk) solution.
		public int MaxProfit(int k, int[] prices) {
			int n = prices.Length;
			if(n<=1 || k==0)
				return 0;

			int[,] memo = new int[n, k + 1];

			for(int tc=1;tc<=k;++tc){
				for(int buyIndex = prices.Length-2; buyIndex>=0; buyIndex--){
					memo [buyIndex, tc] = memo [buyIndex + 1, tc];
					for(int sellIndex = prices.Length-1; sellIndex>buyIndex; sellIndex--){
						int profit = prices[sellIndex] - prices[buyIndex];
						if (profit > 0) {
							memo [buyIndex, tc] = Math.Max(memo[buyIndex,tc], profit + memo[sellIndex,tc-1]);	
						}
					}
				}
			}

			return memo [0, k];
		}
	}
}

