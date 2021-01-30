using System;
using System.Collections.Generic;

// https://leetcode.com/problems/advantage-shuffle/
namespace _csharp
{
	public class _870_advantage_shuffle
	{
		public int[] AdvantageCount(int[] A, int[] B) {
			int an = A.Length;
			int bn = B.Length;

			// index | value
			KeyValuePair<int,int>[] aa = new KeyValuePair<int,int>[an];
			KeyValuePair<int,int>[] bb = new KeyValuePair<int,int>[bn];

			for(int ii=0;ii<an;++ii){
				aa[ii] = new KeyValuePair<int,int>(ii,A[ii]);
			}

			for(int ii=0;ii<bn;++ii){
				bb[ii] = new KeyValuePair<int,int>(ii,B[ii]);
			}

			Array.Sort(aa, sortme);
			Array.Sort(bb, sortme);

			int i=0; int j=0; int n=an; int m=bn;

			while(i<n && j<m){
				int aValue = aa[i].Value;
				int bValue = bb[j].Value;

				if(aValue > bValue){
					int bIndex = bb[j].Key;
					A[bIndex] = aValue;
					++i; ++j;
				}
				else{
					while(i<n && j<m && aa[i].Value <= bValue){
						int indexOfBiggestB = bb[m-1].Key;
						A[indexOfBiggestB] = aa[i].Value;
						--m; ++i;
					}               
				}
			}

			return A;
		}

		private static int sortme(KeyValuePair<int,int> a, KeyValuePair<int,int> b){
			if(a.Value < b.Value)
				return -1;

			if(a.Value > b.Value)
				return 1;

			return 0;
		}
	}
}