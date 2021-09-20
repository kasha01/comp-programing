using System;
using System.Collections.Generic;

// https://leetcode.com/problems/two-city-scheduling/
namespace _csharp
{
	public class _1029_two_city_scheduling
	{
		public int TwoCitySchedCost(int[][] costs) {
			List<Tuple<int,int>> list = new List<Tuple<int,int>>();

			int n = costs.Length; int m = (int)n/2;
			for(int i=0;i<n;++i){
				list.Add(Tuple.Create(costs[i][0],costs[i][1]));
			}

			// sort desc
			list.Sort(new MyComparer());

			int k=0; int sum=0; int ca=0; int cb=0;
			for(k=0;k<n;++k){
				var tup = list[k];
				int s=0;
				if(cb==m){
					// everything must go to a
					s = tup.Item1; ca++;
				}
				else if(ca==m){
					// everything must go to b
					s = tup.Item2; cb++;
				}
				else{
					if(tup.Item1 <= tup.Item2){
						s=tup.Item1; ca++;
					}
					else{
						s=tup.Item2; cb++;
					}
				}

				sum = sum + s;
			}

			return sum;
		}

		private class MyComparer : IComparer<Tuple<int,int>>{
			public int Compare(Tuple<int,int> x, Tuple<int,int> y){
				int xabs = Math.Abs(x.Item1 - x.Item2);
				int yabs = Math.Abs(y.Item1 - y.Item2);

				if(xabs > yabs) return -1;
				if(xabs < yabs) return 1;
				return 0;
			}
		}
	}
}