using System;
using System.Collections.Generic;

// https://leetcode.com/problems/valid-parentheses/
namespace _csharp
{
	public class _20_valid_parentheses
	{
		public bool IsValid(string s) {
			Stack<char> stack = new Stack<char>();

			int n = s.Length;
			for(int i=0;i<n;++i){
				char x = s[i];

				if(x == '(' || x == '{' || x == '['){
					stack.Push(x);
				}
				else{
					if(stack.Count == 0)
						return false;

					char y = stack.Pop();

					if(
						(x == ')' && y != '(' ) ||
						(x == ']' && y != '[' ) || 
						(x == '}' && y != '{' )){
						return false;
					}
				}
			}

			return stack.Count == 0;        
		}
	}
}

