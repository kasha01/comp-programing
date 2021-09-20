using System;

// https://leetcode.com/problems/permutation-in-string/
namespace _csharp
{
	public class _567_permutation_in_string2
	{
		public bool CheckInclusion(string s1, string s2) {
			int n = s1.Length;
			if(s2.Length<n) return false;

			int[] target = new int[26];
			foreach(char c in s1){
				target[c-'a']++;
			}

			int lower_bound=0;
			int upper_bound=n-1;

			int[] freq = new int[26];
			for(int i=0;i<=upper_bound-1;++i){
				freq[s2[i]-'a']++;                
			}

			while(upper_bound<s2.Length){
				// check if freq matches target array
				freq[s2[upper_bound] - 'a']++;            

				bool isMatch=true;
				for(int k=lower_bound;k<=upper_bound;++k){
					char c = s2[k];
					if(target[c-'a'] != freq[c-'a']){
						isMatch=false;
						break; 
					};
				}

				if(isMatch) return true;

				freq[s2[lower_bound] -'a']--;
				upper_bound++;
				lower_bound++;
			}
			return false;
		}
	}
}