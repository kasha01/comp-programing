using System;

// https://leetcode.com/problems/minimum-moves-to-convert-string/
namespace _csharp
{
	public class _2027_minimum_moves_to_convert_string
	{
		public int MinimumMoves(string s) {
			int n = s.Length;
			int i = 0; int moves = 0;
			while(i<n){
				if(s[i] == 'X'){
					moves++;
					i = i + 2;
				}
				++i;
			}

			return moves;
		}
	}
}