using System;

// https://leetcode.com/problems/number-of-dice-rolls-with-target-sum/
namespace _csharp
{
	public class _1155_number_of_dice_rolls_with_target_sum
	{
		private const int mod = 1000000007;
		public int NumRollsToTarget(int d, int f, int target) {
			long[,] memo = new long[target+1,d+1];
			return (int)rc(0,d,f,target,memo);
		}

		private long rc(int sum, int dices, int heads, int target, long[,] memo){
			if(sum==target && dices==0) return 1;
			if(sum >= target || dices<=0) return 0;

			if(memo[sum,dices]>0) return memo[sum,dices]-1;

			long total = 0;
			for(int i=1;i<=heads;++i){
				total = total%mod + rc(sum+i,dices-1,heads,target,memo)%mod;
			}

			memo[sum,dices]=(total%mod)+1;
			return memo[sum,dices]-1;
		}
	}
}