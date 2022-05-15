using System;

// https://leetcode.com/discuss/interview-question/1829745/Facebook-Coding-Puzzle
/*
 cafeteria table consists of a row of N seats, numbered from 1 to N from left to right. Social distancing guidelines require that every diner be seated such that K seats to their left and K seats to their right (or all the remaining seats to that side if there are fewer than K) remain empty.
There are currently M diners seated at the table, the ith of whom is in seat Si. No two diners are sitting in the same seat, and the social distancing guidelines are satisfied.
Determine the maximum number of additional diners who can potentially sit at the table without social distancing guidelines being violated for any new or existing diners, assuming that the existing diners cannot move and that the additional diners will cooperate to maximize how many of them can sit down.
Please take care to write a solution which runs within the time limit.

Sample test case #1
N = 10
K = 1
M = 2
S = [2, 6]

Expected Return Value = 3

Sample Explanation
In the first case, the cafeteria table has N=10N = 10N=10 seats, with two diners currently at seats 222 and 666 respectively. The table initially looks as follows, with brackets covering the K=1K = 1K=1 seat to the left and right of each existing diner that may not be taken.

1 2 3 4 5 6 7 8 9 10
[ ] [ ]

Three additional diners may sit at seats 4, 8, and 10 without violating the social distancing guidelines.
*/

namespace _csharp
{
	public class _fb_oa_social_distance_seating
	{
		// time complexity O(M). space complexity O(1) 
		public void solve_best(){
			int n = 10;
			int k = 1;
			int m = 2;	// existing people
			var s = new int[]{ 2, 6 };	// seats of existing people

			int min_seats_new_person_needs_plus_left_side_distancing = k + 1;	// social distancing seats + person actual seat which is 1
			int sum = 0;

			// between first s and the left end. here we take the ceiling as I don't have to count for the left end distancing 
			// we subtract k to count for distance between s[0] left side required distance 
			int seats_available_left = s[0] - k;
			if (seats_available_left >= min_seats_new_person_needs_plus_left_side_distancing)
				sum = sum + ((seats_available_left + min_seats_new_person_needs_plus_left_side_distancing - 1) / min_seats_new_person_needs_plus_left_side_distancing);

			int prev = s [0];
			for (int i = 1; i < m; ++i) {
				// seats avaialbe between s[i] and prev equals
				// s[i]-prev - 1(to count for s[i] taken seat) - k(to count for the distance between new_person right side and s[i] i.e. s[i] left side distance)
				int diff = s [i] - prev - 1 - k;

				sum = sum + (diff / min_seats_new_person_needs_plus_left_side_distancing);
				prev = s [i];
			}

			// between first s and the right end. here we take the ceiling as I don't have to count for the right end distancing 
			// we subtract k to count for distance between s[m-1] right side required distance 
			int seats_available_right = n - prev - k;
			if (seats_available_right >= min_seats_new_person_needs_plus_left_side_distancing)
				sum = sum + ((seats_available_right + min_seats_new_person_needs_plus_left_side_distancing - 1) / min_seats_new_person_needs_plus_left_side_distancing);
			
			Console.WriteLine (sum);
		}

		public void solve(){
			int n = 10;
			int k = 1;
			int m = 2;
			var s = new int[]{ 2, 6 };

			var seats = new int[n];
			for (int i = 0; i < m; ++i) {
				int person_seat = s [i] - 1;
				int l = Math.Max (person_seat - k, 0);
				int r = person_seat + k + 1;

				seats [l] = 1;
				if (r < n)
					seats [r] = -1;
			}

			int sum = 0;
			int ans = 0;
			for (int i = 0; i < n; ++i) {
				sum = sum + seats [i];
				if (sum == 0) {
					// i can sit here
					ans++;
					sum = 1;
					int r = i + k + 1;
					if (r < n)
						seats [r] = seats [r] - 1;
				}
			}

			Console.WriteLine (ans);
		}
	}
}