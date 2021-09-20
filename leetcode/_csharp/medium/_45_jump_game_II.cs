using System;

// https://leetcode.com/problems/jump-game-ii/
namespace _csharp
{
	public class _45_jump_game_II
	{
		public int Jump(int[] nums) {
			int n = nums.Length;
			int[] memo = new int[n];

			memo[n-1] = 0;

			for(int i=n-2; i>=0; --i){
				memo[i] = int.MaxValue;
				int x = nums[i];
				if(x==0){
					memo[i] = -1;
				}
				else if(x>=n-i-1){
					memo[i] = 1;
				}
				else{
					for(int j=x;j>=1;--j){
						if(i+j < n && memo[i+j] != -1){
							memo[i] = Math.Min(memo[i], memo[i+j] + 1);    
						}                    
					}

					if(memo[i] == int.MaxValue)
						memo[i] = -1;
				}
			}
			return memo[0];
		}
	}
}