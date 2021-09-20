using System;
using System.Collections.Generic;

// https://leetcode.com/problems/my-calendar-iii/
namespace _csharp
{
	public class _732_my_calendar_iii
	{
		public class MyCalendarThree {

			SortedDictionary<int,int> map;

			public MyCalendarThree() {
				map = new SortedDictionary<int,int>();
			}

			public int Book(int start, int end) {
				if(!map.ContainsKey(start)) map.Add(start,0);
				if(!map.ContainsKey(end)) map.Add(end,0);

				map[start]++; map[end]--;

				int maxBooking = 0;
				int booking = 0;
				foreach(var kvp in map){
					booking = booking + kvp.Value;
					maxBooking = Math.Max(maxBooking,booking);
				}
				return maxBooking;
			}
		}
	}
}

