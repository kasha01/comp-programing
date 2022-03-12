using System;
using System.Collections.Generic;

// https://leetcode.com/problems/max-points-on-a-line/
namespace _csharp
{
	public class _149_max_points_on_a_line
	{
		public int MaxPoints(int[][] points) {
			int n = points.Length;
			int ans = 1;

			for(int i=0;i<n;++i){
				// line is defined by a point(base point) and a slope.
				var map = new Dictionary<Tuple<int,int>, int> ();   // reset slope map on every new base point. 

				int x1 = points[i][0];
				int y1 = points[i][1];
				for(int j=i+1;j<n;++j){
					int x2 = points[j][0];
					int y2 = points[j][1];

					int delta_x = x2-x1;
					int delta_y = y2-y1;

					int _gcd = gcd(delta_x,delta_y);

					delta_x = delta_x/_gcd;
					delta_y = delta_y/_gcd;

					var tup = Tuple.Create(delta_x,delta_y);
					if(!map.ContainsKey(tup)){
						map.Add(tup,0);
					}

					map[tup]++;

					ans = Math.Max(ans, map[tup]+1);
				}
			}

			return ans;
		}

		private int gcd(int a, int b){
			if(a==0) return b;
			return gcd(b%a,a);
		}
	}
}