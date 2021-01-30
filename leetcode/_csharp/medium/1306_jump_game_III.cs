using System;

// https://leetcode.com/problems/jump-game-iii/
namespace _csharp
{
	public class _306_jump_game_III
	{
		int[] memo;
		int n=0;
		public bool CanReach(int[] arr, int start) {
			n = arr.Length;
			memo = new int[n];

			return fn(arr, start);
		}

		private bool fn(int[] arr, int i){
			if(i>=n || i<0){
				return false;
			}

			if(arr[i]==0){
				return true;
			}

			if(memo[i] == 1){
				return false;
			}

			memo[i] = 1;
			return fn(arr, i+arr[i]) || fn(arr, i-arr[i]);
		}
	}
}

