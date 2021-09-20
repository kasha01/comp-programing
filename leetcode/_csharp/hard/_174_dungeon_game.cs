using System;

// https://leetcode.com/problems/dungeon-game/
namespace _csharp
{
	public class _174_dungeon_game
	{
		int[,] memo;
		public int CalculateMinimumHP(int[][] dungeon) {
			int n = dungeon.Length; int m = dungeon[0].Length;
			memo = new int[n,m];
			return energy_needed(0,0,n,m,dungeon);
		}

		private int energy_needed(int i, int j, int n, int m, int[][] dungeon){
			if(i>=n || j>=m)
				return 100000000;

			if(i==n-1&&j==m-1)
				return dungeon[i][j] >=0 ? 1 : Math.Abs(dungeon[i][j])+1;

			if(memo[i,j]!=0) return memo[i,j];

			// energy needed - cell energy
			int s1 = energy_needed(i+1,j,n,m,dungeon) - dungeon[i][j];
			int s2 = energy_needed(i,j+1,n,m,dungeon) - dungeon[i][j];

			// if s1/2 is less than or equal 0, that means cell energy is more than what I need for 
			// target cell coming from cells i+1,j / i,j+1. so all what I need is 1.
			if(s1<=0) s1=1;
			if(s2<=0) s2=1;

			memo[i,j] = Math.Min(s1,s2);
			return memo[i,j];
		}
	}
}