using System;
using System.Collections.Generic;
using System.Text;

// https://leetcode.com/problems/most-common-word/
namespace _csharp
{
	public class _819_most_common_word
	{
		public string MostCommonWord(string paragraph, string[] banned) {
			var words = new List<string>();
			StringBuilder sb = new StringBuilder();

			for(int i=0;i<paragraph.Length;++i){
				if(paragraph[i] >= 'a' && paragraph[i] <= 'z'){
					sb.Append(paragraph[i]);
				}
				else if(paragraph[i] >= 'A' && paragraph[i] <= 'Z'){
					sb.Append(paragraph[i].ToString().ToLower());
				}
				else{
					if(sb.Length > 0){
						words.Add(sb.ToString());
						sb.Clear();
					}                    
				}
			}

			if(sb.Length > 0){
				words.Add(sb.ToString());
			}

			var map = new Dictionary<string,int>();
			var bannedSet = new HashSet<string>();

			foreach(string word in banned){
				bannedSet.Add(word.ToLower());
			}       

			foreach(var w in words){
				string word = w.ToLower();

				if(bannedSet.Contains(word))
					continue;

				if(!map.ContainsKey(word)){
					map.Add(word,0);
				}    

				map[word]++;
			}

			int mx = -1; string ans="";
			foreach(var kvp in map){
				if(kvp.Value > mx){
					mx = kvp.Value;
					ans = kvp.Key;
				}
			}

			return ans;
		}
	}
}

