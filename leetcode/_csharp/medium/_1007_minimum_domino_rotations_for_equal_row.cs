using System;

// https://leetcode.com/problems/minimum-domino-rotations-for-equal-row/
namespace _csharp
{
	public class _1007_minimum_domino_rotations_for_equal_row
	{
		public int MinDominoRotations(int[] tops, int[] bottoms) {
			int n = tops.Length;
			if(n==1) return 0;

			int key1=tops[0]; int key2=bottoms[0];

			// solve for key1 (top key)
			int minRotation_1_a = getMinRotation(tops,bottoms,key1,n,0);

			int minRotation_1_b = int.MaxValue;
			if(key1 != key2){
				// rotate top key with bottom key and compute again.
				minRotation_1_b = getMinRotation(tops,bottoms,key2,n,1);
			}

			// solve of key 2 (bottom key)
			int minRotation_2_a = getMinRotation(bottoms,tops,key2,n,0);

			int minRotation_2_b = int.MaxValue;
			if(key1 != key2){
				// rotate bottom key with top key and compute again.
				minRotation_2_b = getMinRotation(bottoms,tops,key1,n,1);
			}

			int x = Math.Min(minRotation_2_b, Math.Min(minRotation_2_a, Math.Min(minRotation_1_a,minRotation_1_b)));
			return x == int.MaxValue ? -1 : x;
		}

		private int getMinRotation(int[] first, int[] second, int key, int n, int init_rotation){
			int rotation = init_rotation;
			for(int i=1;i<n;++i){
				if(first[i] == key){
					continue;
				}

				// i have to rotate if i can
				if(second[i] == key){
					rotation++;
				}
				else{
					return int.MaxValue;
				}
			}
			return rotation;
		}
	}
}

