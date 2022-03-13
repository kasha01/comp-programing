using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

// https://leetcode.com/problems/word-break-ii/
namespace _csharp
{
	public class _140_word_break_ii
	{
		
		/// Word Break with memoization (faster)
		HashSet<string> dict;
		Dictionary<string,List<string>> memo;
		public IList<string> WordBreak_Memo(string s, IList<string> wordDict) {
		    dict = new HashSet<string>();
		    memo = new Dictionary<string,List<string>>();

		    foreach(string word in wordDict)
			dict.Add(word);

		    return rc(s).ToArray();
		}

		private List<string> rc(string s){
		    int n = s.Length;
		    if(n == 0)
			return new List<string>(0);

		    if(memo.ContainsKey(s)) return memo[s];

		    var ret = new List<string>();
		    if(dict.Contains(s))
			ret.Add(s); // count for edge case if s exists in dict as a whole word (without segmentation).

		    for(int l=1;l<n;++l){
			string prefix = s.Substring(0,l);
			if(dict.Contains(prefix)){
			    // segment suffix
			    string suffix = s.Substring(l,n-l);

			    var ret_list = rc(suffix);
			    foreach(string ss in ret_list){
				ret.Add(prefix + " " + ss);
			    }
			}
		    }

		    memo.Add(s, ret);
		    return ret;
		}
		
		/// end word break with memoization
		
		
		/// word break recurssive with no memoization
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
		
		/// end word break recurssive with no memoization
	}
}
