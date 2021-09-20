using System;
using System.Collections.Generic;

// https://leetcode.com/problems/find-all-anagrams-in-a-string/
namespace _csharp
{
	public class _438_find_all_anagrams_in_a_string
	{
		public IList<int> FindAnagrams(string s, string p) {
			if(p.Length > s.Length)
				return new List<int>();

			int[] targetMemo = new int[26];
			foreach(char c in p){
				targetMemo[c - 'a']++;
			}

			int[] memo = new int[26];
			for(int i=0;i<p.Length;++i){
				memo[s[i] - 'a']++;
			}

			int pl = p.Length;
			List<int> result = new List<int>();
			for(int i=0; i<=s.Length-pl; ++i){
				if(isMatch(memo, targetMemo))
					result.Add(i);

				int l = i; int r = i+pl;
				memo[s[l] - 'a']--; 
				if(i+pl < s.Length)
					memo[s[r] - 'a']++;
			}

			return result;
		}

		private bool isMatch(int[] memo, int[] targetMemo){
			for(int i=0;i<26;++i){
				if(memo[i] != targetMemo[i])
					return false;
			}
			return true;
		}
	}
}