using System;

// https://leetcode.com/problems/find-greatest-common-divisor-of-array/
namespace _csharp
{
	public class _1979_find_greatest_common_divisor_of_array
	{
		public int FindGCD(int[] nums) {
			int max = -1;    
			int min = 2000;

			foreach(int x in nums){
				max = Math.Max(max, x);
				min = Math.Min(min, x);
			}

			return gcd(min,max);
		}

		private int gcd(int x, int y){
			return x==0 ? y : gcd(y%x,x);
		}
	}
}

