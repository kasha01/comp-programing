using System;

// NOT MINE. 
// COURTESY OF dyckia
// https://leetcode.com/problems/sell-diminishing-valued-colored-balls/discuss/1116418/Java-sorting-solution-or-easy-to-understand-or-O(nlogn)

// https://leetcode.com/problems/sell-diminishing-valued-colored-balls/
namespace _csharp
{
	public class _1648_sell_diminishing_valued_colored_balls
	{
		public int MaxProfit(int[] inventory, int orders) {
			int n = inventory.Length;
			int mod = 1000000007;
			Array.Sort(inventory);
			int curIndex = n - 1;
			long profit = 0;

			while (orders > 0) {
				int curValue = inventory[curIndex];
				while (curIndex >= 0 && inventory[curIndex] == curValue) {
					curIndex--;
				}

				// if all colors of balls are the same value, nextValue is 0
				int nextValue = curIndex < 0 ? 0 : inventory[curIndex];
				// number of colors of balls with same value 
				int numSameColor = n - 1 - curIndex;
				// number of items to buy
				int nums = (curValue - nextValue) * numSameColor;
				if (orders >= nums) {
					// buy all items
					profit = profit + (((curValue + nextValue + 1) * (curValue - nextValue)) / 2) * numSameColor;
				} else {
					// orders left is less than the number of items to buy
					int numFullRow = orders / numSameColor;
					int remainder = orders % numSameColor;
					profit = profit + ((((curValue + curValue - numFullRow + 1) * numFullRow) / 2) * numSameColor);
					profit = profit + (curValue - numFullRow) * remainder;
				}
				orders = orders - nums;
				profit = profit % mod;
			}
			return (int)profit;
		}
	}
}

