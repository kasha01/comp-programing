using System;

// https://leetcode.com/problems/max-increase-to-keep-city-skyline/
namespace _csharp
{
	public class _807_max_increase_to_keep_city_skyline
	{
		public int MaxIncreaseKeepingSkyline(int[][] grid) {
			int n = grid.Length;
			int m = grid[0].Length;

			int[] horizontal = new int[n];
			int[] vertical = new int[m];

			for(int i=0;i<n;++i){
				int h = 0;
				for(int j=0;j<m;++j){
					int x = grid[i][j];
					vertical[j] = Math.Max(vertical[j],x);
					h = Math.Max(h,x);
				}
				horizontal[i] = h;
			}

			int sum = 0;
			for(int i=0;i<n;++i){
				int maxH = horizontal[i];
				for(int j=0;j<m;++j){
					int x = grid[i][j];
					int maxV = vertical[j];
					if(x==maxV || x==maxH){
						// skip
					}
					else{
						int minValue = Math.Min(maxV,maxH);
						sum = sum + (minValue-x);
					}
				}
			}

			return sum;
		}
	}
}

