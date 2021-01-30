using System;

// https://leetcode.com/problems/escape-the-ghosts/
namespace _csharp
{
	public class _789_escape_the_ghosts
	{
		public bool EscapeGhosts(int[][] ghosts, int[] target) {

			int distanceFromPlayerToTarget = Math.Abs(target[0]) + Math.Abs(target[1]);

			int n = ghosts.Length;
			for(int i=0; i<n; ++i){
				int d = Math.Abs(target[0]-ghosts[i][0]) + Math.Abs(target[1]-ghosts[i][1]);
				if(d <= distanceFromPlayerToTarget)
					return false;
			}

			return true;
		}
	}
}

