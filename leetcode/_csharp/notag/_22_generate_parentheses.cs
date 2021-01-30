using System;
using System.Collections.Generic;

// https://leetcode.com/problems/generate-parentheses/
namespace _csharp
{
	public class _22_generate_parentheses
	{
		int N = 0;
		List<string> result;
		public IList<string> GenerateParenthesis(int n) {
			result = new List<string>();
			N=n;
			rc(0,0,"");
			return result;
		}

		private void rc(int open, int close, string s){
			if(s.Length == N*2){
				result.Add(s);
				return;
			}

			if(open < N){
				rc(open+1, close, s + "(");
			}

			if(open>close){
				rc(open, close+1, s+")");           
			}
		}
	}
}

