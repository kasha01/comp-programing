using System;

// https://leetcode.com/problems/maximum-ice-cream-bars/
namespace _csharp
{
	public class _1833_maximum_ice_cream_bars
	{
		public int MaxIceCream(int[] costs, int coins) {
			Array.Sort(costs);

			int sum = 0;
			for(int i=0;i<costs.Length;++i){
				int remaining = coins-costs[i];
				if(remaining<0)
					break;

				++sum;
				coins=remaining;
			}

			return sum;
		}
	}
}