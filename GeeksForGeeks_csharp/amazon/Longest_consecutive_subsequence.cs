using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/longest-consecutive-subsequence/0
namespace GeeksForGeeks_csharp
{
	public class Longest_consecutive_subsequence
	{
		static public void solve () {
			int n = 5;
			int[] items = {1,5,3,7,2};

			SortedSet<int> set = new SortedSet<int>();    

			for(int i=0;i<n;++i){
				int x = items[i];
				set.Add(x);    
			}

			int c = 1;
			int mx=1;
			int prev_v=set.Min;
			set.Remove(prev_v);
			for(int i=1;i<n;++i){
				int v = set.Min;
				if(prev_v +1 == v){
					c++;
				}
				else{
					c=1;
				}
				prev_v=v;
				set.Remove(v);

				mx=Math.Max(mx,c);
			}
			Console.WriteLine(mx);
		}
	}
}

