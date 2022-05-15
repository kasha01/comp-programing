using System;
using System.Text;

// https://leetcode.com/problems/reverse-words-in-a-string-iii/
namespace _csharp
{
	public class _557_reverse_words_in_a_string_iii
	{
		public string ReverseWords(string s) {
			int n = s.Length;
			if(n == 0) return "";
			if(n == 1) return s;

			string ans = "";
			StringBuilder sb = new StringBuilder();
			for(int i=n-1;i>=0;--i){
				if(s[i] == ' '){
					ans = " " + sb.ToString() + ans;
					sb.Clear();
				}
				else{
					sb.Append(s[i]);
				}
			}

			string res = sb.ToString() + ans;
			res = res.Trim ();

			Console.WriteLine (s);
			Console.WriteLine (res);

			return res;
		}
	}
}

