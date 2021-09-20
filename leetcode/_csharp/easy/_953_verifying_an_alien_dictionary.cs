using System;

// https://leetcode.com/problems/verifying-an-alien-dictionary/
namespace _csharp
{
	public class _953_verifying_an_alien_dictionary
	{
		public bool IsAlienSorted(string[] words, string order) {
			int n = words.Length;
			int[] map = new int[26];

			for(int i=0;i<26;++i){
				map[order[i]-'a'] = i;
			}

			for(int w=0;w<n-1;++w){
				bool isInOrder = false;
				for(int i=0;i<Math.Min(words[w].Length,words[w+1].Length);++i){
					int c1 = words[w][i] - 'a';
					int c2 = words[w+1][i] - 'a';

					if(map[c1] < map[c2]){
						isInOrder=true; break;
					}
					else if(map[c1] > map[c2]){
						return false;
					}
				}

				if(!isInOrder && words[w].Length > words[w+1].Length) return false;
			}

			return true;
		}
	}
}