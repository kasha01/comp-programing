using System;

// https://leetcode.com/problems/maximum-height-by-stacking-cuboids/
namespace _csharp
{
	public class _1691_maximum_height_by_stacking_cuboids
	{
		public int MaxHeight(int[][] cuboids) {
			int n = cuboids.Length;
			for(int i=0;i<n;++i){
				Array.Sort(cuboids[i]);
			}

			Array.Sort(cuboids, (a,b) => SortMe(a,b));

			// LIS
			int ans = 0;
			int[] memo = new int[n];
			for(int i=0;i<n;++i){
				memo[i] = cuboids[i][2];
				for(int j=0;j<i;++j){
					if( cuboids[i][0] >= cuboids[j][0] && 
						cuboids[i][1] >= cuboids[j][1] && 
						cuboids[i][2] >= cuboids[j][2] 
					)
					{
						memo[i] = Math.Max(memo[i], memo[j] + cuboids[i][2]);
					}
				}

				ans = Math.Max(memo[i],ans);
			}

			return ans;

		}

		public static int SortMe(int[] a, int[] b){
			if(a[0]!=b[0])
				return a[0] < b[0] ? -1 : 1;

			if(a[1]!=b[1])
				return a[1] < b[1] ? -1 : 1;

			if(a[2]!=b[2])
				return a[2] < b[2] ? -1 : 1;

			return 0;            
		}
	}
}