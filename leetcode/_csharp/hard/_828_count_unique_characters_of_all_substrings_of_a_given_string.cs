using System;

// https://leetcode.com/problems/count-unique-characters-of-all-substrings-of-a-given-string/
namespace _csharp
{
	public class _828_count_unique_characters_of_all_substrings_of_a_given_string
	{
		public int UniqueLetterString(string s) {
			int n = s.Length;
			int[] left = new int[n];
			int[] right = new int[n];

			int[] last_char_pos_left = new int[26];
			int[] last_char_pos_right = new int[26];

			for(int i=0;i<26;++i){
				last_char_pos_left[i] = -1;
				last_char_pos_right[i] = -1;
			}

			for(int i=0;i<n;++i){
				left[i] = i - (last_char_pos_left[s[i]-'A']);
				last_char_pos_left[s[i]-'A'] = i;
			}

			for(int i=0;i<n;++i){
				right[n-1-i] = i - (last_char_pos_right[s[n-1-i]-'A']);
				last_char_pos_right[s[n-1-i]-'A'] = i;
			}

			int sum = 0;
			for(int i=0;i<n;++i){
				sum = sum + left[i]*right[i];
			}

			return sum;
		}
	}
}