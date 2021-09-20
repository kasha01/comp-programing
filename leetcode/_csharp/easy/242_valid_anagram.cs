using System;

// https://leetcode.com/problems/valid-anagram/
namespace _csharp
{
	public class _42_valid_anagram
	{
		public bool IsAnagram(string s, string t) {

			if(s.Length != t.Length)
				return false;

			int[] memo = new int[26];
			foreach(char c in s){
				memo[c-'a']++; 
			}

			foreach(char c in t){
				memo[c-'a']--; 
			}

			for(int i=0;i<26;++i){
				if(memo[i] != 0)
					return false;
			}

			return true;
		}
	}
}