using System;

// https://leetcode.com/problems/koko-eating-bananas/
namespace _csharp
{
	public class _875_koko_eating_bananas
	{
		public int MinEatingSpeed(int[] piles, int h) {
			int left = 1;
			int right = (int)Math.Pow(10,9);

			while(left < right){
				int m = (right-left)/2 + left;
				if(canEat(piles,h,m)){
					right = m;
				}
				else{
					left = m+1;
				}
			}

			return right;
		}

		private bool canEat(int[] piles, int h, decimal k){
			int hours = 0;
			foreach(int x in piles){
				hours = hours + (int)Math.Ceiling(x/k);
				if(hours > h)
					return false;
			}

			return true;
		}
	}
}