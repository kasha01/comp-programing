using System;

// https://leetcode.com/problems/divide-two-integers/
namespace _csharp
{
	/*
	 * NOT MY SOLUTION.
	 * CREDIT TO:
	 * https://www.youtube.com/watch?v=bdxJHWIyyqI
	 * https://www.geeksforgeeks.org/divide-two-integers-without-using-multiplication-division-mod-operator/
	*/
	public class _29_divide_two_integers
	{
		public long divide(long dividend, long divisor) { 
			int sign = ((dividend < 0) ^ (divisor < 0)) ? -1 : 1; 

			dividend = Math.Abs(dividend); 
			divisor = Math.Abs(divisor); 

			long quotient = 0, temp = 0; 

			for (int i = 31; i >= 0; --i) { 

				if (temp + (divisor << i) <= dividend) { 
					temp += divisor << i; 
					long l = 1;
					quotient |= l << i; 
				} 
			} 

			long result = 0;
			if (quotient < int.MaxValue) {
				if (sign < 0) {
					result = 0 - quotient; 
				} else {
					result = quotient;
				}
			}
			else if (quotient == int.MaxValue) {
				if (sign == -1) {
					result = int.MinValue;
				}
				result = int.MaxValue;
			}

			return result;
		}
	}
}

