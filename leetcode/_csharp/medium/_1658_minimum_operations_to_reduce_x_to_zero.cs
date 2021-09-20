using System;

// https://leetcode.com/problems/minimum-operations-to-reduce-x-to-zero/
namespace _csharp
{
	public class _1658_minimum_operations_to_reduce_x_to_zero
	{
		// dp solution O(N^2)
		int[,] memo;
		public int MinOperations_dp(int[] nums, int x) {
			int n = nums.Length;
			memo = new int[n,n];
			return rc(0,n-1,0,nums,x);
		}

		private int rc(int l, int r, int sum, int[] nums, int x){
			if(sum == x){
				return 0;
			}

			if(sum>x) return -1;
			if(l>r) return -1;

			if(memo[l,r]!=0) return memo[l,r];

			int s1 = rc(l+1,r,sum+nums[l],nums,x);
			int s2 = rc(l,r-1,sum+nums[r],nums,x);

			int res = 0;
			if(s1==-1 && s2==-1)
				res=-1;
			else if(s1==-1) 
				res=s2+1;
			else if(s2==-1)
				res=s1+1;
			else
				res=1+Math.Min(s1,s2);

			memo[l,r] = res;
			return res;
		}


		// two pointers solution O(N). find the longest continuous subarray with sum = total_sum - x; the ans would be n-longest_subarray_length
		public int MinOperations(int[] nums, int x) {
			int n = nums.Length;
			int total = 0;
			foreach(int k in nums){
				total = total+k;
			}

			if(total<x) return -1;
			if(total==x) return n;

			int i=0; int j=0; int sum=0; int y=total-x; int longest_subarray=int.MinValue;
			while(j<n){
				sum=sum+nums[j];

				if(sum==y){
					longest_subarray = Math.Max(longest_subarray,j-i+1);
				}

				while(i<=j && sum>y){
					sum = sum-nums[i];

					++i;
					if(sum==y){
						longest_subarray = Math.Max(longest_subarray,j-i+1);
					}
				}

				++j;
			}

			return longest_subarray == int.MinValue ? -1 : n-longest_subarray;
		}
	}
}