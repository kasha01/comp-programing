using System;
using System.Collections.Generic;

// https://leetcode.com/problems/two-out-of-three/
namespace _csharp
{
	public class _2032_two_out_of_three
	{
		public IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3) {
			bool[] arr_i = new bool[101];
			bool[] arr_j = new bool[101];
			bool[] arr_k = new bool[101];

			for(int i=0;i<nums1.Length;++i){
				arr_i[nums1[i]] = true;
			}

			for(int i=0;i<nums2.Length;++i){
				arr_j[nums2[i]] = true;
			}

			for(int i=0;i<nums3.Length;++i){
				arr_k[nums3[i]] = true;
			}

			List<int> list = new List<int>();
			for(int i=1;i<=100;++i){
				int a = arr_i[i] ? 1 : 0;
				int b = arr_j[i] ? 1 : 0;
				int c = arr_k[i] ? 1 : 0;

				if(a+b+c>=2) list.Add(i);
			}

			return list;
		}
	}
}