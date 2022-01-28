using System;
using System.Collections.Generic;

// https://leetcode.com/problems/find-original-array-from-doubled-array/
namespace _csharp
{
	public class _2007_find_original_array_from_doubled_array
	{
		public int[] FindOriginalArray(int[] changed) {
			int[] freq = new int[100001];

			foreach(int x in changed){
				freq[x]++;
			}

			List<int> list = new List<int>();

			// 0 edge case
			if(freq[0] > 0){
				if(freq[0]%2==0){
					for(int k=0;k<(freq[0]/2);++k){
						list.Add(0);
					}
				}
				else{
					return new int[0];
				}
			}

			for(int i=1;i<=50000;++i){
				if(freq[i] > 0){
					int j = i*2;
					if(freq[j] >= freq[i]){
						for(int k=0;k<freq[i];++k){
							list.Add(i);
						}
						freq[j]= freq[j] - freq[i];  // zeroize as y is part of changed not original array
					}
					else{
						return new int[0];
					}
				}
			}

			return list.ToArray();
		}
	}
}