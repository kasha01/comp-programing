using System;

namespace _csharp
{
	// { 6, 13, 10, 2 }, 4
	public class _fb_oa_split_circular_array
	{
		public int SplitArray(int[] nums, int m) {
			int n = nums.Length;

			int sum = 0;
			foreach(int x in nums){
				sum = sum + x;
			}

			int lo = 0; int hi=sum; int ans = int.MaxValue;
			while(lo<=hi){
				int mid = lo + (hi-lo)/2;
				var res = isValid (mid, m, nums);
				if(res != -1){
					ans = res;
					hi=mid-1;
				}
				else{
					lo=mid+1;
				}
			}

			Console.WriteLine ("answer:" + ans);
			return ans;
		}

		private int isValid(int sumLimit, int m, int[] nums){
			// sum cannot exceed sumLimit

			int n = nums.Length;

			for(int start=0;start<n;++start){
				int minSum = int.MaxValue; int maxSum = int.MinValue;
				int sum = 0; int i=0; int mc = m; 

				while(i<n && mc>0){
					int x = (i + start) % n;
					if(sum + nums[x] > sumLimit){
						// end of split of a block
						minSum = Math.Min (sum, minSum);
						maxSum = Math.Max (sum, maxSum);

						sum = 0;
						--mc;
						continue;
					}
					else{
						sum = sum + nums[x];
					}

					++i;
				}

				if (mc > 1) {
					minSum = Math.Min (sum, minSum);
					maxSum = Math.Max (sum, maxSum);

					return maxSum - minSum;
				}
			}

			return -1;	// no valid result found.
		}
	}
}