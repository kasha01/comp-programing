using System;
using System.Collections.Generic;

// https://leetcode.com/problems/car-pooling/
namespace _csharp
{
	public class _1094_car_pooling
	{
		// O(NLogN) for unlimited constraints on trips.Length
		public bool CarPooling2(int[][] trips, int capacity) {
			List<Tuple<int,int>> list = new List<Tuple<int,int>>();

			for(int i=0;i<trips.Length;++i){
				int passengers = trips[i][0];
				int start = trips[i][1];
				int end = trips[i][2];

				list.Add(Tuple.Create(start,passengers));
				list.Add(Tuple.Create(end,-passengers));
			}

			// sort by trip location
			list.Sort((a,b) => SortMe(a,b));

			int sum_passengers=0;
			for(int i=0;i<list.Count;++i){
				sum_passengers = sum_passengers + list[i].Item2;
				if(sum_passengers > capacity)
					return false;
			}

			return true;
		}

		private static int SortMe(Tuple<int,int> a, Tuple<int,int> b){
			if(a.Item1 < b.Item1) return -1;

			if(a.Item1 > b.Item1) return 1;

			// sort by passengers (b/c I want to drop largest passengers first (passengers count here are in -ve) 
			// before pick new ones at the same end point)
			if(a.Item2 < b.Item2) return -1;
			if(a.Item2 > b.Item2) return 1;

			return 0;
		}

		// O(N) for small trip constraints
		public bool CarPooling(int[][] trips, int capacity) {
			int[] arr = new int[1001];
			int start_trip=int.MaxValue; int end_trip=0;

			for(int i=0;i<trips.Length;++i){
				int passengers = trips[i][0];
				int start = trips[i][1];
				int end = trips[i][2];

				start_trip = Math.Min(start_trip,start);
				end_trip = Math.Max(end_trip,end);

				arr[start] = arr[start] + passengers;
				arr[end] = arr[end] - passengers;
			}

			int sum_passengers=0;
			for(int i=start_trip;i<=end_trip;++i){
				sum_passengers = sum_passengers + arr[i];
				if(sum_passengers > capacity)
					return false;
			}

			return true;
		}
	}
}

