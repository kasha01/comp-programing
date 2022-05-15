using System;
using System.Collections.Generic;

// https://leetcode.com/problems/contains-duplicate-iii/
namespace _csharp
{
	public class _220_contains_duplicate_iii
	{
		// courtesy of: lllllll2
		// https://leetcode.com/problems/contains-duplicate-iii/discuss/824578/C%2B%2B-O(N)-time-complexity-or-Explained-or-Buckets-or-O(K)-space-complexity

		/* 
		If I can group numbers in buckets or range, in which I know if that bucket exists that means there is another 
		number where the absolute value between that number and the bucket number is <= t.
		In other words, all the numbers in the bucket have an absolute difference <= t.
		In other words, if two numbers belonged to the same bucket, their abs is <= t.

		This is a better explanation: Imagine for t<=3. If I have
		[0 1 2 3 4 5 6 7 8 9 10 11]
		Notice how:
		{0,1,2,3}, {4,5,6,7}, {8,9,10,11} these groups statisfy t<=3 within each one.
		**/    
		public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
			var bucket = new Dictionary<int,int>();
			int n = nums.Length;

			for(int i=0;i<n;++i){
				int bucket_x = nums[i]/(t+1);

				if(nums[i]<0)
					--bucket_x;

				if(bucket.ContainsKey(bucket_x)){
					return true;
				}

				if(!bucket.ContainsKey(bucket_x))
					bucket.Add(bucket_x,nums[i]);
				else
					bucket[bucket_x] = nums[i];

				if(bucket.ContainsKey(bucket_x-1) && (long)nums[i] - bucket[bucket_x-1] <= t) return true;
				if(bucket.ContainsKey(bucket_x+1) && (long)bucket[bucket_x+1] - nums[i] <= t) return true;

				// remove i-j>k bucket
				if(i-k>=0){
					int toRemove = nums[i-k];
					int bukcet_toRemove = toRemove/(t+1);

					if(bukcet_toRemove<0)
						--bukcet_toRemove;

					bucket.Remove(bukcet_toRemove);    
				}
			}

			return false;
		}


		// N Log N
		public bool ContainsNearbyAlmostDuplicate_TreeSet(int[] nums, int k, int t) {
			SortedSet<long> set = new SortedSet<long>();
			int n = nums.Length;

			int j=0; set.Add(nums[0]);
			for(int i=1;i<n;++i){
				if(i-j>k){
					int x = nums[j];
					set.Remove(x);
					++j;
				}

				long ls = (long)nums[i] - t;
				long gt = (long)nums[i] + t;
				if(set.GetViewBetween(ls,gt).Count > 0){	// LOG N
					return true;
				}

				set.Add(nums[i]);
			}

			return false;
		}
	}
}

