using System;
using System.Collections.Generic;

// https://leetcode.com/problems/partition-labels/
namespace _csharp
{
	public class _763_partition_labels
	{
		public IList<int> PartitionLabels(string S) {
			int[] map = new int[26];
			int n = S.Length;

			for(int i=0;i<n;++i){
				char x = S[i];
				int ii = x-'a';

				map[ii] = i;
			}

			List<int> result = new List<int>();
			int start=0; int range=0;
			for(int i=0;i<n;++i){
				char x = S[i];
				int ii = x-'a';
				range = Math.Max(range, map[ii]);                               

				if(i == range){
					result.Add(i-start+1);
					range=0;
					start=i+1;
				}
			}

			return result.ToArray();
		}
	}
}