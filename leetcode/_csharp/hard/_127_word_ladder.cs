using System;
using System.Collections.Generic;

// https://leetcode.com/problems/word-ladder/
namespace _csharp
{
	public class _127_word_ladder
	{
		public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
			int m = beginWord.Length;
			Dictionary<string, bool> map = new Dictionary<string,bool>();

			foreach(var word in wordList){
				map.Add(word,false);
			}

			if(!map.ContainsKey(endWord))
				return 0;

			int distance = 1;
			Queue<string> qu = new Queue<string>();
			qu.Enqueue(endWord);
			map[endWord]=true;

			while(qu.Count > 0){
				int n = qu.Count;

				for(int i=0;i<n;++i){
					string word = qu.Dequeue();

					for(int j=0;j<m;++j){
						for(int k=0;k<26;++k){
							string temp_word = word.Substring(0,j) + (char)('a'+k) + word.Substring(j+1,m-1-j);

							if(temp_word==beginWord)
								return distance+1;

							if(map.ContainsKey(temp_word) && !map[temp_word]){
								// not visited
								qu.Enqueue(temp_word);
								map[temp_word] = true;
							}
						}
					}
				}

				++distance;
			}

			return 0;
		}
	}
}