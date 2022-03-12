using System;
using System.Collections.Generic;


// https://leetcode.com/discuss/interview-question/1754686/Amazon-or-OA
namespace _csharp
{
	public class _amazon_oa_power_scores_21_01_2022
	{
		public void solve(){
			int[] arr = new int[]{ 2, 3, 2, 1 };
			int n = arr.Length;

			var presum = new int[n];
			var posElementProdSum = new int[n];
			int sum = 0;
			int subArraySum = 0;
			for (int i = 0; i < n; ++i) {
				sum = sum + arr [i];
				subArraySum = subArraySum + (arr [i] * (i + 1));

				presum [i] = sum;
				posElementProdSum [i] = subArraySum;
			}

			var posElementProdSumReverse = new int[n];
			int subArraySumReverse = 0;
			for (int i = n-1; i >= 0; --i) {
				subArraySumReverse = subArraySumReverse + (arr [i] * (n - i));

				posElementProdSumReverse [n-i-1] = subArraySumReverse;
			}

			int totalScore = 0;
			Stack<int> stack = new Stack<int> ();
			int k = 0;
			while (k < n) {
				if (stack.Count == 0 || arr [stack.Peek ()] < arr [k]) {
					stack.Push (k);
					++k;
				} else {
					int minElementIndex = stack.Pop ();
					int minElement = arr [minElementIndex];

					int leftIndex = stack.Count > 0 ? stack.Peek () : -1;	// leftIndex: index of item not within my range
					int rightIndex = k;

					int leftCount = minElementIndex - leftIndex;	// count of item left of minElementIndex including minElement
					int rightCount = rightIndex - minElementIndex;	// count of item right of minElementIndex including minElement

					int shiftedPosEleProdSumLeft = 
						getSubSum (posElementProdSum, leftIndex + 1, minElementIndex) -
						getSubSum (presum, leftIndex + 1, minElementIndex) * (leftIndex + 1);

					int currRangeScoreLeft = rightCount * minElement * shiftedPosEleProdSumLeft;
					totalScore = totalScore + currRangeScoreLeft;

					int shiftedPosEleProdSumRight = 
						getSubSum (posElementProdSumReverse, n - rightIndex, n - minElementIndex - 2) -
						getSubSum (presum, minElementIndex + 1, rightIndex - 1) * (n - rightIndex);

					int currRangeScoreRight = leftCount * minElement * shiftedPosEleProdSumRight;
					totalScore = totalScore + currRangeScoreRight;
				}
			}

			while (stack.Count > 0) {
				int minElementIndex = stack.Pop ();
				int minElement = arr [minElementIndex];

				int leftIndex = stack.Count > 0 ? stack.Peek () : -1;	// leftIndex: index of item not within my range
				int rightIndex = n;

				int leftCount = minElementIndex - leftIndex;	// count of item left of minElementIndex including minElement
				int rightCount = rightIndex - minElementIndex;	// count of item right of minElementIndex including minElement

				int shiftedPosEleProdSumLeft = 
					getSubSum (posElementProdSum, leftIndex + 1, minElementIndex) -
					getSubSum (presum, leftIndex + 1, minElementIndex) * (leftIndex + 1);

				int currRangeScoreLeft = rightCount * minElement * shiftedPosEleProdSumLeft;
				totalScore = totalScore + currRangeScoreLeft;

				int shiftedPosEleProdSumRight = 
					getSubSum (posElementProdSumReverse, n - rightIndex, n - minElementIndex - 2) -
					getSubSum (presum, minElementIndex + 1, rightIndex - 1) * (n - rightIndex);

				int currRangeScoreRight = leftCount * minElement * shiftedPosEleProdSumRight;
				totalScore = totalScore + currRangeScoreRight;
			}

			Console.WriteLine (totalScore);

		}

		private int getSubSum(int[] arr, int l, int r){
			if (l > r)
				return 0;
			
			return arr [r] - (l - 1 >= 0 ? arr [l - 1] : 0);
		}
	}
}