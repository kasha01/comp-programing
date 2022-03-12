using System;

// https://leetcode.com/problems/russian-doll-envelopes/
namespace _csharp
{
	public class _354_russian_doll_envelopes
	{
		public int MaxEnvelopes(int[][] envelopes) {
			Array.Sort(envelopes, (a,b) => SortMe(a,b));

			// find LIS N LOG N base on height
			int n = envelopes.Length;
			var piles = new int[n];
			piles[0] = envelopes[0][1];
			int len=1;

			for(int i=1;i<n;++i){
				int x = envelopes[i][1];
				int idx = findLowerBound(0,len,x,piles);
				if(idx == -1){
					piles[len] = x;
					++len;
				}
				else{
					piles[idx] = x;
				}
			}

			return len;
		}

		// left most pile to put target
		// BIG Thank You to https://www.youtube.com/watch?v=22s1xxRvy28
		private int findLowerBound(int lo, int hi, int target, int[] arr){
			int ans = -1;
			while(lo<hi){
				int mid = lo + ((hi-lo)/2);

				if(arr[mid] >= target){
					hi = mid;
					ans = mid;
				}
				else{
					lo = mid+1;
				}
			}

			return ans;
		}

		private static int SortMe(int[] a, int[] b){
			if(a[0] < b[0])
				return -1;
			else if(a[0] > b[0])
				return 1;

			// sort height desc.
			if(a[1] < b[1])
				return 1;
			else if(a[1] > b[1])
				return -1;

			return 0;            
		}
	}
}