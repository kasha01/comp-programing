using System;
using System.Collections.Generic;

// https://leetcode.com/problems/group-anagrams/
namespace _csharp
{
	public class _49_group_anagrams
	{
		public IList<IList<string>> GroupAnagrams(string[] strs) {

			Dictionary<string,List<string>> map = new Dictionary<string,List<string>>();

			foreach(string s in strs){
				int[] freq = new int[26];
				foreach(char c in s){
					freq[c-'a']++;
				}

				// concatinate the frequency array chars
				string concat = "";
				for(int j=0;j<26;++j){
					char cc = Convert.ToChar('a'+j);
					concat = concat + new string(cc,freq[j]);
				}

				if(!map.ContainsKey(concat))
					map.Add(concat,new List<string>());

				map[concat].Add(s);
			}

			List<List<string>> ans = new List<List<string>>();
			foreach(var kvp in map){
				ans.Add(kvp.Value);
			}

			return ans.ToArray();
		}
	}
}