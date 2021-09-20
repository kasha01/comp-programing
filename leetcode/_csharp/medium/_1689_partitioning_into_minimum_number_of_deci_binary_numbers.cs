using System;

// https://leetcode.com/problems/partitioning-into-minimum-number-of-deci-binary-numbers/
namespace _csharp
{
	public class _1689_partitioning_into_minimum_number_of_deci_binary_numbers
	{
		public int MinPartitions(string n) {
			int maxDigit=0;

			foreach(char c in n){
				int x = c-'0';
				maxDigit = Math.Max(maxDigit,x);
			}

			return maxDigit;        
		}
	}
}