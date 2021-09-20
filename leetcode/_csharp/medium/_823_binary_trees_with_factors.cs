using System;
using System.Collections.Generic;

// https://leetcode.com/problems/binary-trees-with-factors/
namespace _csharp
{
	public class _823_binary_trees_with_factors
	{

		public int NumFactoredBinaryTrees(int[] arr) {
			int m = 1000000007;
			int n = arr.Length;
			long count = 0;

			// key: root | value: count of trees
			Dictionary<int,long> tree = new Dictionary<int,long>();

			Array.Sort(arr);
			for(int i=0;i<n;++i){
				int root = arr[i];
				tree.Add(root,1);

				for(int j=i-1;j>=0;--j){
					int child1 = arr[j];
					int child2 = root/child1;

					if(root%child1==0 && tree.ContainsKey(child2)){
						tree[root] = tree[root] + tree[child1] * tree[child2];
					}
				}

				count += tree[root];
			}

			return (int)(count%m);
		}
	}
}

