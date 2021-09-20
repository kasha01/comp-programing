using System;
using System.Collections.Generic;

// https://leetcode.com/problems/minimize-hamming-distance-after-swap-operations/
namespace _csharp
{
	public class _1722_minimize_hamming_distance_after_swap_operations
	{
		public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps) {
			int n = source.Length;
			int[] disJoint = new int[n];
			// init disjoint
			for(int i=0;i<n;++i){
				disJoint[i] = i;
			}

			for(int i=0;i<allowedSwaps.Length;++i){
				int a = allowedSwaps[i][0]; int b = allowedSwaps[i][1];
				int parent_a=find(disJoint,a); int parent_b=find(disJoint,b);
				if(parent_a != parent_b) disJoint[parent_b] = parent_a;
			}

			// key:disJoint parent |-| value:disjoint set => key:number | value: number count
			Dictionary<int,Dictionary<int,int>> map = new Dictionary<int,Dictionary<int,int>>();
			for(int i=0;i<n;++i){
				int i_parent = find(disJoint,i);
				if(!map.ContainsKey(i_parent)){
					map.Add(i_parent,new Dictionary<int,int>());
				}

				var mySet = map[i_parent];
				if(!mySet.ContainsKey(source[i])){
					mySet.Add(source[i],0);
				}
				mySet[source[i]]++;
			}

			// check if I can get target number in source at index i
			int distance = 0;
			for(int i=0;i<target.Length;++i){
				int target_x = target[i];
				int parent_of_i = find(disJoint,i);
				var disJoint_set_at_i = map[parent_of_i];

				if(disJoint_set_at_i.ContainsKey(target_x) && disJoint_set_at_i[target_x] > 0){
					disJoint_set_at_i[target_x]--;  // number can be swapped
				}
				else{
					distance++;
				}
			}

			return distance;
		}

		private int find(int[] disJoint, int x){
			if(disJoint[x]==x) return x;
			return find(disJoint,disJoint[x]);
		}
	}
}