using System;
using System.Collections.Generic;

// https://leetcode.com/problems/4sum-ii/
namespace _csharp
{
	public class _454_4sum_ii
	{
		public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4) {
			Dictionary<int,int> map_1_2 = new Dictionary<int,int>();     
			Dictionary<int,int> map_3_4 = new Dictionary<int,int>();     

			int n = nums1.Length;
			for(int i=0;i<n;++i){
				for(int j=0;j<n;++j){
					int sum1_2 = nums1[i] + nums2[j];
					int sum3_4 = nums3[i] + nums4[j];

					if(!map_1_2.ContainsKey(sum1_2)){
						map_1_2.Add(sum1_2,0);
					}
					if(!map_3_4.ContainsKey(sum3_4)){
						map_3_4.Add(sum3_4,0);
					}

					map_1_2[sum1_2]++;
					map_3_4[sum3_4]++;
				}
			}

			int ans = 0;
			foreach(var kvp in map_1_2){
				int ab = kvp.Key;
				int cd = ab*-1;
				if(map_3_4.ContainsKey(cd)){
					ans = ans + (map_3_4[cd] * map_1_2[ab]);
				}
			}

			return ans;
		}
	}
}