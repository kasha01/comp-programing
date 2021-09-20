using System;
using System.Collections.Generic;

// https://leetcode.com/problems/daily-temperatures/
namespace _csharp
{
	public class _739_daily_temperatures
	{
		public int[] DailyTemperatures(int[] T) {
			int n = T.Length;
			Stack<int> st = new Stack<int>();
			int[] ans = new int[n];

			for(int i=0;i<n;++i){
				while(st.Count > 0 && T[st.Peek()] < T[i]){
					int x = st.Pop();
					ans[x] = i-x;
				}
				st.Push(i);
			}

			while(st.Count > 0){
				ans[st.Pop()] = 0;
			}

			return ans;
		}
	}
}

