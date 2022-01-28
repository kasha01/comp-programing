using System;

// https://leetcode.com/problems/regular-expression-matching/
namespace _csharp
{
	public class _10_regular_expression_matching
	{
		// Mostly not my solution.
		public class Solution {
			int[,] memo;
			public bool IsMatch(string s, string p) {
				memo = new int[s.Length+1,p.Length+1];
				return IsMatch(s,p,0,0);
			}

			private bool IsMatch(string s, string p, int si, int pi){
				// pattern is finished, true: s is finished | otherwise: false. 
				if(pi==p.Length) {
					memo[si,pi] = si==s.Length ? 2 : 1;
					return si==s.Length;
				}

				if(memo[si,pi] > 0) return memo[si,pi]-1 == 1 ? true : false;

				// normal match if si<s.Length
				bool is_match = si<s.Length && (s[si]==p[pi] || p[pi]=='.');

				// edge case for '*'
				if(pi+1<p.Length && p[pi+1]=='*'){
					// * Matches zero characters, OR recurssively matches a character and goes to the next one
					bool result = IsMatch(s,p,si,pi+2) || (is_match && IsMatch(s,p,si+1,pi));
					memo[si,pi] = result ? 2 : 1;
					return result;
				}

				// return for case if not '*': return false if not match OR go to next char
				bool result_2 = is_match && IsMatch(s,p,si+1,pi+1);
				memo[si,pi] = result_2 ? 2 : 1;
				return result_2;
			}
		}
	}
}

