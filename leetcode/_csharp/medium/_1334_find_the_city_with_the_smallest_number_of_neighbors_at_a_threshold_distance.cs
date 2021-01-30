using System;

// https://leetcode.com/problems/find-the-city-with-the-smallest-number-of-neighbors-at-a-threshold-distance/
namespace _csharp
{
	public class _1334_find_the_city_with_the_smallest_number_of_neighbors_at_a_threshold_distance
	{
		public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
			int[,] dist = new int[n,n];        

			int m = edges.Length;

			for(int i=0;i<m;++i){
				int fr = edges[i][0];
				int to = edges[i][1];
				int w = edges[i][2];
				dist[fr,to] = w;
				dist[to,fr] = w;
			}

			for (int i = 0; i < n; ++i) {
				for (int j = 0; j < n; ++j) {
					if (i != j && dist [i, j] == 0) {
						dist [i, j] = int.MaxValue;
					} 
				}
			}

			for(int k=0;k<n;++k){
				for(int i=0;i<n;++i){
					for(int j=0;j<n;++j){
						if (dist[i,k] == int.MaxValue || dist[k,j] == int.MaxValue){
							continue;
						}

						int distanceviaIntermediateNode = dist[i,k] + dist[k,j];
						if(dist[i,j] > distanceviaIntermediateNode){
							dist[i,j] = distanceviaIntermediateNode;
						}
					}
				}
			}

			int cityCount=int.MaxValue;
			int cityId = -1;
			for(int i=0;i<n;++i){
				int neighbors = 0;
				for(int j=0;j<n;++j){
					if(i==j || dist[i,j] > distanceThreshold){
						continue;
					}
					neighbors++;
				}

				if(neighbors < cityCount){
					cityCount = neighbors;
					cityId = i;
				}
				else if(cityCount == neighbors){
					cityId = Math.Max(cityId,i);
				}
			}

			return cityId;
		}
	}
}

