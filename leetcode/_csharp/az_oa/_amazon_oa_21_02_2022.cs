using System;

// https://leetcode.com/discuss/interview-question/1789737/amazon-OA
namespace _csharp
{
	public class _amazon_oa_21_02_2022
	{
		// Question 1
		// minimum energy needed to play. you can use armor to reduce damage.
		public void armor(){
			// energyNeeded = sumOfEnergy + 1 - min(energy[i],armor) 
			var arr = new int[]{ 1, 2, 6, 7 };
			int armor = 5;
			int n = arr.Length;

			int sum = 0;
			int maxEnergy = 0;
			foreach (int e in arr) {
				sum = sum + e;
				maxEnergy = Math.Max (e, maxEnergy);
			}

			var energy = sum + 1 - Math.Min (maxEnergy, armor);
			Console.WriteLine (energy);
		}

		// Question 2
		// month at which the average stock difference is minimum.
		public void stock_price(){
			var arr = new int[]{1,3,2,3};
			int n = arr.Length;

			if (n == 0) {
				Console.WriteLine (0);
				return;
			}

			int sum = 0;
			for (int i = 0; i <n; ++i) {
				sum = sum + arr[i];
			}

			int left = 0;
			int min_net_price_month = -1;
			int diff = int.MaxValue;
			for (int month = 0; month < n; ++month) {
				left = left + arr [month];

				int avg1 = left / (month + 1);
				int avg2 = month == n-1 ? 0 : (sum-left) / (n - 1 - month);

				int d = Math.Abs (avg2 - avg1);
				if (d < diff) {
					diff = d;
					min_net_price_month = month + 1;
				}
			}

			Console.WriteLine (min_net_price_month);
		}
	}
}

