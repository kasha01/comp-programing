using System;

// https://leetcode.com/discuss/interview-question/313719/Amazon-or-Online-Assessment-2019-or-Movies-on-Flight

/*
 * Question:
You are on a flight and wanna watch two movies during this flight.
You are given List<Integer> movieDurations which includes all the movie durations.
You are also given the duration of the flight which is d in minutes.
Now, you need to pick two movies and the total duration of the two movies is less than or equal to (d - 30min).

Find the pair of movies with the longest total duration and return they indexes. If multiple found, return the pair with the longest movie.

Example:
Input: movieDurations = [90, 85, 75, 60, 120, 150, 125], d = 250
Output: [0, 6]
Explanation: movieDurations[0] + movieDurations[6] = 90 + 125 = 215 is the maximum number within 220 (250min - 30min)
*/

namespace _csharp
{
	public class _amazon_oa_movies_on_flight
	{
		public void solve(){
			var flights = new int[]{ 90, 85, 75, 60, 120, 110, 110, 150, 125 };
			int duration = 250;
			int n = flights.Length;

			// value | index
			var arr = new Tuple<int,int>[n];
			for (int i = 0; i < n; ++i) {
				arr [i] = Tuple.Create (flights [i], i);
			}

			Array.Sort (arr);

			int[] res = new int[2] { -1, -1 };
			int l = 0; int r = n - 1; int maxSum = -1;

			while (l < r) {
				int sum = arr [l].Item1 + arr [r].Item1;
				int target = duration - 30;

				if (sum > target) {
					--r;
				} else {
					if (sum <= target && sum >= maxSum) {
						if (maxSum == -1) {
							// this is the initial setting.
							res [0] = arr [l].Item2;
							res [1] = arr [r].Item2;
						} else {
							// pick the longest movies pair
							int current_pair_sum = flights[res[0]] + flights[res[1]];

							if (sum > current_pair_sum) {
								res [0] = arr [l].Item2;
								res [1] = arr [r].Item2;
							}
						}

						maxSum = sum;
					}

					++l;
				}
			}

			Console.WriteLine (res [0] + " " + res [1]);
		}		
	}
}