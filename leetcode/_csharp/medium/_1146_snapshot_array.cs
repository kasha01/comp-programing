using System;
using System.Collections.Generic;

// https://leetcode.com/problems/snapshot-array/
namespace _csharp
{
	public class _1146_snapshot_array
	{
		private List<int>[] memo;
		private int snapId;

		public void SnapshotArray(int length) {
			memo = new List<int>[length];
			for(int i=0;i<length;++i){
				memo[i] = new List<int>();
				memo[i].Add(0);
			}
			snapId = 0;
		}

		public void Set(int index, int val) {
			int cnt = memo[index].Count;
			while(cnt-1 < snapId){
				memo[index].Add(memo[index][cnt-1]);
				cnt = memo[index].Count;
			}

			memo[index][snapId] = val;
		}

		public int Snap() {
			++snapId;
			return snapId-1;
		}

		public int Get(int index, int snap_id) {
			int idx = snap_id;
			if(snap_id >= memo[index].Count){
				idx = memo[index].Count-1;
			}
			return memo[index][idx];
		}
	}
}