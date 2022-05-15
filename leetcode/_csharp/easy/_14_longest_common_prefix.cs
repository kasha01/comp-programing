using System;

// https://leetcode.com/problems/longest-common-prefix/
namespace _csharp
{
	public class _14_longest_common_prefix
	{
		public string LongestCommonPrefix(string[] strs) {
			int ptr = fn(strs);
			return strs[0].Substring(0,ptr);
		}

		private int fn(string[] strs){
			int n = strs.Length;

			int ptr=0;
			while(true){
				if(ptr>=strs[0].Length) return ptr;

				char c = strs[0][ptr];

				for(int i=1;i<n;++i){
					if(ptr>=strs[i].Length) return ptr;

					if(c != strs[i][ptr]) return ptr;
				}

				++ptr;
			}

			return ptr;
		}


		// using sorting
		public string LongestCommonPrefix_2(string[] strs) {
			int n = strs.Length;

			// when you sort you guarantee abc, abdef, abz
			Array.Sort(strs);

			string first = strs[0];
			string last = strs[n-1];

			int i=0;
			while(i<first.Length && i<last.Length){
				if(first[i] != last[i]) break;

				++i;
			}

			return first.Substring(0,i);
		}
	}
}