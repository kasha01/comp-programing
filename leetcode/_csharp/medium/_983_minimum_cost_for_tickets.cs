using System;

/*
The leetcode solution is more intuitive though.
Check: https://leetcode.com/problems/minimum-cost-for-tickets/solution/
*/
// https://leetcode.com/problems/minimum-cost-for-tickets/
namespace _csharp
{
	public class _983_minimum_cost_for_tickets
	{
		int totalSum = int.MaxValue;
		public int MincostTickets(int[] days, int[] costs) {
			int n = days.Length;
			int[] memo = new int[n];

			int[] ticketRange = {1,7,30};
			rc(0,0,0,n,days,costs,ticketRange,memo);
			return totalSum;
		}

		private void rc(int i, int nextDay, int sum, int n, int[] days, int[] costs, int[] ticketRange, int[] memo){
			if(i>=n){
				totalSum = Math.Min(totalSum, sum);
				return;
			}

			if(nextDay > days[i])
				rc(i+1,nextDay,sum,n,days,costs,ticketRange,memo);

			if(memo[i]!=0 && sum>=memo[i])
				return;

			memo[i] = sum;
			for(int t=0;t<3;++t){
				int price = costs[t];
				rc(i+1, days[i]+ticketRange[t], sum + price,n,days,costs,ticketRange,memo);
			}
		}
	}
}

