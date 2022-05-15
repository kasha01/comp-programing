using System;
using System.Collections.Generic;

// https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/
namespace _csharp
{
	public class _1047_remove_all_adjacent_duplicates_in_string
	{
		public string RemoveDuplicates(string s) {
			var st = new Stack<char>();

			foreach(char c in s){
				if(st.Count > 0 && st.Peek() == c)
					st.Pop();
				else
					st.Push(c);
			}

			string ans = "";
			while(st.Count > 0){
				ans = st.Pop() + ans;
			}

			return ans;
		}
	}
}