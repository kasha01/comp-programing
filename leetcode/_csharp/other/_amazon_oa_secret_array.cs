using System;

// https://leetcode.com/discuss/interview-question/1332322/amazon-online-assessment-july-2021-secret-array

/*
 * An array is said to be analogous to the secret array if all of the following conditions are true:
• The length of the array is equal to the length of the secret array.
• Each integer in the array lies in the interval [lowerBound, upperBound].
• The difference between each pair of consecutive integers of the array must be equal to the difference between the respective pair of consecutive integers in the secret array. In other words, let the secret array be [s[0], s[1],..., s[n-1]] and let the analogous array be [a[0], a[1],..., a[n-1]], then (a[i-1] - a[i]) must be equal to (s[i-1] - s[i]) for each i from 1 to n -1.

Given the value of integers lowerBound and upperBound, inclusive, and the array of differences between each pair of consecutive integers of the secret array, find the number of arrays that are analogous to the secret array. If there is no array analogous to the secret array, return 0.

For example:
consecutiveDifference = [-2, -1, -2, 5]
lowerBound = 3
upperBound = 10

Note that none of the values is out of the bound. All possible analogous arrays are:
[3, 5, 6, 8, 3]
[4, 6, 7, 9, 4]
[5, 7, 8, 10, 5]

Tha answer is 3.
*/
namespace _csharp
{
	public class _amazon_oa_secret_array
	{
		public void solve(){
			int upperBound=10;
			int lowerBound=3;
			var consecutive = new int[]{ -2, -1, -2, 5 };
			int n = consecutive.Length;

			int maxDiff = int.MinValue;
			int minDiff = int.MaxValue;

			int sum = 0;
			for (int i = 0; i < n; ++i) {
				sum = sum + consecutive [i];
				maxDiff = Math.Max (sum, maxDiff);
				minDiff = Math.Min (sum, minDiff);
			}

			// notice here. the minDiff increases the numbers. check this. if I picked 3 as the first item in the secret array. after applying the
			// consecutive array rule: the next item would have to have a -2 diff from the 3, that is 3-x = -2 => x=5 notice x increases from 3.
			// therefore I apply the minDiff to upper bound to guarantee I don't exceed the upperbound and vice versa for lowerBound.
			int up = upperBound + minDiff;	
			int low = lowerBound + maxDiff;
			int validUpperBound = up <= upperBound ? up : upperBound;
			int validLowerBound = low >= lowerBound ? low : lowerBound;

			// r is how many numbers I can fit between the new upper and the new lower bounds.
			int r = validUpperBound - validLowerBound;
			int res = r >= 0 ? r + 1 : 0;

			Console.WriteLine (res);
		}
	}
}
