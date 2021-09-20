using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

// https://leetcode.com/problems/word-break-ii/
namespace _csharp
{
	public class _140_word_break_ii
	{
		List<string> allResults = new List<string>();

		public IList<string> WordBreak(string s, IList<string> wordDict) {
			var set = new HashSet<string> ();
			foreach (string word in wordDict) {
				set.Add (word);
			}
			fn(s, new List<string> (), set);
			return allResults;
		}

		private void fn(string s, List<string> result, HashSet<string> set){
			if(s.Length == 0){
				StringBuilder sb = new StringBuilder();
				foreach(string ss in result){
					sb.Append(ss);
					sb.Append(" ");
				}
				allResults.Add(sb.ToString().Trim());
			}

			foreach(string word in set){
				if(s.StartsWith(word)){
					result.Add(word);
					fn(s.Substring(word.Length), result, set);
					result.RemoveAt(result.Count-1);
				}
			}
		}
	}
}