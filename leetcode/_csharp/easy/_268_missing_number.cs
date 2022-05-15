using System;

// https://leetcode.com/problems/missing-number/
namespace _csharp
{
	public class _268_missing_number
	{
		public int MissingNumber_Mark_Index(int[] nums) {
			int n = nums.Length;
			int maxNum = -1;
			for(int i=0;i<n;++i){
				maxNum = Math.Max(maxNum, nums[i]);
			}

			maxNum = maxNum+1;

			for(int i=0;i<n;++i){
				int x = nums[i];
				if(x < 0){
					x = x + maxNum;
				}

				if(x<n)
					nums[x] = nums[x]-maxNum;
			}

			for(int i=0;i<n;++i){
				if(nums[i] >= 0) return i;
			}

			return n;
		}

		public int MissingNumber_xor(int[] nums) {
			int n = nums.Length;

			int all = 0;
			int xor = 0;
			for(int i=0;i<n;++i){
				xor = nums[i] ^ xor;
			}

			for(int i=0;i<=n;++i){
				all = all ^ i;
			}

			return all ^ xor;
		}

		public int MissingNumber_BinarySearch(int[] nums) {
			int n = nums.Length;

			Array.Sort(nums);
			int lo=0; int hi=n-1;
			while(lo<=hi){
				int mid = lo + (hi-lo)/2;

				if(nums[mid] == mid){
					lo = mid+1;    
				}
				else{
					hi = mid-1;
				}
			}

			return lo;
		}
	}
}

