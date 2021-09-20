using System;
using System.Collections.Generic;

// https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/
namespace _csharp
{
	public class _1456_maximum_number_of_vowels_in_a_substring_of_given_length
	{
		public int MaxVowels(string s, int k) {
			int mx = 0;
			int vowelsCount = 0;
			HashSet<char> set = new HashSet<char>();
			set.Add('a');
			set.Add('e');
			set.Add('i');
			set.Add('o');
			set.Add('u');

			for(int i=0;i<k-1;++i){
				if(set.Contains(s[i])){
					vowelsCount++;
				}
			}

			int n = s.Length;        
			int a = 0;
			int b = k-1;
			while(b<n){
				if(set.Contains(s[b])){
					++vowelsCount;
				}
				mx=Math.Max(vowelsCount,mx);

				if(set.Contains(s[a])){
					--vowelsCount;
				}
				++a;
				++b;
			}

			return mx;
		}
	}
}

