using System;
using System.Collections.Generic;

// https://leetcode.com/problems/cheapest-flights-within-k-stops/
namespace _csharp
{
	public class _787_cheapest_flights_within_k_stops
	{
		public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) {
			if(src==dst)
				return 0;        

			// key: source | value: list of edges.
			Dictionary<int,List<int>> edges = new Dictionary<int,List<int>>();

			int m = flights.Length;
			for(int i=0;i<m;++i){
				int source = flights[i][0];

				if(!edges.ContainsKey(source)){
					edges.Add(source, new List<int>());
				}

				edges[source].Add(i);            
			}

			return bfs(n,flights,src,dst,K,edges);
		}

		private int bfs(int n, int[][] flights, int src, int dst, int K, Dictionary<int,List<int>> edges){
			bool reachedDestination = false;
			int MinPrice = int.MaxValue;

			// node, hops, price
			Queue<Tuple<int,int,int>> qu = new Queue<Tuple<int,int,int>>();

			qu.Enqueue(Tuple.Create(src,0,0));

			while(qu.Count>0){
				var tup = qu.Dequeue();

				int source = tup.Item1;
				int hop = tup.Item2;
				int price = tup.Item3;

				if(!edges.ContainsKey(source))
					continue;

				List<int> edgesSource = edges[source];

				foreach(int e in edgesSource){
					int nodeSource = flights[e][0];
					int nodeDestination = flights[e][1];
					int nodePrice = flights[e][2];

					if(nodePrice+price>=MinPrice){
						// no need for further comparison
						continue;
					}

					if(nodeDestination == dst){
						reachedDestination=true;
						MinPrice = Math.Min(MinPrice, nodePrice + price);
						continue;
					}

					if(hop>=K){
						// I cannot continue on this route
						continue;
					}

					qu.Enqueue(Tuple.Create(nodeDestination,hop+1,nodePrice+price));
				}
			}

			return reachedDestination ? MinPrice : -1;
		}
	}
}

