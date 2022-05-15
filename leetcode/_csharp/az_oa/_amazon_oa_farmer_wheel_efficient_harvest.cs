﻿using System;

namespace _csharp
{
	// https://leetcode.com/discuss/interview-question/1321204/efficient-harvest-faang-oa-question-2021

	/*
	Efficient Harvest: A farmer uses pivot irrigation to water a circular field of crops. Due to varying conditions, the field does not produce 
	consistently. The farmer wants to achieve maximum profit using limited resources for harvest. The field is segmented into a number of equal segments,
	and a profit is calculated for each segment. This profit is the cost to harvest versus the sale price a the produce. 
	The farmer will harvest a number of contiguous segments along with those opposite. Determine the maximum profit the farmer can achieve.
	For example, the field is divided into n = 6 sections and will select k = 2 contiguous sections and those opposite for harvest. 
	The profit estimates are profit = [1, 5, 1, 3, 7.-3) respectively. The diagrams below show the possible choices with profits(0) at the 9 o'clock 
	position and filling counterclockwise. -3 The profit levels, from left to right, are 1 + 5+7 + 3 - 16,5+1 +7 +-3-10, and 1 + 3+3+1 -2. 
	The maximum profit is 16. Function Description Complete the function maxProfit in the editor below. The function must return the maximum profit
	achievable. maxProfit has the following parameters: k an integer denoting the half of the needed amount of pieces of the field. profit[profit[0],..profit[n-1]. 
	*/

	public class _amazon_oa_farmer_wheel_efficient_harvest
	{
		public void solve(){
			int[] wheel = new int[]{1, 5, 1, 3, 7, -3};
			int n = wheel.Length; int k = 1;

			int m = n/2;

			int max_sum = 0;
			for(int i=0;i<k;++i){
				int x = wheel[i];
				int x_opp = wheel[(i+m)%n];
				max_sum = max_sum + x + x_opp;
			}

			int prev_pair = wheel[0] + wheel[m];
			int prev_sum = max_sum;
			for(int i=1;i<m;++i){
				int additional_section_index = i+k-1;
				int x = wheel[additional_section_index];
				int x_opp = wheel[(additional_section_index+m)%n];

				int new_pair = x + x_opp;
				int sum = prev_sum - prev_pair + new_pair;
				max_sum = Math.Max(max_sum, sum);
				prev_sum = sum;
				prev_pair = new_pair;
			}

			Console.WriteLine(max_sum);
		}
	}
}