using System;

// https://leetcode.com/problems/angle-between-hands-of-a-clock/
namespace _csharp
{
	public class _1344_angle_between_hands_of_a_clock
	{
		public double AngleClock(int hour, int minutes) {
			double hr = (double) hour;
			double mn = (double) minutes;

			// convert hour hand to minutes
			double hour_hand_to_minutes = hr == 12 ? 0 : (hr/12)*60;

			// hour hand is shifted by minutes
			double hour_hand = ((mn/60) * 5) + hour_hand_to_minutes;

			double hour_angle = (hour_hand/60) * 360;
			double minute_angle = (mn/60) * 360;

			double ans = Math.Abs(hour_angle - minute_angle);   

			// credits to sankalpdayal5
			if(ans>180)
				ans = 360 - ans;

			return ans;
		}
	}
}

