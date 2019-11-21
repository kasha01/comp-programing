using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/reverse-words-in-a-given-string/0
namespace GeeksForGeeks_csharp
{
	public class reverse_words_in_a_given_string
	{
		static void solve(string s){
			Stack<string> stack = new Stack<string>();

			string ss = "";
			int n = s.Length;
			for (int i = 0; i < n; ++i) {
				if (s [i] == '.') {
					stack.Push (ss);
					ss = "";
				} else {
					ss = ss + s [i];
				}
			}
			stack.Push (ss);

			string result = "";
			while (stack.Count > 0) {
				result = result + stack.Peek () + ".";
				stack.Pop ();
			}
			result = result.TrimEnd ('.');
			Console.WriteLine (result);
		}
	}
}

