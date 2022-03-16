using System;
using System.Collections.Generic;

// https://leetcode.com/problems/maximum-units-on-a-truck/
namespace _csharp
{
	public class _1710_maximum_units_on_a_truck
	{
		// this is an O(N) solution.
		public int MaximumUnits_2(int[][] boxTypes, int truckSize) {
			int maxUnits = 1000;
			var freq_units = new int[maxUnits+1];   // number of boxes that have i units

			foreach(var box in boxTypes){
				int num_boxes = box[0];
				int num_units_in_each_box = box[1];

				freq_units[num_units_in_each_box] = freq_units[num_units_in_each_box] + num_boxes;
			}

			int sum = 0;
			for(int units=maxUnits;units>=0 && truckSize>0;--units){
				int num_boxes_i_can_load_in_truck = Math.Min(freq_units[units], truckSize);
				sum = sum + (num_boxes_i_can_load_in_truck * units);
				truckSize = truckSize - num_boxes_i_can_load_in_truck;
			}

			return sum;
		}

		// O(N LOG N) solution
		public int MaximumUnits(int[][] boxTypes, int truckSize) {
			// number of boxes | number of units per box.
			int n = boxTypes.Length;
			var arr = new Tuple<int,int>[n];

			for(int i=0;i<n;++i){
				arr[i] = Tuple.Create(boxTypes[i][0],boxTypes[i][1]);
			}

			Array.Sort(arr, (i1,i2) => SortMe(i1,i2));

			int units_sum = 0; int boxes_loaded=0;
			for(int i=0;i<n;++i){
				if(truckSize == boxes_loaded) break;

				var number_of_boxes = arr[i].Item1;
				var units = arr[i].Item2;

				if(number_of_boxes+boxes_loaded < truckSize){
					// load all boxes
					boxes_loaded = number_of_boxes+boxes_loaded;
					units_sum = units_sum + (number_of_boxes*units);
				}
				else{
					// load some of the boxes and exit.
					int boxes_i_can_take = truckSize - boxes_loaded;
					units_sum = units_sum + (boxes_i_can_take*units);
					break;
				}
			}

			return units_sum;        
		}

		private static int SortMe(Tuple<int,int> a, Tuple<int,int> b){
			int unit_a = a.Item2; int unit_b = b.Item2;

			if(unit_a > unit_b) return -1;
			if(unit_a < unit_b) return 1;
			return 0;
		}
	}
}