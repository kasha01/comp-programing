using System;

// https://leetcode.com/problems/count-sorted-vowel-strings/
namespace _csharp
{
	public class _1641_count_sorted_vowel_strings
	{
		public int CountVowelStrings(int n) {
			var memo = new int[5];
			for(int i=0;i<5;++i){
				memo[i] = 1;
			}

			while(n>0){
				--n;
				for(int i=1;i<5;++i){
					memo[i] = memo[i-1] + memo[i];
				}
			}
			return memo[4];
		}
	}
}