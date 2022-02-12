using System;
using System.Collections.Generic;

// https://leetcode.com/problems/longest-consecutive-sequence/
namespace _csharp
{
	public class _128_longest_consecutive_sequence
	{
		public int LongestConsecutive(int[] nums) {
			var set = new HashSet<int>();
			foreach(int x in nums){
				if(!set.Contains(x))
					set.Add(x);
			}

			int ans = 0;
			foreach(int x in nums){
				int gt = x+1;
				int c = 1;
				while(set.Contains(gt)){
					set.Remove(gt);
					++c;
					gt++;
				}

				int ls = x-1;
				while(set.Contains(ls)){
					set.Remove(ls);
					++c;
					ls--;
				}

				ans = Math.Max(ans, c);
			}

			return ans;
		}
	}
}