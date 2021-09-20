using System;
using System.Collections.Generic;

// https://leetcode.com/problems/avoid-flood-in-the-city/
namespace _csharp
{
	public class _1488_avoid_flood_in_the_city
	{
		public int[] AvoidFlood(int[] rains) {
			List<int> dryDays = new List<int>();
			Dictionary<int,int> fullLakes = new Dictionary<int,int>();
			int n = rains.Length;
			int[] ans = new int[n];
			for (int i = 0; i < n; ++i) {
				ans [i] = 1;
			}

			for(int i=0;i<n;++i){
				int lakeWithRain = rains[i];
				if(lakeWithRain==0){
					// dry day.
					dryDays.Add(i);
				}
				else{
					if(fullLakes.ContainsKey(lakeWithRain)){
						// lake can potentially flood

						int dryDay = -1;
						int rainDay = fullLakes[lakeWithRain];
						// greedy. find the first eligible dry day to use. since the earlier the dry days,
						// the less lakes they proceed as I can only dry lakes preceeding the dry day
						// so I better use the earlies ones.
						for(int j=0;j<dryDays.Count;++j){
							if(dryDays[j] > rainDay){
								// dry day found. so I can dry the lake
								dryDay = dryDays[j];
								dryDays.RemoveAt(j);    // remove dry day as it will be used to dry lake.
								break;
							}
						}

						// no dry day. flood.
						if(dryDay==-1) return new int[0];

						fullLakes[lakeWithRain] = i;
						ans[dryDay] = lakeWithRain;
						ans[i]=-1;
					}
					else{
						ans[i] = -1;
						fullLakes.Add(lakeWithRain,i);
					}
				}
			}

			return ans;
		}
	}
}