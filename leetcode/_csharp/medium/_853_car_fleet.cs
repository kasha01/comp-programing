using System;

// https://leetcode.com/problems/car-fleet/
namespace _csharp
{
	public class _853_car_fleet
	{
		public int CarFleet(int target, int[] position, int[] speed) {
			int n = position.Length;

			// position | speed
			var arr = new Tuple<int,int>[n];        
			for(int i=0;i<n;++i){
				arr[i] = Tuple.Create(position[i], speed[i]);
			}

			Array.Sort(arr, (a,b)=>SortAscn(a,b));

			int fleet=1;
			double leading_car_time = (double)(target-arr[n-1].Item1)/arr[n-1].Item2;
			for(int i=n-2;i>=0;--i){
				// time to reach target
				double time = (double)(target-arr[i].Item1)/arr[i].Item2;
				if(time <= leading_car_time){
					// this car (t) is faster than the car ahead. so it will eventually join it, making a fleet.
					// do nothing.
				}
				else{
					// this car (t) is slower than the car ahead. so there is no way it is joining the fleet.
					// count it as a separate fleet, and set its time.
					fleet++;
					leading_car_time = time;
				}
			}

			return fleet;       
		}

		private static int SortAscn(Tuple<int,int> a, Tuple<int,int> b){
			int p1 = a.Item1;
			int p2 = b.Item1;

			if(p1<p2) return -1;
			if(p1>p2) return 1;

			return 0;
		}
	}
}