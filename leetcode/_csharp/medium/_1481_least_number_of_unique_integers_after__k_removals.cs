using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

// https://leetcode.com/problems/least-number-of-unique-integers-after-k-removals/
namespace _csharp
{
	public class _1481_least_number_of_unique_integers_after__k_removals
	{
		public int FindLeastNumOfUniqueInts(int[] arr, int k) {
			Dictionary<int,int> map = new Dictionary<int,int>();

			foreach(int x in arr){
				if(!map.ContainsKey(x)){
					map.Add(x,0);
				}
				++map[x];
			}

			List<int> counts = map.Values.ToList();
			counts.Sort();

			int n = counts.Count;
			int ans = counts.Count;
			int i=0;
			while(k>0 && i < n){
				k = k - counts[i];
				if(k>=0){
					--ans;
				}
				++i;
			}

			return ans;
		}
	}
}

