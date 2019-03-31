using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/maximize-the-array/0
namespace GeeksForGeeks_csharp
{
	public class maximize_the_array
	{
		public static int sort_by_value(KeyValuePair<int,int> a, KeyValuePair<int,int> b){
			// desc
			if (a.Key > b.Key)
				return -1;
			else
				return 1;
		}

		public static int sort_by_index(KeyValuePair<int,int> a, KeyValuePair<int,int> b){
			if (a.Value < b.Value)
				return -1;
			else
				return 1;
		}

		public void solve ()
		{
			// value | input index
			List<KeyValuePair<int,int>> list = new List<KeyValuePair<int,int>>();
			int[] arr1 = { 5 ,6 ,9 ,3 ,7 ,4 ,5};
			int[] arr2 = { 2 ,5 ,4 ,7 ,4 ,4 ,3 };

			int n = 7;

			ISet<int> set = new HashSet<int> ();

			int ii = 0;
			for (int i = 0; i < n; ++i) {
				if (!set.Contains (arr2 [i])) {					
					set.Add (arr2 [i]);
					list.Add (new KeyValuePair<int, int> (arr2 [i], ii));
					ii++;
				}
			}

			for (int i = 0; i < n; ++i) {
				if(!set.Contains(arr1[i])){
					set.Add (arr1 [i]);
					list.Add (new KeyValuePair<int, int> (arr1 [i], ii));
					++ii;
				}
			}

			list.Sort (sort_by_value);
			list.RemoveRange(n, list.Count - n);
			list.Sort (sort_by_index);

			for (int i = 0; i < n; ++i) {
				Console.Write(list [i].Key + " ");
			}
		}
	}
}

