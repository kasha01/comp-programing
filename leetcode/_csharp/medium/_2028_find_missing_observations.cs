using System;

// https://leetcode.com/problems/find-missing-observations/
namespace _csharp
{
	public class _2028_find_missing_observations
	{
		public int[] MissingRolls(int[] rolls, int mean, int n) {
			int sum = 0;
			foreach(int x in rolls){
				sum = sum + x;
			}

			int nm = rolls.Length + n;
			int sum_rolls_of_n = (mean * nm) - sum;

			int d = sum_rolls_of_n / n;
			int r = sum_rolls_of_n % n;

			if(d<= 0 || d>6 || (d==6 && r!=0))
				return new int[0];

			int[] result = new int[n];
			for(int i=0;i<n;++i){
				result[i] = d + (r > 0 ? 1 : 0);
				--r;
			}

			return result;
		}
	}
}