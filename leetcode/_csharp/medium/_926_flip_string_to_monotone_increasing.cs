using System;

// https://leetcode.com/problems/flip-string-to-monotone-increasing/
namespace _csharp
{
	public class _926_flip_string_to_monotone_increasing
	{
		public int MinFlipsMonoIncr(string s) {
			int n = s.Length;
			int[] all_zero = new int[n+2];
			int[] all_one = new int[n+2];

			int i=1; int j=n;
			while(i<=n){
				char x = s[i-1];
				char y = s[j-1];

				if(x=='0'){
					all_zero[i] = all_zero[i-1];
				}
				else{
					all_zero[i] = all_zero[i-1] + 1;
				}

				if(y=='1'){
					all_one[j] = all_one[j+1];
				}
				else{
					all_one[j] = all_one[j+1] + 1;
				}

				i++; j--;
			}

			int flips = int.MaxValue;
			for(int k=1;k<=n;++k){
				// k is my split point (1st "1").
				int f = all_zero[k-1] + all_one[k+1];
				flips = Math.Min(flips, f);
			}

			return flips;
		}
	}
}