using System;

// https://leetcode.com/problems/count-number-of-teams/
namespace _csharp
{
	public class _1395_count_number_of_teams
	{
		public int NumTeams(int[] rating) {
			int n = rating.Length;
			int sum=0;
			int[] left_greater_than_me = new int[n];
			int[] right_greater_than_me = new int[n];
			int[] left_less_than_me = new int[n];
			int[] right_less_than_me = new int[n];

			for(int i=0;i<n;++i){
				int player = rating[i];
				for(int j=0;j<n;++j){
					if(rating[j] < player){
						if(j<i){
							left_less_than_me[i]++;
						}
						else if(j>i){
							right_less_than_me[i]++;
						}                    
					}

					if(rating[j] > player){
						if(j<i){
							left_greater_than_me[i]++;
						}
						else if(j>i){
							right_greater_than_me[i]++;
						}
					}
				}            

				int rate_ascending_i_sum = left_less_than_me[i] * right_greater_than_me[i];
				int rate_decreasing_i_sum = left_greater_than_me[i] * right_less_than_me[i];
				sum = sum + rate_ascending_i_sum + rate_decreasing_i_sum;
			}

			return sum;
		}
	}
}