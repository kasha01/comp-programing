using System;
using System.Collections.Generic;

// https://leetcode.com/problems/concatenated-words/
namespace _csharp
{
	public class _472_concatenated_words
	{
		HashSet<string> dictionary;
		Dictionary<string,bool> memo;
		public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
			if(words.Length <= 2) return new string[0];

			dictionary = new HashSet<string>();
			memo = new Dictionary<string,bool>();

			int minLength = int.MaxValue;
			foreach(var w in words){
				dictionary.Add(w);
				minLength = Math.Min(minLength, w.Length);
			}

			var ans = new List<string>();
			foreach(var w in words){
				if(w.Length==minLength)
					continue;

				if(fn(w))
					ans.Add(w);
			}

			return ans.ToArray();
		}

		private bool fn(string word){
			int n = word.Length;
			if(n==0)
				return false;

			if(memo.ContainsKey(word))
				return memo[word];

			for(int l=1;l<n;++l){
				string prefix = word.Substring(0,l);
				if(dictionary.Contains(prefix)){
					string suffix = word.Substring(l,n-l);
					bool b = dictionary.Contains(suffix) || fn(suffix);

					if(b){
						AddToMemo(word,true);
						return true;
					}
				}
			}

			AddToMemo(word,false);
			return false;
		}

		private void AddToMemo(string word, bool b){
			if(!memo.ContainsKey(word))
				memo.Add(word,b);
		}

		//*************************************************************************************************************************************//

		// Get the list of words that when concatinated it composite a word in the dictionary(words)
		public List<List<string>> FindAllCombositeWordsInADict(string[] words) {
			if(words.Length <= 2) return new List<List<string>>();

			dictionary = new HashSet<string>();
			memo = new Dictionary<string,bool>();

			int minLength = int.MaxValue;
			foreach(var w in words){
				dictionary.Add(w);
				minLength = Math.Min(minLength, w.Length);
			}

			var ans = new List<List<string>>();
			foreach(var w in words){
				if(w.Length==minLength)
					continue;

				var result = getComposite(w);
				if(result != null)
					ans.Add(result);
			}

			return ans;
		}

		private List<string> getComposite(string word){
			int n = word.Length;
			if(n==0)
				return null;

			for(int l=1;l<n;++l){
				string prefix = word.Substring(0,l);
				if(dictionary.Contains(prefix)){
					string suffix = word.Substring(l,n-l);

					if (dictionary.Contains (suffix)) {
						return new List<string> (){ prefix, suffix };
					}

					List<string> list = getComposite(suffix);
					if(list != null){
						list.Add(prefix);
						return list;
					}
				}
			}

			return null;
		}

		private void test(){
			FindAllCombositeWordsInADict (new string[] {
				"car",
				"super",
				"supercar",
				"hero",
				"superhero",
				"superherocar",
				"spring",
				"flower",
				"springflower",
				"winter",
				"cool"
			});
		}
	}
}