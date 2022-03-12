using System;
using System.Collections.Generic;
using System.Text;

// https://leetcode.com/problems/most-common-word/
namespace _csharp
{
	public class _819_most_common_word
	{
		public string MostCommonWord(string paragraph, string[] banned) {
			var bannedSet = new HashSet<string>();
			foreach(string word in banned){
				bannedSet.Add(word.ToLower());
			}

			int mx = -1; string ans="";
			var words = new Dictionary<string,int>();
			StringBuilder sb = new StringBuilder();

			for(int i=0;i<paragraph.Length;++i){
				if(paragraph[i] >= 'a' && paragraph[i] <= 'z'){
					sb.Append(paragraph[i]);
				}
				else if(paragraph[i] >= 'A' && paragraph[i] <= 'Z'){
					sb.Append(paragraph[i]);
				}
				else{
					if(sb.Length > 0){
						string s = sb.ToString().ToLower();
						sb.Clear();

						if(bannedSet.Contains(s))
							continue;

						if(!words.ContainsKey(s))
							words.Add(s,0);

						words[s]++;

						if(words[s] >= mx){
							mx = words[s];
							ans = s;
						}
					}
				}
			}

			if(sb.Length > 0){
				string s = sb.ToString().ToLower();
				sb.Clear();

				if(bannedSet.Contains(s))
					return ans;

				if(!words.ContainsKey(s))
					words.Add(s,0);

				words[s]++;

				if(words[s] >= mx){
					mx = words[s];
					ans = s;
				}
			}

			return ans;
		}
	}
}