using System;
using System.Collections.Generic;

// https://leetcode.com/problems/top-k-frequent-elements/
namespace _csharp
{
	public class _347_top_k_frequent_elements
	{
		public int[] TopKFrequent_bucket_sort(int[] nums, int k) {
			int n = nums.Length;
			Dictionary<int,int> map = new Dictionary<int,int>();
			var freq = new List<int>[n+1];

			for(int i=1;i<=n;++i)
				freq[i] = new List<int>();

			foreach(int x in nums){
				if(!map.ContainsKey(x))
					map.Add(x,0);

				map[x]++;
			}

			foreach(var kvp in map){
				int key = kvp.Key;
				int fr = kvp.Value;

				freq[fr].Add(key);
			}

			var ans = new List<int>();
			for(int i=n;i>=1; --i){
				if(freq[i].Count > 0)
					ans.AddRange(freq[i]);

				if(ans.Count == k)
					break;
			}

			return ans.ToArray();
		}
	}
}

