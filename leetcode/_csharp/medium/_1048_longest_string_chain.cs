using System;
using System.Collections.Generic;

// https://leetcode.com/problems/longest-string-chain/
namespace _csharp
{
	public class _1048_longest_string_chain
	{
		public int LongestStrChain(string[] words) {
			Dictionary<string, int> memo = new Dictionary<string, int>();

			// sort words by length
			Array.Sort(words, new MyComparer());

			int mx = 1;
			for(int i=0;i<words.Length;++i){
				string word = words[i];
				if(!memo.ContainsKey(word)){
					memo.Add(word,1);    
				}

				if(word.Length == words[0].Length) {
					// no need to compare words of size equals minimum size as no letters were added to form
					// a predecessor relationship
					continue;
				}

				int m = word.Length;
				for (int j = 0; j < m; ++j) {
					string a = words[i].Substring (0, j);
					string b = words[i].Substring (j + 1, m - j - 1);
					string predecessor = a+b;
					if(memo.ContainsKey(predecessor)){
						memo[word]=Math.Max(1+memo[predecessor],memo[word]);
						mx=Math.Max(memo[word],mx);
					}
				}
			}

			return mx;
		}

		class MyComparer:IComparer<string>{
			public int Compare(string a, string b){
				if(a.Length < b.Length)
					return -1;

				if(a.Length > b.Length)
					return 1;

				return 0;
			}
		}
	}
}