using System;

// https://practice.geeksforgeeks.org/problems/smallest-positive-missing-number-1587115621/1#
namespace GeeksForGeeks_csharp
{
	public class smallest_positive_missing_number
	{
		//Function to find the smallest positive number missing from the array.
		public int missingNumber(int[] arr, int n) 
		{ 
			// turn all negatives and zeros into n+1, so we don't confuse them into
			// a flagged value
			for(int i=0;i<n;++i){
				if(arr[i] <= 0)
					arr[i] = n+1;
			}

			for(int i=0;i<n;++i){
				// get original value which will always be the absolute value. 
				int val = Math.Abs(arr[i]);

				// if val is within array index and it not flagged(not negative)
				// negate its index value arr[val-1];
				if(val <= n)
					arr[val-1] = arr[val-1] > 0 ? arr[val-1] * -1 : arr[val-1];
			}

			for(int i=0;i<n;++i){
				if(arr[i] > 0)
					return i+1;
			}

			return n+1;
		}		
	}
}