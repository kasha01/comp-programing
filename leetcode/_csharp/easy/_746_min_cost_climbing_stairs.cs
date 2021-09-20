using System;
using System.Collections.Generic;
using System.Collections;

namespace _csharp
{
	public class _746_min_cost_climbing_stairs
	{
		public int MinCostClimbingStairs(int[] cost) {
			int n = cost.Length;

			int[] memo = new int[n+1];
			for (int i = 0; i <= n; ++i)
				memo [i] = int.MaxValue;
			
			memo[0] = 0;

			int result = int.MaxValue;
			for(int start=0;start<=n;++start){
				// one step
				if(start+1>n){
					result = Math.Min(result,memo[start]);
				}
				else{
					int currentStepIndex = start;
					memo[start+1] = Math.Min(memo[start+1], memo[start] + cost[currentStepIndex]);
				}

				// two steps
				if(start+2>n){
					result = Math.Min(result,memo[start]);
				}
				else{
					int currentStepIndex = start+1;
					memo[start+2] = Math.Min(memo[start+2], memo[start] + cost[currentStepIndex]);
				}
			}

			return result;
		}
	}
}