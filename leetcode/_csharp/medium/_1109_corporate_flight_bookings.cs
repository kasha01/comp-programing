using System;

// https://leetcode.com/problems/corporate-flight-bookings/
namespace _csharp
{
	public class _1109_corporate_flight_bookings
	{
		public int[] CorpFlightBookings(int[][] bookings, int n) {
			int[] arr = new int[n];

			int m=bookings.Length;
			for(int i=0;i<m;++i){
				int first = bookings[i][0];
				int last = bookings[i][1];
				int seat = bookings[i][2];

				arr[first-1] = arr[first-1] + seat;

				if(last<n){
					arr[last] = arr[last] + (seat*-1);
				}
			}

			for(int i=1;i<n;++i){
				arr[i] = arr[i] + arr[i-1];
			}

			return arr;
		}
	}
}

