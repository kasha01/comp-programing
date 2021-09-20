using System;

// https://leetcode.com/problems/jump-game/
namespace _csharp
{
	public class _55_jump_game
	{
		// O(N) approach.
		public bool CanJump(int[] nums) {
			if(nums.Length==1) return true;

			int n = nums.Length-1;
			for(int i=nums.Length-2; i>=0;--i){
				int jump = nums[i];
				if(i + jump >= n){
					n = i;
				}
			}
			return n == 0;
		}

		// dp O(n^2) approach
		bool[] deadEnd;
		public bool CanJump_dp(int[] nums) {
			if(nums.Length==1)
				return true;

			deadEnd = new bool[nums.Length+1];
			return rc(0,nums);
		}

		private bool rc(int i, int[] nums){
			if(i>=nums.Length-1)
				return true;

			if(deadEnd[i])
				return false;

			int jumps = nums[i];
			for(int j=jumps; j>0;--j){
				bool b = rc(i+j, nums);
				if(b) return true;
			}

			deadEnd[i] = true;
			return false;
		}
	}
}

