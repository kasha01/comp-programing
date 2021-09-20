using System;

// https://leetcode.com/problems/house-robber/
namespace _csharp
{
	public class _198_house_robber
	{
		public int Rob(int[] nums) {
			int n = nums.Length;
			if(n==0)
				return 0;

			if(n==1)
				return nums[0];

			int[] memo = new int[n+1];
			memo[n]=0;
			memo[n-1] = nums[n-1];

			for(int i=n-2;i>=0;--i){
				int picked = nums[i] + memo[i+2];
				int notPicked = memo[i+1];
				memo[i] = Math.Max(picked,notPicked);
			}

			return memo[0];
		}
	}
}

