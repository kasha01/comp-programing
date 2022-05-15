using System;

// https://leetcode.com/problems/random-pick-with-weight/
// courtesy of: https://leetcode.com/problems/random-pick-with-weight/discuss/154044/Java-accumulated-freq-sum-and-binary-search
namespace _csharp
{
	public class _528_random_pick_with_weight
	{
		private int[] arr;
		int n = 0;
		Random rnd;
		public _528_random_pick_with_weight(int[] w) {
			n = w.Length;
			arr = new int[n];
			rnd = new Random();

			int prev = 0;
			for(int i=0;i<n;++i){
				arr[i] = prev + w[i];
				prev = arr[i];
			}
		}

		public int PickIndex() {
			if(n==1) return 0;

			int r = rnd.Next(arr[n-1]) + 1; // range [1,last item]

			int index = getIndex(r);
			return index;
		}

		// get Lower Bound
		private int getIndex(int target){
			int lo=0; int hi=n-1; int ans = hi;

			while(lo<=hi){
				int mid = lo + ((hi-lo)/2);

				if(arr[mid] >= target){
					hi = mid-1;
					ans = mid;
				}
				else{
					lo = mid+1;
				}
			}

			return ans;
		}
	}
}