using System;

// https://leetcode.com/problems/minimum-moves-to-reach-target-score/
namespace _csharp
{
	public class _2139_minimum_moves_to_reach_target_score
	{
		public int MinMoves(int target, int maxDoubles) {
			int c = 0;
			while(target>1){
				if(maxDoubles == 0){
					// I can no longer divide by two. so all remaining operatios are decrement.
					c = c + target-1;
					break;
				}

				if(target%2 == 1){
					// odd
					--target;
				}
				else{
					--maxDoubles;
					target=target/2;
				}

				++c;
			}

			return c;
		}
	}
}

