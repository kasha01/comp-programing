using System;
using System.Collections.Generic;

// https://leetcode.com/problems/minimum-window-substring/
namespace _csharp
{
	public class _76_minimum_window_substring
	{
		public string MinWindow(string s, string t) {
			Dictionary<char, int> targetMap = new Dictionary<char,int>();
			Dictionary<char,int> memo = new Dictionary<char,int>();

			foreach(char c in t){
				if(!targetMap.ContainsKey(c)){
					targetMap.Add(c,0);
					memo.Add(c,0);
				}
				targetMap[c]++;
			}

			bool targetCountMet = false;
			int uniqueTargetLettersCount=0;
			int rightIndex=0; int leftIndex=0;
			int r=0; int l=0; int n=s.Length; int mn=int.MaxValue;

			while(r<n){
				if(memo.ContainsKey(s[r])){
					// current letter exists in target.
					memo[s[r]]++;

					// if count of current letter equals the its count in target. increment unique target letters count
					if(memo[s[r]] == targetMap[s[r]])
						uniqueTargetLettersCount++;

					// if unique target letters count equals targetMap count (count of uniques in target), then
					// all target letters were met.
					if(uniqueTargetLettersCount == targetMap.Count)
						targetCountMet=true;
				}

				// try to minimize the left window if possible.
				while(l<r){
					if(!targetMap.ContainsKey(s[l])){
						// letter on left is not in target, move left index up
						++l;
					}
					else if(targetMap.ContainsKey(s[l]) && memo[s[l]]>targetMap[s[l]]){
						// letter on left has extra count more than needed in targetMap. move and decrement count.
						--memo[s[l]];
						++l;
					}
					else{
						break;
					}
				}

				if(targetCountMet && r-l+1 < mn){
					rightIndex=r;
					leftIndex=l;
					mn = r-l+1;
				}

				++r;
			}

			return targetCountMet ? s.Substring(leftIndex, rightIndex-leftIndex+1) : "";
		}
	}
}