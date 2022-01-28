using System;
using System.Collections.Generic;
using System.Collections;

// https://leetcode.com/problems/roman-to-integer/
namespace _csharp
{
	public class _13_roman_to_integer
	{
		public int RomanToInt(string s) {
			int sum = 0;

			Dictionary<char,int> map = new Dictionary<char,int>();
			map.Add('I',1);
			map.Add('V',5);
			map.Add('X',10);
			map.Add('L',50);
			map.Add('C',100);
			map.Add('D',500);
			map.Add('M',1000);

			int i=0;
			while(i<s.Length){
				int c1 = map[s[i]];
				if(i+1<s.Length){
					int c2 = map[s[i+1]];
					if(c2>c1){
						sum = sum + (c2-c1); ++i;
					}
					else{
						sum = sum + c1;
					}
				}
				else{
					sum = sum + c1;
				}

				++i;
			}

			return sum;
		}
	}
}