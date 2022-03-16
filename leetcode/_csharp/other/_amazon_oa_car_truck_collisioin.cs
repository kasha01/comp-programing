using System;

// https://leetcode.com/discuss/interview-question/928067/Amazon-or-Internship
namespace _csharp
{
	public class _amazon_oa_car_truck_collisioin
	{
		/*
		 * notice how 1st truck T can potentially collide with 8 cars.
		 * 2nd car C can potentially collide with 7 cars
		 * 3rd car with 6 and so on...8+7+6+5+4+3+2+1 => 36
		*/

		public void solve(){
			string a = "TCCBCTTB";
			string b = "BTCCBBTT";

			int total_probabilities = 0;
			int trucks = 0;
			int collisions = 0;
			for (int i = 0; i < a.Length; ++i) {
				if (a [i] == 'T')
					trucks++;

				if (b [i] == 'T')
					collisions = collisions + trucks;

				total_probabilities = total_probabilities + (i + 1);
			}

			Console.WriteLine (collisions / total_probabilities);
		}
	}
}