using System;

// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
namespace _csharp
{
	public class _167_two_sum_ii_input_array_is_sorted
	{
		public int[] TwoSum(int[] numbers, int target) {
			int i=0; int j=numbers.Length-1;

			while(i<j){
				int sum = numbers[i] + numbers[j];
				if(sum > target)
					--j;
				else if(sum < target)
					++i;
				else
					return new int[]{i+1,j+1};
			}

			return new int[0];
		}
	}
}