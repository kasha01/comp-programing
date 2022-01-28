using System;

// https://leetcode.com/problems/count-number-of-pairs-with-absolute-difference-k/
namespace _csharp
{
	public class _2006_count_number_of_pairs_with_absolute_difference_k
	{
		public int CountKDifference(int[] nums, int k) {
			int[] freq = new int[200];
			int max = -1;
			foreach(int x in nums){
				freq[x]++;
				max = Math.Max(max, x);
			}

			int ans = 0;
			for(int i=1;i<=200;++i){
				int a = i;
				int b = i+k;

				if(b > max) break;

				ans = ans + (freq[a] * freq[b]);
			}

			return ans;
		}
	}
}