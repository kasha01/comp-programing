using System;

// https://leetcode.com/problems/splitting-a-string-into-descending-consecutive-values/
namespace _csharp
{
	public class _1849_splitting_a_string_into_descending_consecutive_values
	{
		public bool SplitString(string s) {
			return rc(0,-1,0,s,s.Length);
		}

		private bool rc(int start, long prevNum, int splitCount, string s, int n){
			if(start>=n){
				return splitCount>=2;
			}

			long num = 0; int m=1;
			for(int i=start;i<n;++i){
				int x=s[i] - '0';
				num = (num*10) + x;

				if(prevNum != -1){
					if(prevNum <= num) return false;
					if(prevNum > num && prevNum-num != 1) continue;                
				}

				if(rc(i+1,num,splitCount+1,s,n)) return true;
			}

			return false;
		}
	}
}

