using System;
using System.Collections.Generic;
using System.Text;

// https://leetcode.com/problems/print-words-vertically/
namespace _csharp
{
	public class _1324_print_words_vertically
	{
		public IList<string> PrintVertically(string s) {
			string[] words = s.Split(' ');
			int n = words.Length;

			StringBuilder sb = new StringBuilder();
			List<string> answer = new List<string>();
			int j=0;
			while(true){
				bool wordWasAdded = false;
				sb.Clear();
				for(int i=0;i<n;++i){
					if(j >= words[i].Length){
						// skip
						sb.Append(' ');
					}
					else{
						sb.Append(words[i][j]);
						wordWasAdded = true;
					}
				}

				if(!wordWasAdded)
					break;

				answer.Add(sb.ToString().TrimEnd());
				++j;
			}

			return answer;        
		}		
	}
}

