using System;

// https://leetcode.com/problems/minimum-limit-of-balls-in-a-bag/
namespace _csharp
{
	public class _1760_minimum_limit_of_balls_in_a_bag
	{
		public int MinimumSize(int[] nums, int maxOperations) {
			int left = 1; int right = (int)Math.Pow(10,9);

			while (left < right){
				int m = ((right-left)/2) + left;

				if(canDivide(nums, maxOperations, m)){
					right = m;
				}
				else{
					left = m + 1;
				}
			}        
			return right;
		}

		private bool canDivide(int[] nums, int maxOperations, int m){
			int c = 0;
			foreach(int x in nums){
				if(x > m){
					// int operations = (int)Math.Ceiling((double)x/m) - 1;                
					c = c + (x-1)/m;
					if(c>maxOperations)
						return false;
				}
			}
			return true;        
		}
	}
}

