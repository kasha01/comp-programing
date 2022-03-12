﻿using System;

// https://leetcode.com/discuss/interview-question/1789737/amazon-OA
namespace _csharp
{
	public class _amazon_oa_21_02_2022
	{
		// Question 1
		// minimum energy needed to play. you can use armor to reduce damage.
		public void armor(){
			var arr = new int[]{ 1, 2, 6, 7 };
			int armor = 5;
			int n = arr.Length;

			int energy = 1;		// energy i need
			int energy_so_far = 1;
			int when_to_use_armor = 0;

			for (int i = 0; i < n; ++i) {
				// i found a power greater than armor. so use armor here.
				if (arr [i] >= armor) {
					when_to_use_armor = i;
					break;
				}

				// get me the largest power
				if(arr[i] > arr[when_to_use_armor]){
					when_to_use_armor = i;
				}
			}

			for (int i = 0; i < n; ++i) {
				int en = arr [i];

				if (when_to_use_armor == i)
					en = en - Math.Min (en, armor);
					
				if (en >= energy_so_far) {
					int diff = en - energy_so_far;
					energy_so_far = 1;		// I consumed all my energy, so reset energy_so_far to 1
					energy = energy + diff + 1;
				} else {
					energy_so_far = energy_so_far - en;
				}
			}

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

			int[] left = new int[n];
			left [0] = arr [0];
			for (int i = 1; i < n; ++i) {
				left [i] = left [i - 1] + arr [i];
			}

			int[] right = new int[n];
			right [n - 1] = arr [n - 1];
			for (int i = n-2; i >=0; --i) {
				right [i] = right [i + 1] + arr [i];
			}

			int min_net_price_month = -1;
			int diff = int.MaxValue;
			for (int month = 0; month < n-1; ++month) {
				int avg1 = left [month] / (month + 1);
				int avg2 = right [month + 1] / (n - 1 - month);

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

