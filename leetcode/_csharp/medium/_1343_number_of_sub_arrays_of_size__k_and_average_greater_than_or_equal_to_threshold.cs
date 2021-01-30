using System;

// https://leetcode.com/problems/number-of-sub-arrays-of-size-k-and-average-greater-than-or-equal-to-threshold/
namespace _csharp
{
	public class _1343_number_of_sub_arrays_of_size__k_and_average_greater_than_or_equal_to_threshold
	{
		public int NumOfSubarrays(int[] arr, int k, int threshold) {
			int n = arr.Length;

			// compute initial sum upto k-1. as line 21 step would get that.
			int sum = 0;
			for(int a=0;a<k-1;++a){
				sum = sum + arr[a];
			}

			int c=0;
			int i=0;
			int j = k-1;
			while(j<n){
				// j is withink the window size k. add it to the sum.
				sum = sum+arr[j];

				if(sum/k >= threshold){
					++c;
				}

				// i is out of the window size k. subract it from the sum
				sum = sum - arr[i];
				++i;
				++j;
			}

			return c;
		}
	}
}

