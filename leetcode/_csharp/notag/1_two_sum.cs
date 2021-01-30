using System;
using System.Collections.Generic;

// https://leetcode.com/problems/two-sum/
namespace _csharp
{
	public class _1_two_sum
	{
		public void driver() {
			int[] num = {3,2,4};
			int t = 6;
			int[] result = TwoSum (num, t);
			Console.WriteLine (result [0] + " " + result [1]);
		}

		public int[] TwoSum(int[] nums, int target) {
			int[] result = new int[2];
			int n = nums.Length;

			Dictionary<int, List<int>> map = new Dictionary<int, List<int>> ();
			for (int i=0; i<n; ++i) {
				int x = nums [i];
				if (map.ContainsKey (x)) {
					map [x].Add (i);
				} else {
					map.Add (x, new List<int> (){ i });
				}
			}

			int i1 = -1;
			int i2 = -1;
			for (int i=0; i < n; ++i) {
				int a = nums [i];
				int b = target - a;

				if (a == b && map[a].Count > 1) {
					i1 = i;
					i2 = map [a] [1];
					break;
				} else if (a != b && map.ContainsKey(b)) {
					i1 = i;
					i2 = map [b] [0];
					break;
				}
			}

			result[0] = i1;
			result[1] = i2;
			return result;
		}

	}
}

