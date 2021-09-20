using System;

// https://leetcode.com/problems/number-of-good-ways-to-split-a-string/
namespace _csharp
{
	public class _1525_number_of_good_ways_to_split_a_string
	{
		public static int NumSplits(string s) {
			int[] freq_b = new int[26];
			foreach(char c in s){
				freq_b[c-'a']++;
			}

			int[] freq_a = new int[26];

			int count = 0;
			for(int i=0;i<s.Length-1;++i){
				char c = s[i];
				freq_a[c-'a']++;
				freq_b[c-'a']--;
				if(isGood(freq_a,freq_b)) ++count;
			}

			return count;
		}

		static bool isGood(int[] freq_a, int[] freq_b){
			int unique_a = 0; int unique_b = 0;
			for(int i=0;i<26;++i){
				if(freq_a[i] > 0) unique_a++;
				if(freq_b[i] > 0) unique_b++;
			}

			return unique_a == unique_b;
		}

	}
}

