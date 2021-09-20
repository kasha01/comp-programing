using System;

// https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/
namespace _csharp
{
	public class _921_minimum_add_to_make_parentheses_valid
	{
		public int MinAddToMakeValid(string s) {
			int open=0; int close=0;

			foreach(char c in s){
				if(c==')'){
					if(open==0){
						++close;
					}
					else{
						--open;
					}
				}
				else{
					++open;
				}
			}

			return open+close;
		}
	}
}

