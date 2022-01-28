using System;
using System.Collections.Generic;

// https://leetcode.com/problems/relative-sort-array/
namespace _csharp
{
	public class _1122_relative_sort_array
	{
		public int[] RelativeSortArray(int[] arr1, int[] arr2) {
			Dictionary<int,int> map = new Dictionary<int,int>();
			for(int i=0;i<arr2.Length;++i){
				map.Add(arr2[i],i);
			}

			Array.Sort(arr1, (i1,i2) => Compare(i1,i2,map));

			return arr1;
		}

		private int Compare(int a, int b, Dictionary<int,int> map){
			if(!map.ContainsKey(a) && !map.ContainsKey(b)){
				if(a<b) return -1;
				if(a>b) return 1;
				return 0;
			}
			else if(!map.ContainsKey(a)){
				return 1;
			}
			else if(!map.ContainsKey(b)){
				return -1;
			}

			int k1 = map[a];
			int k2 = map[b];

			if(k1<k2) return -1;
			if(k1>k2) return 1;
			return 0;
		}
	}
}