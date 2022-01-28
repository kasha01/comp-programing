using System;

// https://leetcode.com/problems/rank-transform-of-an-array/
namespace _csharp
{
	public class _1331_rank_transform_of_an_array
	{
		public int[] ArrayRankTransform(int[] arr) {
			int n = arr.Length;

			// Tuple: value | index
			var rank = new Tuple<int,int>[n];

			for(int i=0;i<n;++i){
				rank[i] = Tuple.Create(arr[i],i);
			}

			Array.Sort(rank, (i1,i2) => Compare(i1,i2));

			int[] ans = new int[n];

			int r = 1;
			for(int i=0;i<n;++i){
				int v = rank[i].Item1;
				int idx = rank[i].Item2;
				if(i>0){
					int prev_v = rank[i-1].Item1;
					if(prev_v < v) ++r;
				}
				ans[idx] = r;
			}

			return ans;
		}

		private static int Compare(Tuple<int,int> a, Tuple<int,int> b){
			int va = a.Item1;
			int vb = b.Item1;

			if(va<vb) return -1;
			if(va>vb) return 1;

			return 0;
		}
	}
}