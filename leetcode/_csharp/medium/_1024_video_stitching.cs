using System;
using System.Collections.Generic;

// https://leetcode.com/problems/video-stitching/
namespace _csharp
{
	public class _1024_video_stitching
	{
		public int VideoStitching(int[][] clips, int T) {
			if(T == 0)
				return 0;

			// memo is how many clips it took me to reach to time-point t
			int[] memo = new int[T+1];

			Array.Sort (clips, new MyComparer ());

			// loop through all clips
			for (int i = 0; i < clips.Length; ++i) {
				int start = clips [i] [0];
				int end = clips [i] [1];

				if(start > T)
					continue;

				if(start!=0 && memo[start] == 0){
					// I have no way to get to this start point. excluding if I am at frame 0
					return -1;
				}

				end = end > T ? T : end;
				int x = memo [start];

				// for each clip, compute how much this clip is extended.
				for (int j=start; j<=end && j<=T; ++j) {
					if(j==0){
						// i am at the first frame (0) continue. 
						continue;
					}

					if (memo [j] == 0) {
						memo [j] = x + 1;	// memo[j]=0 means memo was not set yet. so just set it.
					} else {
						memo [j] = Math.Min (memo [j], x + 1);	// compute the min value.
					}
				}
			}

			return memo [T] == 0 ? -1 : memo[T];
		}

		class MyComparer : IComparer<int[]>{
			public int Compare(int[] a, int[] b){
				if (a [0] < b [0])
					return -1;

				if (a [0] > b [0])
					return 1;

				return 0;
			}
		}
	}
}

