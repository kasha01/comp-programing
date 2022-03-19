using System;
using System.Collections.Generic;
using System.Text;

// https://leetcode.com/problems/word-break/
namespace _csharp
{
	public class _139_word_break
	{
		bool[] notValidMemo;
		public bool WordBreak(string s, IList<string> wordDict) {
			notValidMemo = new bool[s.Length+1];
			HashSet<string> set = new HashSet<string>();
			foreach(string word in wordDict){
				set.Add(word);
			}
			return rc(0,s.Length,s,set);
		}

		private bool rc(int start, int n, string s, HashSet<string> wordDict){
			if(start>=n)
				return true;

			if(notValidMemo[start])
				return false;

			StringBuilder sb = new StringBuilder();
			for(int i=start;i<n;++i){
				sb.Append(s[i]);

				if(wordDict.Contains(sb.ToString())){
					bool result = wordDict.Contains(s.Substring(i+1)) || rc(i+1,n,s,wordDict);
					if(result)
						return true;
				}
			}

			notValidMemo[start] = true;
			return false;
		}
	}
}