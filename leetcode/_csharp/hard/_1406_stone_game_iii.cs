using System;

// https://leetcode.com/problems/stone-game-iii/
namespace _csharp
{
	public class _1406_stone_game_iii
	{
		int[] memo;
		public string StoneGameIII(int[] stoneValue) {
			int n = stoneValue.Length;
			memo = new int[n];
			for(int i=0;i<n;++i){
				memo[i] = int.MaxValue;
			}

			int ans = rc(0,n,stoneValue);

			string winner="Tie";
			if(ans > 0)
				winner="Alice";
			else if(ans < 0)
				winner = "Bob";

			return winner;
		}   

		private int rc(int i, int n, int[] stoneValue){
			if(i>=n)
				return 0;

			if(memo[i]!=int.MaxValue) return memo[i];

			int maxScore = int.MinValue;
			int myScore = 0;
			for(int j=1;j<=3;++j){
				int idx = i+j-1;
				if(idx>=n)
					break;

				myScore = myScore + stoneValue[idx];            
				int otherPlayerScore = rc(idx+1,n,stoneValue);

				// maxScore = summation of myScore - summation of other player score.
				// the other player is the minimizer, as he tries to minimize my score.
				maxScore = Math.Max(maxScore,myScore-otherPlayerScore);
			}

			// returning the maximum delta of scores that I have above ahead of the other player.
			// this is NOT this player score, but it is how much this player is ahead of the other player. score
			memo[i] = maxScore;
			return maxScore;
		}
	}
}