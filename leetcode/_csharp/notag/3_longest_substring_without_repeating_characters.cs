using System;
using System.Collections.Generic;

// https://leetcode.com/problems/longest-substring-without-repeating-characters/
namespace _csharp
{
	public class _3_longest_substring_without_repeating_characters
	{

		public int LengthOfLongestSubstring(string s) {

			// map: char | index
			Dictionary<char,int> map = new Dictionary<char,int>();
			int start = 0;
			int result = 0;
			int sum=0;
			int i = 0;
			int n = s.Length;
			while(i<n){
				char x = s[i];

				if(map.ContainsKey(x)){
					// there is duplicate
					int dupIndex = map[x];
					while(start<=dupIndex){
						char xx = s[start];
						map.Remove(xx);
						start++;
					}

					map[x]=i;
					sum=i-start+1;
					result = Math.Max(sum, result);
				}
				else {
					// no duplicate
					map.Add(x,i);
					sum++;
					result = Math.Max(sum, result);
				}

				++i;
			}

			return result;
		}
	}
}