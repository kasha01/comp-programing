using System;
using System.Text;

// https://leetcode.com/problems/reverse-words-in-a-string/
namespace _csharp
{
	public class _151_reverse_words_in_a_string
	{
		public string ReverseWords(string s) {

			// remove leading and trailing spaces
			s = s.Trim();

			int n = s.Length;
			StringBuilder sb = new StringBuilder();
			string word = "";
			bool spaceFlag = false;

			for(int i=n-1;i>=0;--i){
				if(!spaceFlag && s[i] == ' '){
					// add the word
					spaceFlag = true;
					sb.Append(word + " ");
					word = "";
				}
				else if(s[i] != ' '){
					// concatinate letters
					word = s[i] + word;
					spaceFlag = false;
				}
			}

			sb.Append(word);

			return sb.ToString();
		}		
	}
}

