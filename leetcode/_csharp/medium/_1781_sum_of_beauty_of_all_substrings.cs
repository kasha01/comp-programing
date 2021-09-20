using System;

// https://leetcode.com/problems/sum-of-beauty-of-all-substrings/
namespace _csharp
{
	public class _1781_sum_of_beauty_of_all_substrings
	{
		public int BeautySum(string s) {
			int result = 0;
			for(int start=0;start<s.Length;++start){
				int[] memo = new int[26];
				int mx = 0;
				for(int j=start; j<s.Length;++j){
					int x = s[j] - 'a';
					++memo[x];
					if(memo[x] > mx){
						mx = memo[x];
					}

					int mn = mx;

					for(int k=0;k<26;++k){
						if(memo[k]>0 && memo[k] < mn){
							mn = memo[k];
						}
					}

					result = result + (mx-mn);
				}
			}

			return result;
		}
	}
}