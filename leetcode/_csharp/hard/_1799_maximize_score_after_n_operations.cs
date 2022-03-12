using System;

// https://leetcode.com/problems/maximize-score-after-n-operations/
namespace _csharp
{
	public class _1799_maximize_score_after_n_operations
	{
		int[,] memo;
		public int MaxScore(int[] nums) {
			int n = nums.Length/2;

			memo = new int[n+1, (int)Math.Pow(2,n*2)+1];
			return rc(1,0,n,nums);
		}

		private int rc(int i, int mask, int n, int[] nums){
			if(i>n)
				return 0;

			if(memo[i,mask] > 0) return memo[i,mask]-1;

			int sum = 0;
			int m = n*2;
			for(int j=0;j<m;++j){
				int j_bit = 1<<(m-1-j);
				if((j_bit & mask) != 0) continue;

				for(int k=0;k<m && k!=j;++k){
					int k_bit = 1<<(m-1-k);
					if((k_bit & mask) != 0) continue;

					int new_mask = mask | j_bit | k_bit;
					int s = i*gcd(nums[j],nums[k]) + rc(i+1,new_mask,n,nums);
					sum = Math.Max(sum,s);
				}
			}

			memo[i,mask] = sum + 1;
			return sum;
		}

		private int gcd(int a, int b){
			if(a==0) return b;
			return gcd(b%a, a);
		}
	}
}