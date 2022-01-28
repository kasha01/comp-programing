using System;
using System.Collections.Generic;

// https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/
namespace _csharp
{
	public class _1239_maximum_length_of_a_concatenated_string_with_unique_characters
	{
		public int MaxLength(IList<string> arr) {
			int n = arr.Count;
			int[] mask = new int[n];

			for(int i=0;i<n;++i){
				int binary_rep = 0;
				string s = arr[i];
				int m = s.Length;
				for(int j=0;j<m;++j){
					int ascii = s[j] - 97;
					int shift = 1 << ascii;

					if((binary_rep & shift) != 0){
						// this is a duplicate letter within the same word
						binary_rep=-1; break;
					}

					binary_rep = binary_rep | shift;
				}
				mask[i] = binary_rep;
			}

			rc(0,"",0,arr,mask);
			return ans;
		}

		int ans = 0;
		private void rc(int start, string concat_s, int concat_mask, IList<string> arr, int[] mask){        
			for(int i=start;i<arr.Count;++i){
				if(mask[i] == -1 || (concat_mask & mask[i]) != 0) continue;

				rc(i+1, concat_s + arr[i], concat_mask | mask[i], arr, mask);
			}

			ans = Math.Max(ans, concat_s.Length);
		}    
	}
}