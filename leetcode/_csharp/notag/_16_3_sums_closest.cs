using System;

// https://leetcode.com/problems/3sum-closest/
namespace _csharp
{
	public class _16_3_sums_closest
	{
		public int ThreeSumClosest(int[] nums, int target) {
			int n = nums.Length;
			int absDiff = Int32.MaxValue;
			int closestSum = Int32.MaxValue;

			Array.Sort(nums);

			for(int k=0;k<n;++k){
				int a = nums[k];

				int i=0;
				int j=n-1;

				while(i<j){
					if(i==k){
						++i;
						continue;
					}
					if(j==k){
						--j;
						continue;
					}

					int b = nums[i];
					int c = nums[j];

					int sum = a+b+c;
					int localAbsDiff = Math.Abs(sum - target);

					if(localAbsDiff < absDiff){
						absDiff = localAbsDiff;
						closestSum=sum;
					}

					if(sum < target){
						++i;
					}
					else if(sum > target){
						--j;
					}
					else{
						return target;
					}
				}
			}

			return closestSum;
		}
	}
}

