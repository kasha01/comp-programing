using System;

// https://leetcode.com/problems/trapping-rain-water/
namespace _csharp
{
	public class _42_trapping_rain_water
	{
		public int Trap(int[] height) {
			int n = height.Length;
			int[] left = new int[n];
			int[] right = new int[n];

			int maxSoFar = 0;
			for(int i=0;i<n;++i){
				left[i] = maxSoFar;
				maxSoFar = Math.Max(maxSoFar, height[i]);
			}

			maxSoFar = 0;
			for(int i=n-1;i>=0;--i){
				right[i] = maxSoFar;
				maxSoFar = Math.Max(maxSoFar, height[i]);
			}

			int sum = 0;
			for(int i=0;i<n;++i){
				int side = Math.Min(left[i],right[i]);
				if(side - height[i] > 0)
					sum = sum + (side - height[i]);
			}

			return sum;
		}
	}
}