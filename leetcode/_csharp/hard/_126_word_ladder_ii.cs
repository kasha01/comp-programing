using System;
using System.Collections.Generic;

// https://leetcode.com/problems/word-ladder-ii/
namespace _csharp
{
	public class _126_word_ladder_ii
	{
		public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
			HashSet<string> set = new HashSet<string>();
			List<List<string>> ans = new List<List<string>>();

			foreach(var w in wordList){
				set.Add(w);
			}

			if(!wordList.Contains(endWord))
				return ans.ToArray();

			int m = beginWord.Length;
			Queue<List<string>> qu = new Queue<List<string>>();

			char[] letters = new char[26]{'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

			qu.Enqueue(new List<string>(){beginWord});

			while(qu.Count>0){
				int n = qu.Count;
				var visited_in_level = new HashSet<string>();
				for(int l=0;l<n;++l){
					var list = qu.Dequeue();
					var word = list[list.Count - 1];

					for(int i=0;i<m;++i){
						char char_to_replace = word[i];
						for(int j=0;j<26;++j){
							char c = letters[j];
							if(c == char_to_replace) continue;

							var new_word = word.Substring(0,i) + c + word.Substring(i+1,m-1-i);

							if(set.Contains(new_word)){
								visited_in_level.Add(new_word);
								var new_list = new List<string>(list);
								new_list.Add(new_word);

								if(new_word == endWord)
									ans.Add(new_list);
								else
									qu.Enqueue(new_list);
							}
						}
					}
				}

				// don't visited words that were visited in level
				foreach(string w in visited_in_level)
					set.Remove(w);
			}

			return ans.ToArray();
		}
	}
}