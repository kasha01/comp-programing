using System;

// https://leetcode.com/problems/count-binary-substrings/
namespace _csharp
{
	public class _696_count_binary_substrings
	{
		public int CountBinarySubstrings(string s) {
			int n = s.Length;
			int sum = 0;

			for(int i=0;i<n-1;++i){
				if(s[i] != s[i+1]){
					// expand
					char l_v=s[i]; char r_v=s[i+1];
					int l=i; int r=i+1; int sum_temp=0;
					while(l>=0 && r<n){
						if(s[l] == l_v && s[r]==r_v){
							sum_temp = (r-l+1)/2;
							--l; ++r;
						}
						else{
							break;
						}
					}

					sum = sum + sum_temp;                
				}
			}

			return sum;
		}
	}
}