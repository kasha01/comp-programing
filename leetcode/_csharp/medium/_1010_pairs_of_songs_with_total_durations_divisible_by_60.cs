using System;

// https://leetcode.com/problems/pairs-of-songs-with-total-durations-divisible-by-60/
namespace _csharp
{
	public class _1010_pairs_of_songs_with_total_durations_divisible_by_60
	{
		public int NumPairsDivisibleBy60(int[] time) {
			int n = time.Length;
			int[] memo = new int[60]; 
			int sum = 0;

			for(int i=0;i<n;++i){
				int r1 = time[i]%60;
				int r2 = (60 - r1)%60;

				sum = sum + memo[r2];
				memo[r1]++;
			}

			return sum;
		}
	}
}