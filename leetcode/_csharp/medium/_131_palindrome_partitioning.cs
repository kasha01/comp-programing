using System;
using System.Collections.Generic;

// https://leetcode.com/problems/palindrome-partitioning/
namespace _csharp
{
	public class _131_palindrome_partitioning
	{
		List<List<string>> result;
		public IList<IList<string>> Partition(string s) {
			var memo = new bool[s.Length,s.Length];
			result = new List<List<string>>();
			List<string> list = new List<string>();
			rc(0, list, memo, s);
			return result.ToArray();
		}

		private void rc(int start, List<string> list, bool[,] memo, string s){
			if(start==s.Length){
				// print
				List<string> ls = new List<string>();
				ls.AddRange(list);
				result.Add(ls);
				return;
			}

			for(int ll=1;start+ll-1<s.Length;++ll){
				int end = start+ll-1;
				if(s[start] == s[end]){
					if(ll<=2){
						memo[start,end] = true;
						list.Add(s.Substring(start, ll));
						rc(end+1, list, memo, s);
						list.RemoveAt(list.Count-1);
					}
					else{
						if(memo[start+1, end-1]){
							memo[start,end] = true;
							list.Add(s.Substring(start, ll));
							rc(end+1, list, memo, s);    
							list.RemoveAt(list.Count-1);
						}
					}
				}                
			}
		}
	}
}