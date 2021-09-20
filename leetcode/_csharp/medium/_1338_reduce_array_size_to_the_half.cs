using System;
using System.Collections.Generic;

// https://leetcode.com/problems/reduce-array-size-to-the-half/
namespace _csharp
{
	public class _1338_reduce_array_size_to_the_half
	{
		public int MinSetSize(int[] arr) {
			Dictionary<int,int> map = new Dictionary<int,int> ();

			foreach(int i in arr){
				if(!map.ContainsKey(i)){
					map.Add (i, 0);
				}
				map [i]++;
			}

			List<int> list = new List<int> (map.Values);
			list.Sort ();

			int c = 0;
			int halfSize = arr.Length / 2;
			int n = list.Count;
			for (int i = n - 1; i >= 0; --i) {
				++c;
				halfSize = halfSize - list [i];
				if (halfSize <= 0)
					break;
			}

			return c;
		}
	}
}

