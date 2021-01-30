using System;

// https://leetcode.com/problems/maximum-number-of-coins-you-can-get/
namespace _csharp
{
	public class _1561_maximum_number_of_coins_you_can_get
	{
		public int MaxCoins(int[] piles) {
			Array.Sort(piles);
			int n = piles.Length;
			int i=0; int j=n-1;

			int sum=0;
			while(i+1<j){
				sum = sum + piles[j-1];
				++i;
				j=j-2;
			}
			return sum;
		}
	}
}

