using System;
using System.Collections.Generic;

// https://leetcode.com/problems/longest-arithmetic-subsequence/
namespace _csharp
{
	public class _1027_longest_arithmetic_subsequence
	{
		// DP apprach
		public int LongestArithSeqLength(int[] nums) {
			int n = nums.Length;
			int[,] memo = new int[n,1001];

			for(int i=0;i<n;++i){
				for(int j=0;j<=1000;++j){
					memo[i,j] = 1;
				}
			}

			int mx = -1;
			for(int i=0;i<n;++i){
				for(int j=i+1;j<n;++j){
					int diff = nums[j] - nums[i] + 500;

					memo[j,diff] = 1 + memo[i,diff];
					mx = Math.Max(mx, memo[j,diff]);
				}
			}

			return mx;
		}

		// weird approach
		public int LongestArithSeqLength_2(int[] nums) {
			int n = nums.Length;
			Dictionary<int,int>[] memo = new Dictionary<int,int>[n];
			for(int i=0;i<n;++i){
				memo[i] = new Dictionary<int,int>();
				memo[i].Add(0,1);
			}

			int ans=1;
			for(int i=0;i<n;++i){
				for(int j=i+1;j<n;++j){
					int s = 1;
					int diff = nums[j]-nums[i];
					Dictionary<int,int> dict_i = memo[i];
					int diff_at_i = 1;
					if(dict_i.ContainsKey(diff)){
						// there is an arithmetic subsquence with same sequence ending at i.
						diff_at_i=dict_i[diff];
					}

					Dictionary<int,int> dict_j = memo[j];
					if(dict_j.ContainsKey(diff)){
						// there was already a subsequence with same diff. pick max
						// current or dict_i+1.
						memo[j][diff] = Math.Max(memo[j][diff], diff_at_i+1);
					}
					else{
						memo[j].Add(diff,diff_at_i+1);
					}
					s = memo[j][diff];

					ans = Math.Max(ans,s);
				}
			}

			return ans;
		}
	}
}

